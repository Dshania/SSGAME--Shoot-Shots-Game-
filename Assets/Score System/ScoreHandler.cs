using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public GameObject currentScore;
    private TMP_Text currentScoreText;

    void Start()
    {
        currentScoreText = currentScore.GetComponent<TMP_Text>();
        currentScoreText.text = PlayerPrefs.GetString("Score: ");
    }

}
