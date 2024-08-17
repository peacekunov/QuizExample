using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;

    [SerializeField]
    private Text _text;

    [SerializeField]
    private Image _rect;

    [SerializeField]
    private Color _rightColor;

    [SerializeField]
    private Color _wrongColor;

    public string Text
    {
        get => _text.text;
        set => _text.text = value;
    }

    public void Init(int index, System.Action<int> clickAction)
    {
        _button.onClick.AddListener(() => clickAction?.Invoke(index));
    }

    public void SetRightColor()
    {
        _rect.color = _rightColor;
    }

    public void SetWrongColor()
    {
        _rect.color = _wrongColor;
    }
}
