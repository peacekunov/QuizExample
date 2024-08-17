using UnityEngine;

[System.Serializable]
public class TileStateStyle
{
    [SerializeField]
    private Sprite _tileSprite;

    [SerializeField]
    private float _tileScale;

    [SerializeField]
    private Color _iconColor;

    public Sprite TileSprite => _tileSprite;

    public float TileScale => _tileScale;

    public Color IconColor => _iconColor;
}