using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "QuestionsLib", menuName = "ScriptableObjects/QuestionsLib")]
public class QuestionsLib : ScriptableObject
{
    public TextAsset[] jsons;
    public List<QuestionData> questionDatas;


    public void Init()
    {
        questionDatas.Clear();

        foreach (TextAsset json in jsons)
        {
            JsonQuestionModel jsonQuestionModel = JsonConvert.DeserializeObject<JsonQuestionModel>(json.text);
            questionDatas.Add(new QuestionData(jsonQuestionModel));
        }
    }

}

[Serializable]
public class JsonQuestionModel
{
    public string question;
    [JsonProperty("questionItemArray")] public Dictionary<string, string>[] answers;
}
