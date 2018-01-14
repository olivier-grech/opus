using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Olivier Grech
 * This class provides methods binded to the buttons of the extra menu
 */

public class ExtraMenuManager : MonoBehaviour
{
    public GameObject m_ExtraMenu;

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

    public void DisplayExtraMenu()
    {
        m_ExtraMenu.SetActive(true);
    }

    public void HideExtraMenu()
    {
        m_ExtraMenu.SetActive(false);
    }
}
