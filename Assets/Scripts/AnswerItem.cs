using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnswerItem : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image backgroud;

    private List<int> ids = new List<int>();
    private Color defaultColor;
    private float glowDuration = 0.5f;
    private string answer;

    public List<int> Ids => ids;
    public string Answer => answer;

    private void Start()
    {
        defaultColor = backgroud.color;
    }

    public void Init(string answer, int id)
    {
        AddId(id);
        this.answer = answer;
        text.text = answer;
    }

    public void AddId(int id)
    {
        ids.Add(id);
    }

    public void Glow(Color color)
    {
        backgroud.DOColor(color, glowDuration).OnComplete(() => backgroud.DOColor(defaultColor, glowDuration));
    }
}
