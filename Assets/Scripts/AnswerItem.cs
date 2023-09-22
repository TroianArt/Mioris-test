using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerItem : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private int id;

    public int Id => id;

    public void Init(string answer, int id)
    {
        this.id = id;
        text.text = answer;
    }
}
