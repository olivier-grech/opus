using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Olivier Grech
 * This class provides methods binded to the user buttons
 */

public class UserButtonsManager : MonoBehaviour
{
    public void Save()
    {
        SavesManager.instance.DisplayPage(SavesManager.SAVE_CONTEXT.SAVE);
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }
}
