using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxManager : MonoBehaviour
{
    public GameObject m_NamePlate;
    private Text m_NamePlateName;

    public GameObject m_TextBox;
    private Text m_TextBoxText;

    // Use this for initialization
    void Start()
    {
		m_NamePlateName = m_NamePlate.GetComponentInChildren<Text>();
		m_TextBoxText = m_TextBox.GetComponentInChildren<Text>();
    }

	void ChangeNamePlateName(string name)
	{
		m_NamePlateName.text = name;
	}
}
