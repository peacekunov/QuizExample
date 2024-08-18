using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Canvas _mainCanvas;

    [SerializeField]
    private GameObject _levelPagePrefab;

    [SerializeField]
    private QuestionPresenter _questionPagePrefab;

    public void ShowLevelScreen()
    {
        Instantiate(_levelPagePrefab, _mainCanvas.transform);
    }

    public void ShowQuestionScreen(int questionId)
    {
        var questionPresenter = Instantiate(_questionPagePrefab, _mainCanvas.transform);
        questionPresenter.ShowQuestion(questionId);
    }
}