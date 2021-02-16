using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    const string MAX_SCORE = "MAX_SCORE";

    public int GetRanking()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE);
        return maxScore;
    }

    public void SetRanking(int value)
    {
        PlayerPrefs.SetInt(MAX_SCORE, value);
    }
}
