using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private QuestionsLib questionsLib;

    public QuestionsLib QuestionsLib => questionsLib;

    void Awake()
    {
        questionsLib.Init();
    }
}
