using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private Canvas _mainCanvas;

    [SerializeField]
    private GameObject _levelPrefab;

    [SerializeField]
    private QuestionPresenter _questionPagePrefab;

    public void ShowLevelScreen()
    {
        Instantiate(_levelPrefab, _mainCanvas.transform);
    }

    public void ShowQuestionScreen(int questionId)
    {
        var questionPresenter = Instantiate(_questionPagePrefab, _mainCanvas.transform);
        questionPresenter.ShowQuestion(questionId);
    }
}