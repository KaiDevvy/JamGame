using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginScreenController : MonoBehaviour
{
    public Button loginButton;

    public static void QuitGame()
    {
#if !UNITY_EDITOR
        Application.Quit();
#endif
    }

    public static void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene+1);
    }

    public void CheckIsInputValid(string value)
    {
        loginButton.interactable = !string.IsNullOrEmpty(value);
    }
}
