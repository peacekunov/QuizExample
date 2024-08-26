using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

public class Questions
{
    private AssetLoader<TextAsset> _assetLoader;

    private QuestionDto[] _questions;

    public Questions(AssetLoader<TextAsset> assetLoader)
    {
        _assetLoader = assetLoader;
    }

    public async Task LoadData()
    {
        var textAsset = await _assetLoader.LoadAsset(Constants.QUESTION_DATA_ASSET_KEY);
        _questions = JsonConvert.DeserializeObject<QuestionDto[]>(textAsset.text);
        _assetLoader.UnloadAsset(textAsset);
    }

    public QuestionDto GetById(int id)
    {
        return _questions.Single(q => q.id == id);
    }
}