using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static Action OnAnswered;

    [SerializeField] private QuestionsLibrary questionsLibrary;

    public QuestionsLibrary QuestionsLibrary => questionsLibrary;

    private void Awake()
    {
        Instance = this;
        questionsLibrary.Init();
    }
}
