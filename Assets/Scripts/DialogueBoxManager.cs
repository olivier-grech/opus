using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxManager : MonoBehaviour
{
    [HideInInspector] public static DialogueBoxManager instance;

    public GameObject m_NamePlate;
    private Text m_NamePlateName;

    public GameObject m_TextBox;
    private Text m_TextBoxText;

    private bool m_TextIsScrolling;
    private Coroutine m_ScrollingTextCoroutine;
    private string m_CurrentLine;

    void Awake()
    {
        instance = this;

        m_TextIsScrolling = false;
    }

    // Use this for initialization
    void Start()
    {
        m_NamePlateName = m_NamePlate.GetComponentInChildren<Text>();
        m_TextBoxText = m_TextBox.GetComponentInChildren<Text>();
    }

    public void ChangeNamePlateName(string name)
    {
        m_NamePlateName.text = name;
    }

    public void DisplayNewLine(string line)
    {
        m_CurrentLine = line;
        m_ScrollingTextCoroutine = StartCoroutine(StartScrollingText());
    }

    private IEnumerator StartScrollingText()
    {
        float numberOfFramesBetweenLetters = 2.0f; // = m_SettingsManager.GetNumberOfFramesBetweenLetters();
        int numberOfLettersToDisplayAtOnce;

        if (numberOfFramesBetweenLetters == 0)
        {
            numberOfLettersToDisplayAtOnce = 0;
        }
        else if (numberOfFramesBetweenLetters < 1)
        {
            numberOfLettersToDisplayAtOnce = (int)(1.0f / numberOfFramesBetweenLetters);
        }
        else
        {
            numberOfLettersToDisplayAtOnce = 1;
        }

        m_TextIsScrolling = true;
        m_TextBoxText.text = "";

        char[] charArray = m_CurrentLine.ToCharArray();

        int i = 0;
        while (i < charArray.Length)
        {
            for (int j = 0; j < Mathf.Max(1, numberOfLettersToDisplayAtOnce); ++j)
            {
                if (i < charArray.Length)
                {
                    m_TextBoxText.text += charArray[i];
                }
                ++i;
            }

            if (numberOfLettersToDisplayAtOnce != 0)
            {
                for (int j = 0; j < Mathf.Max(1, numberOfFramesBetweenLetters); ++j)
                {
                    yield return new WaitForFixedUpdate();
                }
            }
        }

        m_TextIsScrolling = false;
        yield return null;
    }

    public bool IsTextScrolling()
    {
      return m_TextIsScrolling;
    }

    // If the text is still scrolling, instantly display the end of the line
    public void FinishDisplayingLine()
    {
        StopCoroutine(m_ScrollingTextCoroutine);
        m_TextIsScrolling = false;
        m_TextBoxText.text = m_CurrentLine;
    }
}
