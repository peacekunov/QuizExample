using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionCategoryStyles", menuName = "Styles/QuestionCategoryStyles", order = 1)]
public class QuestionCategoryStyleList : ScriptableObject
{
    [SerializeField]
    private QuestionCategoryStyle[] _questionsStyles;

    public QuestionCategoryStyle GetStyle(QuestionCategory category)
    {
        return _questionsStyles.SingleOrDefault(c => c.Category == category);
    }
}