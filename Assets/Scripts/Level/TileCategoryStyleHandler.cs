using UnityEngine;

public class TileCategoryStyleHandler : MonoBehaviour
{
    [SerializeField]
    private QuestionCategoryStyleList _styles;

    private QuestionTileModel _model;

    private TileView _view;

    private Questions _questions;

    private void Awake()
    {
        _model = GetComponent<QuestionTileModel>();
        _view = GetComponent<TileView>();
        _questions = GameObject.FindWithTag(Constants.QUESTIONS_TAG).GetComponent<Questions>();
    }

    private void Start()
    {
        SetStyle(_questions.GetById(_model.Id).category);
    }

    public void SetStyle(QuestionCategory category)
    {
        var style = _styles.GetStyle(category);

        if (style != null)
        {
            _view.TileColor = style.TileColor;
            _view.Icon = style.Icon;
        }
        else
        {
            Debug.LogError($"Style for category '{category}' not found");
        }
    }
}