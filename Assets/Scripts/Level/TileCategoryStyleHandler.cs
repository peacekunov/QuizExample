using UnityEngine;
using Zenject;

public class TileCategoryStyleHandler : MonoBehaviour
{
    [SerializeField]
    private QuestionCategoryStyleList _styles;

    private Questions _questions;

    private QuestionTileModel _model;

    private TileView _view;

    [Inject]
    public void Constructor(Questions questions)
    {
        Debug.Log("TileCategoryStyleHandler constructor");
        _questions = questions;
    }

    private void Awake()
    {
        _model = GetComponent<QuestionTileModel>();
        _view = GetComponent<TileView>();
    }

    private void Start()
    {
        SetStyle(_questions.GetById(_model.Id).category);
    }

    public void SetStyle(QuestionCategory category)
    {
        var style = _styles.GetStyle(category);
        _view.TileColor = style.TileColor;
        _view.Icon = style.Icon;
    }
}