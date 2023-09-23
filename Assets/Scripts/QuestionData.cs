using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class QuestionData
{
    public string question;
    public List<AnswersSet> sets = new List<AnswersSet>();

    public QuestionData(JsonQuestionModel jsonQuestionModel)
    {
        question = jsonQuestionModel.question;
        int id = 0;
        foreach(var set in jsonQuestionModel.answers)
        {
            sets.Add(new AnswersSet
            {
                id = id,
                answers = set.Values.ToArray()
            });
            id++;
        }
    }
}

[Serializable]
public class AnswersSet
{
    public int id;
    public string[] answers;
}
