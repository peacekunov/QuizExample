using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameLoader : MonoBehaviour
{
    private PlayerState _playerState;

    private Questions _questions;

    private Level.Factory _levelFactory;

    [Inject]
    public void Constructor(PlayerState playerState, Questions questions, Level.Factory levelFactory)
    {
        _playerState = playerState;
        _questions = questions;
        _levelFactory = levelFactory;
    }

    private void Start()
    {
        LoadGame();
    }

    private async void LoadGame()
    {
        var playerStateLoading = _playerState.LoadData();
        var questionDataLoading = _questions.LoadData();

        await Task.WhenAll(playerStateLoading, questionDataLoading);

        _levelFactory.Create();

        Destroy(gameObject);
    }
}