using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LocalAssetLoader<T> : AssetLoader<T>
{
    private AsyncOperationHandle<T> _handle;

    public event System.Action<T> DataLoaded;

    public void LoadAsset(string assetKey)
    {
        var operationHandle = Addressables.LoadAssetAsync<T>(assetKey);
        operationHandle.Completed += handle =>
        {
            _handle = handle;
            DataLoaded?.Invoke(_handle.Result);
        };
    }

    public void UnloadAsset()
    {
        Addressables.Release(_handle);
    }

    public void UnloadAsset(T asset)
    {
        Addressables.Release(asset);
    }
}