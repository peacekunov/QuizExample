using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

public class LocalAssetLoader<T> : AssetLoader<T>
{
    public async Task<T> LoadAsset(string assetKey)
    {
        var handle = Addressables.LoadAssetAsync<T>(assetKey);
        return await handle.Task;
    }

    public void UnloadAsset(T asset)
    {
        Addressables.Release(asset);
    }
}