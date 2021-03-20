using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text TriesText;

    public void UpdateScore(int score)
    {
        ScoreText.text = score.ToString();
    }

    public void UpdateTries(int tries)
    {
        TriesText.text = tries.ToString();
    }
}
