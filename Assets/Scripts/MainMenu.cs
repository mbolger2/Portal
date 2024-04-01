using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject instructionsMenu;
    [SerializeField] GameObject mainMenu;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Play()
    {
        SceneManager.LoadScene("Map1");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Map1");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void OpenInstructionMenu()
    {
        instructionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        instructionsMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
