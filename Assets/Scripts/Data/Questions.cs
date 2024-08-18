using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

public class Questions : Singleton<Questions>
{
    private QuestionDto[] _questions;

    public async Task LoadData()
    {
        var assetLoader = new LocalAssetLoader<TextAsset>();
        var textAsset = await assetLoader.LoadAsset(Constants.QUESTION_DATA_ASSET_KEY);
        _questions = JsonConvert.DeserializeObject<QuestionDto[]>(textAsset.text);
        assetLoader.UnloadAsset();
    }

    public QuestionDto GetById(int id)
    {
        return _questions.Single(q => q.id == id);
    }
}