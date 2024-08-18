using System.Collections.Generic;
using UnityEngine;

public class LevelMap : MonoBehaviour
{
    private PlayerState _playerState;

    private Dictionary<int, TilePresenter> _tiles;

    private void Awake()
    {
        _playerState = GameObject.FindWithTag(Constants.PLAYER_STATE_TAG).GetComponent<PlayerState>();

        _tiles = new Dictionary<int, TilePresenter>();
        foreach (var tileGameObject in GameObject.FindGameObjectsWithTag(Constants.LEVEL_MAP_TILE_TAG))
        {
            var tileModel = tileGameObject.GetComponent<TileModel>();
            _tiles.Add(tileModel.Id, tileGameObject.GetComponent<TilePresenter>());
        }
    }

    private void OnEnable()
    {
        _playerState.StepCompleted += CompleteTile;
    }

    private void OnDisable()
    {
        _playerState.StepCompleted -= CompleteTile;
    }

    private void Start()
    {
        if (_playerState.HasLevelData)
        {
            LoadLevelData();
        }
        else
        {
            CreateLevelData();
        }
    }

    private void CreateLevelData()
    {
        var steps = new List<LevelStepData>();
        foreach (var tile in _tiles)
        {
            tile.Value.SetDefaultState();
            steps.Add(new LevelStepData { Id = tile.Key });
        }

        _playerState.SetLevelStaps(steps.ToArray());
        _playerState.SaveData();
    }

    private void LoadLevelData()
    {
        foreach (var tile in _tiles)
        {
            if (_playerState.IsStepCompleted(tile.Key))
            {
                CompleteTile(tile.Key);
            }
        }
    }

    public void CompleteTile(int id)
    {
        if (_tiles.ContainsKey(id))
        {
            _tiles[id].Complete();
        }
    }
}