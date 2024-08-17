using UnityEngine;
using UnityEngine.UI;

public class TileView : MonoBehaviour
{
    [SerializeField]
    private TileStateStyle _blockedStateStyle;

    [SerializeField]
    private TileStateStyle _availableStateStyle;

    [SerializeField]
    private TileStateStyle _completedStateStyle;

    [SerializeField]
    protected Image _tile;

    [SerializeField]
    protected Image _icon;

    public Color TileColor
    {
        set => _tile.color = value;
    }

    public Sprite Icon
    {
        set => _icon.sprite = value;
    }

    public virtual void SetBlockedStyle()
    {
        SetStyle(_blockedStateStyle);
    }

    public virtual void SetAvailableStyle()
    {
        SetStyle(_availableStateStyle);
    }

    public virtual void SetCompletedStyle()
    {
        SetStyle(_completedStateStyle);
    }

    private void SetStyle(TileStateStyle mapNodeStateStyle)
    {
        _tile.sprite = mapNodeStateStyle.TileSprite;
        _tile.transform.localScale = Vector3.one * mapNodeStateStyle.TileScale;
        _icon.color = mapNodeStateStyle.IconColor;
    }
}
