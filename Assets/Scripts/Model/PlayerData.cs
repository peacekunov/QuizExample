using System;
using System.Linq;

public class PlayerData
{
    public int Score;

    public LevelStepData[] Steps;

    public PlayerData()
    {
        Steps = Array.Empty<LevelStepData>();
    }

    public LevelStepData GetStep(int id)
    {
        return Steps.SingleOrDefault(s => s.Id == id);
    }
}