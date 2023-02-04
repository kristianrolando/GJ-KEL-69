using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayBgm("main_menu_bgm");
    }
    public void StartButton(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void ButtonSfx()
    {
        AudioManager.Instance.PlaySfx("button_press");
    }
}
