using System.Collections;
using UnityEngine;

public class ResourceImageLoader : ImageLoader
{
    private ResourceRequest _request;

    public Sprite Image => (Sprite)_request.asset;

    public IEnumerator LoadImage(int id)
    {
        _request = Resources.LoadAsync<Sprite>(Constants.QUESTION_IMAGES_RESOURCES_PATH + id);
        yield return _request;
    }
}