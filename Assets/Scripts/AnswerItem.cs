using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnswerItem : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image backgroud;

    private int id;
    private Color defaultColor;
    private float glowDuration = 0.5f;
    public int Id => id;

    private void Start()
    {
        defaultColor = backgroud.color;
    }

    public void Init(string answer, int id)
    {
        this.id = id;
        text.text = answer;
    }

    public void Glow(Color color)
    {
        backgroud.DOColor(color, glowDuration).OnComplete(() => backgroud.DOColor(defaultColor, glowDuration));
    }
}
