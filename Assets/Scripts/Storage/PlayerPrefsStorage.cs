using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

public class PlayerPrefsStorage<T> : Storage<T>
{
    private string _key;

    public PlayerPrefsStorage(string key)
    {
        _key = key;
    }

    public bool HasData()
    {
        return PlayerPrefs.HasKey(_key);
    }

    public Task<T> LoadData()
    {
        var json = PlayerPrefs.GetString(_key);
        return Task.FromResult(JsonConvert.DeserializeObject<T>(json));
    }

    public void SaveData(T data)
    {
        var json = JsonConvert.SerializeObject(data);
        PlayerPrefs.SetString(_key, json);
        PlayerPrefs.Save();
    }
}