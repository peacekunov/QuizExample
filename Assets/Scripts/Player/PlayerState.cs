using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private PlayerData _playerData;

    private Storage<PlayerData> _storage;

    public event System.Action<int> ScoreChanged;

    public event System.Action<int> StepCompleted;

    private void Awake()
    {
        _storage = new PlayerPrefsStorage<PlayerData>(Constants.PLAYER_DATA_STORAGE_KEY);
        _playerData = new PlayerData();
    }

    public async Task LoadData()
    {
        if (_storage.HasData())
        {
            _playerData = await _storage.LoadData();
            ScoreChanged?.Invoke(_playerData.Score);
        }
    }

    public void AddScore(int addScore)
    {
        _playerData.Score += addScore;
        ScoreChanged?.Invoke(_playerData.Score);
    }

    public void CompleteStep(int id)
    {
        _playerData.Steps.SingleOrDefault(s => s.Id == id).Completed = true;
        StepCompleted?.Invoke(id);
    }

    public void SaveData()
    {
        _storage.SaveData(_playerData);
    }
}