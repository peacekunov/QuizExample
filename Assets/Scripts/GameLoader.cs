using System.Threading.Tasks;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField]
    private PlayerState _playerState;

    [SerializeField]
    private UIManager _uiManager;

    private void Start()
    {
        LoadGame();
    }

    private async void LoadGame()
    {
        var playerStateLoading = _playerState.LoadData();
        var questionDataLoading = Questions.Instance.LoadData();

        await Task.WhenAll(playerStateLoading, questionDataLoading);

        _uiManager.ShowLevelScreen();

        Destroy(gameObject);
    }
}