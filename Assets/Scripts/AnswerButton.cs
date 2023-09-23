using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    public void Answer()
    {
        GameManager.OnAnswered?.Invoke();
    }
}
