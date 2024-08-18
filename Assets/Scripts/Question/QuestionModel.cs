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

    public async void LoadQuestion(int id)
    {
        _questionData = Questions.Instance.GetById(id);
        var image = await _imageLoader.LoadAsset(Constants.QUESTION_IMAGES_ASSET_KEY + _questionData.id + ".jpg");
        QuestionLoaded?.Invoke(_questionData, image);
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