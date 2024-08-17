using System.Linq;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private int _score;

    private LevelStep[] _steps;

    public event System.Action<int> ScoreChanged;

    public event System.Action<int> StepCompleted;

    public void AddScore(int addScore)
    {
        _score += addScore;
        ScoreChanged?.Invoke(_score);
    }

    public void CompleteStep(int id)
    {
        // _steps.Single(s => s.Id == id).Complete();
        StepCompleted?.Invoke(id);
    }
}

public class LevelStep
{
    private int _id;

    private bool _isCompleted;

    public int Id => _id;

    public bool IsCompleted => _isCompleted;

    public void Complete()
    {
        _isCompleted = true;
    }
}