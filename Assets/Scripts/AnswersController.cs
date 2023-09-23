using DanielLochner.Assets.SimpleScrollSnap;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class AnswersController : MonoBehaviour
{
    [SerializeField] private TMP_Text question;
    [SerializeField] private SimpleScrollSnap[] scrollSnaps;
    [SerializeField] private AnswerItem answerItemPrefab;

    private QuestionData QuestionData => QuestionsLibrary.questionDatas[0];
    private QuestionsLibrary QuestionsLibrary => GameManager.Instance.QuestionsLibrary;

    public void Start()
    {
        if (QuestionsLibrary.questionDatas.Count == 0) return;

        InitScrolls();
        GameManager.OnAnswered += Answer;
    }

    private void InitScrolls()
    {
        question.text = QuestionData.question;

        for (int i = 0; i < scrollSnaps.Length; i++)
        {
            List<AnswerItem> answerItems = new List<AnswerItem>();

            foreach (var set in QuestionData.sets)
            {
                if (i >= set.answers.Length) break;

                AnswerItem duplicateAnswer = answerItems.Find(x => x.Answer == set.answers[i]);
                if (duplicateAnswer != null)
                {
                    duplicateAnswer.AddId(set.id);
                }
                else
                {
                    AnswerItem item = Instantiate(answerItemPrefab);
                    item.Init(set.answers[i], set.id);
                    answerItems.Add(item);
                }
            }

            Random rand = new Random();
            var shuffledItems = answerItems.OrderBy(_ => rand.Next()).ToList();

            foreach (var shuffledItem in shuffledItems)
            {
                scrollSnaps[i].AddToBack(shuffledItem.gameObject, false);
            }
        }

        foreach (var snap in scrollSnaps)
        {
            snap.ShuffleItems();
        }
    }

    private void Answer()
    {
        AnswerItem[] items = scrollSnaps.Select(x => x.Panels[x.SelectedPanel].gameObject.GetComponent<AnswerItem>()).ToArray();

        bool rightAnswer = items.All(x => x.Ids.Intersect(items[0].Ids).Any());

        foreach (var item in items)
        {
            item.Glow(rightAnswer ? Color.green : Color.red);
        }
    }

    private void OnDestroy()
    {
        GameManager.OnAnswered -= Answer;
    }
}
