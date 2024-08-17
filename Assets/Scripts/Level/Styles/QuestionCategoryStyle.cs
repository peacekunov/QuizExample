using UnityEngine;

[System.Serializable]
public class QuestionCategoryStyle
{
    [SerializeField]
    private QuestionCategory _category;

    [SerializeField]
    private Color _tileColor;

    [SerializeField]
    private Sprite _icon;

    public QuestionCategory Category => _category;

    public Color TileColor => _tileColor;

    public Sprite Icon => _icon;
}