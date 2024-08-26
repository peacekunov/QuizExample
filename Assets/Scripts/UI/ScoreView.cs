using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    private PlayerState _playerState;

    [Inject]
    public void Constructor(PlayerState playerState)
    {
        _playerState = playerState;
    }

    private void OnEnable()
    {
        _playerState.ScoreChanged += SetScore;
    }

    private void OnDisable()
    {
        _playerState.ScoreChanged -= SetScore;
    }

    public void SetScore(int score)
    {
        _scoreText.text = score.ToString();
    }
}
