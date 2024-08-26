using UnityEngine;
using Zenject;

public class Question : MonoBehaviour
{
    [SerializeField]
    private QuestionPresenter _presenter;

    private int _id;

    [Inject]
    public void Constructor(int id)
    {
        _id = id;
    }

    private void Start()
    {
        _presenter.ShowQuestion(_id);
    }

    public class Factory : PlaceholderFactory<int, Question> { }
}