using DanielLochner.Assets.SimpleScrollSnap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

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
        GameManager.OnAnswered += Answered;
    }

    private void InitScrolls()
    {
        question.text = QuestionData.question;
        foreach (var set in QuestionData.sets)
        {
            for (int i = 0; i < scrollSnaps.Length && i < QuestionData.sets.Count; i++)
            {
                AnswerItem item = Instantiate(answerItemPrefab);
                item.Init(set.answers[i], set.id);
                scrollSnaps[i].AddToBack(item.gameObject, false);
            }
        }

        foreach (var snap in scrollSnaps)
        {
            snap.ShuffleItems();
        }
    }

    private void Answered()
    {
        AnswerItem[] items = scrollSnaps.Select(x => x.Panels[x.SelectedPanel].gameObject.GetComponent<AnswerItem>()).ToArray();

        bool rightAnswer = items.All(x => x.Id == items[0].Id);

        foreach (var item in items)
        {
            item.Glow(rightAnswer ? Color.green : Color.red);
        }
    }

    private void OnDestroy()
    {
        GameManager.OnAnswered -= Answered;
    }
}
