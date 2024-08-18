using UnityEngine;

public class QuestionModel
{
    private QuestionDto _questionData;

    private bool _isAnswered;

    private LocalAssetLoader<Sprite> _imageLoader;

    public event System.Action<QuestionDto, Sprite> QuestionLoaded;

    public event System.Action<int, bool> Answered;

    public int QuestionId => _questionData.id;

    public QuestionModel()
    {
        _imageLoader = new LocalAssetLoader<Sprite>();
    }

    public void LoadQuestion(int id)
    {
        _questionData = Questions.Instance.GetById(id);

        _imageLoader.DataLoaded += image =>
        {
            QuestionLoaded?.Invoke(_questionData, image);
        };
        _imageLoader.LoadAsset(Constants.QUESTION_IMAGES_KEY + _questionData.id + ".jpg");
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

    public void UnloadResources()
    {
        _imageLoader.UnloadAsset();
    }
}