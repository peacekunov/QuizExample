using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameLoader : MonoBehaviour
{
    [SerializeField]
    private Questions _questions;

    [SerializeField]
    private PlayerState _playerState;

    [SerializeField]
    private UIManager _uiManager;

    private Questions _questions;

    [Inject]
    public void Constructor(Questions questions)
    {
        Debug.Log("GameLoader constructor");
        _questions = questions;
    }

    private void Awake()
    {
        Debug.Log("GameLoader Awake");
    }

    private void Start()
    {
        Debug.Log("GameLoader Start");
        LoadGame();
    }

    private async void LoadGame()
    {
        var playerStateLoading = _playerState.LoadData();
        var questionDataLoading = _questions.LoadData();

        await Task.WhenAll(playerStateLoading, questionDataLoading);

        _uiManager.ShowLevelScreen();

        Destroy(gameObject);
    }
}