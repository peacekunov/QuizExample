using System.Collections;
using UnityEngine;

public class QuestionPresenter : MonoBehaviour
{
    [SerializeField]
    private QuestionView _view;

    private QuestionModel _model;

    private PlayerState _playerState;

    private void Awake()
    {
        _playerState = GameObject.FindWithTag(Constants.PLAYER_STATE_TAG).GetComponent<PlayerState>();
        _model = new QuestionModel();
    }

    private void OnEnable()
    {
        _model.QuestionLoaded += _view.ShowQuestion;
        _model.Answered += OnAnswered;

        _view.AnswerSelected += Answer;
    }

    private void OnDisable()
    {
        _model.QuestionLoaded -= _view.ShowQuestion;
        _model.Answered -= OnAnswered;

        _view.AnswerSelected -= Answer;
    }

    private void OnDestroy()
    {
        _model.UnloadResources();
    }

    public void ShowQuestion(int questionId)
    {
        _model.LoadQuestion(questionId);
    }

    public void Answer(int answerIndex)
    {
        _model.Answer(answerIndex);
    }

    private void OnAnswered(int answerIndex, bool isRight)
    {
        _playerState.CompleteStep(_model.QuestionId);

        if (isRight)
        {
            _playerState.AddScore(Constants.CORRECT_ANSWER_SCORE);
        }

        _playerState.SaveData();

        _view.DisplayUserAnswer(answerIndex, isRight);

        StartCoroutine(CloseQuestion());
    }

    private IEnumerator CloseQuestion()
    {
        yield return new WaitForSeconds(Constants.CLOSE_QUESTION_AFTER_ANSWER_DELAY);

        Destroy(gameObject);
    }
}