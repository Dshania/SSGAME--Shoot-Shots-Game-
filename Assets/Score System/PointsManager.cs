using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public static int points;
    public GameObject scoreManager;

    private void Start()
    {
        PlayerPrefs.SetString("Score: ", "0");
    }
    void Update()
    {
        scoreManager.GetComponent<TMP_Text>().text = "Points: " + points;
        PlayerPrefs.SetString("Score: ", points.ToString());
    }

    /*public static PointsManager Instance;

    public TMP_Text pointsText;
    int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        pointsText.text = score.ToString() + "Points: ";
    }

    public void AddPoint(int points)
    {
        score += points;
        pointsText.text = score.ToString() + "Points: ";
    }*/
}
