using UnityEngine;

public class TileCategoryStyleHandler : MonoBehaviour
{
    [SerializeField]
    private QuestionCategoryStyleList _styles;

    private QuestionTileModel _model;

    private TileView _view;

    private void Awake()
    {
        _model = GetComponent<QuestionTileModel>();
        _view = GetComponent<TileView>();
    }

    private void Start()
    {
        SetStyle(Questions.Instance.GetById(_model.Id).category);
    }

    public void SetStyle(QuestionCategory category)
    {
        var style = _styles.GetStyle(category);
        _view.TileColor = style.TileColor;
        _view.Icon = style.Icon;
    }
}