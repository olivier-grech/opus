using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{

    [HideInInspector] public static ChoiceManager instance;

	public GameObject m_ChoiceButton;
    public GameObject m_ChoiceButtonsHolder;

    void Awake()
    {
        instance = this;
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	public void displayChoiceButtons(List<string> texts, List<object> lambdas)
    {
        for (int i = 0; i < texts.Count; i++)
        {
            GameObject choiceButton = Instantiate(m_ChoiceButton);
            choiceButton.transform.SetParent(m_ChoiceButtonsHolder.transform, false);

            Text choiceButtonText = choiceButton.GetComponentInChildren<Text>();
            choiceButtonText.text = texts[i];

        }

	}
}
