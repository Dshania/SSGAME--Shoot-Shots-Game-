using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CountDownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 30f;

    [SerializeField] TMP_Text countdownText;
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
       // print(currentTime);
       countdownText.text = currentTime.ToString("0");

        if (currentTime < 6 )
        {
            countdownText.color = Color.red;
        }

        if(currentTime <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
