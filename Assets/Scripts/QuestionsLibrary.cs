using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionsLibrary", menuName = "ScriptableObjects/QuestionsLibrary")]
public class QuestionsLibrary : ScriptableObject
{
    public TextAsset[] jsons;
    public List<QuestionData> questionDatas;


    public void Init()
    {
        questionDatas.Clear();

        foreach (TextAsset json in jsons)
        {
            try
            {
                JsonQuestionModel jsonQuestionModel = JsonConvert.DeserializeObject<JsonQuestionModel>(json.text);
                questionDatas.Add(new QuestionData(jsonQuestionModel));
            }
            catch(Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
    }

}

[Serializable]
public class JsonQuestionModel
{
    public string question;
    [JsonProperty("questionItemArray")] public Dictionary<string, string>[] answers;
}
