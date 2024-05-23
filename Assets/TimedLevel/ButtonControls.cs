using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ButtonControls : MonoBehaviour
{
    public GameObject controlsMenu;

    public void Controls()
    {
        controlsMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Backbttn()
    {
        controlsMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("ShootingAreaGame");
    }
    public void MainMenuLoad()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Debug.Log("Game closed");
        Application.Quit();
    }
}
