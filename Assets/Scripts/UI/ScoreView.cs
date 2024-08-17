using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    private PlayerState _playerState;

    [SerializeField]
    private Text _scoreText;

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
