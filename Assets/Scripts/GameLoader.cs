using System.Threading.Tasks;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField]
    private PlayerState _playerState;

    private void Start()
    {
        LoadGame();
    }

    private async void LoadGame()
    {
        var playerStateLoading = _playerState.LoadData();
        var questionDataLoading = Questions.Instance.LoadData();

        await Task.WhenAll(playerStateLoading, questionDataLoading);

        UIManager.Instance.ShowLevelScreen();
    }
}