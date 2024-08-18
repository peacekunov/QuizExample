using UnityEngine;

public class TilePresenter : MonoBehaviour
{
    [SerializeField]
    private bool _availableOnInit;

    private TileModel _model;

    private TileView _view;

    private void Awake()
    {
        _model = GetComponent<TileModel>();
        _view = GetComponent<TileView>();

        if (_availableOnInit)
        {
            _model.State = LevelMapTileState.Available;
        }
        else
        {
            _model.State = LevelMapTileState.Blocked;
        }
    }

    private void OnEnable()
    {
        _model.StateChanged += SetViewStyle;
    }

    private void OnDisable()
    {
        _model.StateChanged -= SetViewStyle;
    }

    public void Unblock()
    {
        if (_model.State == LevelMapTileState.Blocked)
        {
            _model.State = LevelMapTileState.Available;
        }
    }

    public void Launch()
    {
        if (_model.State == LevelMapTileState.Available)
        {
            _model.Launch();
        }
    }

    public void Complete()
    {
        _model.State = LevelMapTileState.Completed;
        _model.UnblockNeighbours();
    }

    private void SetViewStyle(LevelMapTileState state)
    {
        switch (state)
        {
            case LevelMapTileState.Blocked:
                _view.SetBlockedStyle();
                break;

            case LevelMapTileState.Available:
                _view.SetAvailableStyle();
                break;

            case LevelMapTileState.Completed:
                _view.SetCompletedStyle();
                break;
        }
    }
}