using System.Threading.Tasks;

public interface AssetLoader<T>
{
    Task<T> LoadAsset(string assetKey);

    void UnloadAsset();

    void UnloadAsset(T asset);
}