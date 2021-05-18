using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public Text scoreTxt;

    private int score;

    public static UnityEvent<int> ChangeScoreEvt = new UnityEvent<int>();

    private void Start()
    {
        ChangeScoreEvt.AddListener(ChangeScore);
    }

    public static void AddScore(int value)
    {
        ChangeScoreEvt.Invoke(value);
    }

    public void ChangeScore(int value)
    {
        score += value;
        scoreTxt.text = score.ToString();
    }
}
