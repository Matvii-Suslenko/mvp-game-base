using System.Collections.Generic;
using MvpBaseGame.Promises;
using UnityEngine;

namespace MvpBaseGame.Assets
{
    public interface IAssetsLoader
    {
        IPromise<T> LoadAsset<T>(string assetUrl, bool asyncMode = true) where T : Object;
        IPromise<List<T>> LoadAssets<T>(IEnumerable<string> assetUrls, bool asyncMode = true);
        T GetAsset<T>(string assetPath);
    }
}