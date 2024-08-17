using System.Collections;
using UnityEngine;

public interface ImageLoader
{
    public Sprite Image { get; }

    IEnumerator LoadImage(int id);
}