[System.Serializable]
public class QuestionDto
{
    public int id;

    public string title;

    public QuestionCategory category;

    public AnswerDto[] answers;
}
