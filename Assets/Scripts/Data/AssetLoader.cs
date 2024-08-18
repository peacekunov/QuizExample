public interface AssetLoader<T>
{
    event System.Action<T> DataLoaded;

    void LoadAsset(string assetKey);

    void UnloadAsset();

    void UnloadAsset(T asset);
}