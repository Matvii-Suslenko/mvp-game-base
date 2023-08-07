using MvpBaseGame.Utils.CoroutineRunner;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using MvpBaseGame.Promises.Impl;
using MvpBaseGame.Promises;
using System.Collections;
using UnityEngine;
using System;

namespace MvpBaseGame.Utils.SceneLoader.Impl
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        private readonly Dictionary<string, Coroutine> _coroutines = new Dictionary<string, Coroutine>();

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public IPromise LoadScene(string scenePath, bool isAdditive, bool isAsync)
        {
            var outcome = new Promise();
            var mode = isAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single;
            var sceneName = GetSceneName(scenePath);
            if (sceneName == null)
            {
                outcome.ReportFail(new Exception($"[SceneManager]: Can't find scene with name {sceneName}"));
            }

            if (!isAsync)
            {
                SceneManager.LoadScene(sceneName, mode);
                outcome.Dispatch();
                return outcome;
            }

            var coroutine = _coroutineRunner.StartCoroutine(LoadSceneCoroutine(sceneName, mode, outcome));
            _coroutines.Add(scenePath, coroutine);
            outcome.Finally(() => { _coroutines.Remove(scenePath); });
            
            return outcome;
        }
        
        public void AbortSceneLoading(string scenePath)
        {
            _coroutines.TryGetValue(scenePath, out var coroutine);
            if (coroutine != null)
            {
                _coroutineRunner.StopCoroutine(coroutine);
                _coroutines.Remove(scenePath);
            }
        }

        private IEnumerator LoadSceneCoroutine(string sceneName, LoadSceneMode mode, IPromise outcome)
        {
            var request = SceneManager.LoadSceneAsync(sceneName,mode);
            yield return request;
            if (request == null)
            {
                outcome.ReportFail(new Exception($"[CashmanSceneManager]: Load scene {sceneName} operation return a null object"));
                yield break;
            }
    
            outcome.Dispatch();
        }
        
        public IPromise UnloadScene(string scenePath)
        {
            var outcome = new Promise();
            var scene = GetSceneByName(scenePath);
            _coroutineRunner.StartCoroutine(UnloadSceneCoroutine(scene.name, outcome));
            return outcome;
        }

        private IEnumerator UnloadSceneCoroutine(string sceneName, IPromise outcome)
        {
            yield return SceneManager.UnloadSceneAsync(sceneName);
            outcome.Dispatch();
        }

        public bool IsSceneLoaded(string scenePath)
        {
            return GetSceneByName(scenePath).isLoaded;
        }

        private Scene GetSceneByName(string scenePath)
        {
            var sceneName = GetSceneName(scenePath);
            var scene = SceneManager.GetSceneByName(sceneName);
            if (scene == null)
            {
                throw new Exception($"[CashmanSceneManager]: Can't find scene with path {scenePath}");
            }

            return scene;
        }
        
        private string GetSceneName(string assetPath)  
        {
            var ind = assetPath.LastIndexOf("/", StringComparison.Ordinal);
            if (ind > 0)
            {
                return assetPath.Substring(ind+1);
            }

            return assetPath;
        }
    }
}
