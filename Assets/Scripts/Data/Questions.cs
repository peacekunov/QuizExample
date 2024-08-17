using System.Collections.Generic;
using System.Linq;

public class Questions : Singleton<Questions>
{
    private DataProvider _dataProvider;

    private QuestionDto[] _questions;

    public IEnumerable<QuestionDto> All => _questions;

    public int Count => _questions.Length;

    protected override void Awake()
    {
        base.Awake();
        _dataProvider = new FileDataProvider(Constants.QUESTION_DATA_FILE_PATH);
        LoadData();
    }

    public void LoadData()
    {
        _questions = _dataProvider.GetQuestions();
    }

    public QuestionDto GetById(int id)
    {
        return _questions.SingleOrDefault(q => q.id == id);
    }
}