using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LocalAssetLoader<T> : AssetLoader<T>
{
    private AsyncOperationHandle<T> _handle;

    public async Task<T> LoadAsset(string assetKey)
    {
        _handle = Addressables.LoadAssetAsync<T>(assetKey);
        return await _handle.Task;
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