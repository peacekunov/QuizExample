using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private Canvas _mainCanvas;

    [SerializeField]
    private QuestionPresenter _questionPagePrefab;

    public void ShowQuestionScreen(int questionId)
    {
        var questionPresenter = Instantiate(_questionPagePrefab);
        questionPresenter.ShowQuestion(questionId);
    }
}