using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [HideInInspector]
    public static TitleManager instance;

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

	public void NewGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
	}

    public void Load()
    {
        SavesManager.instance.DisplayPage(SavesManager.SAVE_CONTEXT.LOAD);
    }

    public void Settings()
    {
        SettingsManager.instance.DisplayPage();
    }

	public void Quit()
	{
		Application.Quit();
	}
}
