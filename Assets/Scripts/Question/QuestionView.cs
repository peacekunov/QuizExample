using UnityEngine;
using UnityEngine.UI;

public class QuestionView : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    [SerializeField]
    private Text _title;

    [SerializeField]
    private Transform _buttonsLayout;

    [SerializeField]
    private AnswerButton _answerButtonPrefab;

    private AnswerButton[] _buttons;

    public event System.Action<int> AnswerSelected;

    public void ShowQuestion(QuestionDto question, Sprite image)
    {
        _image.sprite = image;
        _title.text = question.title;

        _buttons = new AnswerButton[question.answers.Length];
        for (int i = 0; i < question.answers.Length; i++)
        {
            var button = Instantiate(_answerButtonPrefab, _buttonsLayout);
            _buttons[i] = button;
            button.Text = question.answers[i].text;
            button.Init(i, AnswerSelected);
        }
    }

    public void DisplayUserAnswer(int answerIndex, bool isRight)
    {
        if (isRight)
        {
            _buttons[answerIndex].SetRightColor();
        }
        else
        {
            _buttons[answerIndex].SetWrongColor();
        }
    }
}