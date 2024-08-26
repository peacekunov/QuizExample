using System.Linq;
using System.Threading.Tasks;

public class PlayerState
{
    private PlayerData _playerData;

    private Storage<PlayerData> _storage;

    public int Score => _playerData.Score;

    public bool HasLevelData => _playerData.Steps.Count() > 0;

    public event System.Action<int> ScoreChanged;

    public event System.Action<int> StepCompleted;

    public PlayerState(PlayerData playerData, Storage<PlayerData> storage)
    {
        _playerData = playerData;
        _storage = storage;
    }

    public async Task LoadData()
    {
        if (_storage.HasData())
        {
            _playerData = await _storage.LoadData();
            ScoreChanged?.Invoke(_playerData.Score);
        }
    }

    public void SetLevelStaps(LevelStepData[] steps)
    {
        _playerData.Steps = steps;
    }

    public bool IsStepCompleted(int id)
    {
        return _playerData.GetStep(id).Completed;
    }

    public void AddScore(int addScore)
    {
        _playerData.Score += addScore;
        ScoreChanged?.Invoke(_playerData.Score);
    }

    public void CompleteStep(int id)
    {
        _playerData.GetStep(id).Completed = true;
        StepCompleted?.Invoke(id);
    }

    public void SaveData()
    {
        _storage.SaveData(_playerData);
    }
}