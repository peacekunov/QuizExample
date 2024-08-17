using Newtonsoft.Json;
using UnityEngine;

public class FileDataProvider : DataProvider
{
    private string _filePath;

    public FileDataProvider(string filePath)
    {
        _filePath = filePath;
    }

    public QuestionDto[] GetQuestions()
    {
        var textAsset = Resources.Load<TextAsset>(_filePath);
        var result = JsonConvert.DeserializeObject<QuestionDto[]>(textAsset.text);
        return result;
    }
}