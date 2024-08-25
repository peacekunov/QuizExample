using UnityEngine;

public class QuestionTileModel : TileModel
{
    public override void Launch()
    {
        var uiManager = GameObject.FindWithTag(Constants.UI_MANAGER).GetComponent<UIManager>();
        uiManager.ShowQuestionScreen(_id);
    }
}