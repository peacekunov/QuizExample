using UnityEngine;

public abstract class TileModel : MonoBehaviour
{
    [SerializeField]
    protected int _id;

    [SerializeField]
    protected TilePresenter[] _neighbours;

    protected LevelMapTileState _state;

    public int Id => _id;

    public event System.Action<LevelMapTileState> StateChanged;

    public LevelMapTileState State
    {
        get => _state;
        set
        {
            _state = value;
            StateChanged?.Invoke(_state);
        }
    }

    public void UnblockNeighbours()
    {
        foreach (var neighbor in _neighbours)
        {
            neighbor.Unblock();
        }
    }

    public abstract void Launch();
}
