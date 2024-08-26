using UnityEngine;

public class QuestionModel
{
    private Questions _questions;

    private AssetLoader<Sprite> _imageLoader;

    private QuestionDto _questionData;

    private Sprite _image;

    private bool _isAnswered;

    public event System.Action<QuestionDto, Sprite> QuestionLoaded;

    public event System.Action<int, bool> Answered;

    public int QuestionId => _questionData.id;

    public QuestionModel(Questions questions, AssetLoader<Sprite> imageLoader)
    {
        _questions = questions;
        _imageLoader = imageLoader;
    }

    public async void LoadQuestion(int id)
    {
        _questionData = _questions.GetById(id);
        _image = await _imageLoader.LoadAsset(Constants.QUESTION_IMAGES_ASSET_KEY + _questionData.id + ".jpg");
        QuestionLoaded?.Invoke(_questionData, _image);
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
        _imageLoader.UnloadAsset(_image);
    }
}