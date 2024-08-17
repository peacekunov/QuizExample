using System.Collections;
using UnityEngine;

public class QuestionModel
{
    private QuestionDto _questionData;

    private bool _isAnswered;

    private ImageLoader _imageLoader;

    public event System.Action<QuestionDto, Sprite> QuestionLoaded;

    public event System.Action<int, bool> Answered;

    public int QuestionId => _questionData.id;

    public QuestionModel()
    {
        _imageLoader = new ResourceImageLoader();
    }

    public IEnumerator LoadQuestion(int id)
    {
        _questionData = Questions.Instance.GetById(id);
        yield return _imageLoader.LoadImage(_questionData.id);
        QuestionLoaded(_questionData, _imageLoader.Image);
    }

    public void Answer(int answerIndex)
    {
        if (!_isAnswered)
        {
            _isAnswered = true;
            bool isRight = _questionData.answers[answerIndex].isRight;
            Answered?.Invoke(answerIndex, isRight);
        }
    }
}