using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    [HideInInspector] public static SettingsManager instance;

    public GameObject m_Canvas;

    public enum TEXT_SPEED {VERY_SLOW, SLOW, NORMAL, FAST, VERY_FAST, INSTANT}

    // Objects reflecting the value of the settings
    public GameObject m_TextSpeed;
    private Slider m_TextSpeedSlider;
    private Text m_TextSpeedValue;

    // The value of the settings themselves
    private float m_NumberOfFramesBetweenLetters;
    private string m_TextSpeedName;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        
        m_TextSpeedSlider = m_TextSpeed.GetComponentInChildren<Slider>();
        m_TextSpeedValue = m_TextSpeed.GetComponentInChildren<Text>();
    }

    // Use this for initialization
    void Start()
    {
        // Text scrolling speed
        m_TextSpeedSlider.onValueChanged.AddListener(delegate
        {
            TextSpeedChanged();
        });
        m_TextSpeedSlider.value = PlayerPrefs.GetInt("SettingScrollingTextSpeed", 1);
    }

       // Display the settings page
    public void DisplayPage()
    {
        m_Canvas.SetActive(true);
    }

    // Hide the settings page as well as the extra menu
    public void HidePage()
    {
        m_Canvas.SetActive(false);
        // TODO: hide the extra menu
    }

    // A listener for the text scrolling speed slider
    public void TextSpeedChanged()
    {
        SetTextSpeed((SettingsManager.TEXT_SPEED)m_TextSpeedSlider.value);
        m_TextSpeedValue.text = GetTextSpeedName();
    }

    public void SetTextSpeed (TEXT_SPEED textSpeed)
	{
		switch (textSpeed) {
		case TEXT_SPEED.VERY_SLOW:
			m_NumberOfFramesBetweenLetters = 4f;
			m_TextSpeedName = "Very slow";
			break;
		case TEXT_SPEED.SLOW:
			m_NumberOfFramesBetweenLetters = 2f;
			m_TextSpeedName = "Slow";
			break;
		case TEXT_SPEED.NORMAL:
			m_NumberOfFramesBetweenLetters = 1f;
			m_TextSpeedName = "Normal";
			break;
		case TEXT_SPEED.FAST:
			m_NumberOfFramesBetweenLetters = 0.5f;
			m_TextSpeedName = "Fast";
			break;
		case TEXT_SPEED.VERY_FAST:
			m_NumberOfFramesBetweenLetters = 0.25f;
			m_TextSpeedName = "Very fast";
			break;
		case TEXT_SPEED.INSTANT:
			m_NumberOfFramesBetweenLetters = 0f;
			m_TextSpeedName = "Instant";
			break;
		}

        PlayerPrefs.SetInt("SettingScrollingTextSpeed", (int)textSpeed);
    }

    public string GetTextSpeedName()
    {
        return m_TextSpeedName;
    }

    public float GetNumberOfFramesBetweenLetters()
    {
        return m_NumberOfFramesBetweenLetters;
    }
}
