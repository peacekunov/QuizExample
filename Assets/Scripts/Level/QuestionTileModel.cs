using Zenject;

public class QuestionTileModel : TileModel
{
    private Question.Factory _questionFactory;

    [Inject]
    public void Constructor(Question.Factory questionFactory)
    {
        _questionFactory = questionFactory;
    }

    public override void Launch()
    {
        _questionFactory.Create(_id);
    }
}