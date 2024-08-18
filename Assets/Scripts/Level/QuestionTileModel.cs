public class QuestionTileModel : TileModel
{
    public override void Launch()
    {
        FindFirstObjectByType<UIManager>().ShowQuestionScreen(_id);
    }
}