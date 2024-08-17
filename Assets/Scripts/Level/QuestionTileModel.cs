public class QuestionTileModel : TileModel
{
    public override void Launch()
    {
        UIManager.Instance.ShowQuestionScreen(_id);
    }
}