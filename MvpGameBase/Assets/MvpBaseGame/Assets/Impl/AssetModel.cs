using System.Collections.Generic;
using MvpBaseGame.Promises;
using MvpBaseGame.Promises.Impl;
using UnityEditor;
using UnityEngine;

namespace MvpBaseGame.Assets.Impl
{
    public class AssetModel : IAssetModel
    {
        public IPromise<T> LoadAsset<T>(string assetUrl, bool asyncMode = true) where T : Object
        {
            var promise = new Promise<T>();
            promise.Dispatch(AssetDatabase.LoadAssetAtPath<T>(assetUrl));;
            return promise;
        }

        public IPromise<List<T>> LoadAssets<T>(IEnumerable<string> assetUrls, bool asyncMode = true)
        {
            throw new System.NotImplementedException();
        }

        public T GetAsset<T>(string assetPath)
        {
            throw new System.NotImplementedException();
        }

        public void Initialize()
        {
        }
    }
}