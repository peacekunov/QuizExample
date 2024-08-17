using System.Collections.Generic;
using UnityEngine;

public class LevelMap : MonoBehaviour
{
    [SerializeField]
    private PlayerState _playerState;

    private Dictionary<int, TilePresenter> _tiles;

    private void Awake()
    {
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

    public void CompleteTile(int id)
    {
        _tiles[id].Complete();
    }
}