using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public class Questions : Singleton<Questions>
{
    private QuestionDto[] _questions;

    public IEnumerable<QuestionDto> All => _questions;

    public int Count => _questions.Length;

    private void Start()
    {
        LoadData();
    }

    public void LoadData()
    {
        var assetLoader = new LocalAssetLoader<TextAsset>();
        assetLoader.DataLoaded += textAsset =>
        {
            _questions = JsonConvert.DeserializeObject<QuestionDto[]>(textAsset.text);
            assetLoader.UnloadAsset();
            UIManager.Instance.ShowLevelScreen();
        };
        assetLoader.LoadAsset(Constants.QUESTION_DATA_KEY);
    }

    public QuestionDto GetById(int id)
    {
        return _questions.SingleOrDefault(q => q.id == id);
    }
}