using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BacklogManager : Page
{
    [HideInInspector] public static BacklogManager instance;

    public GameObject m_BacklogContent;

    public GameObject m_BacklogTextWrapperPrefab;

    private Queue<string> m_BacklogLines;
    public int m_MaxNumberOfLinesInBacklog = 10;

    public override void Awake()
    {
        base.Awake();
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(this);

        m_BacklogLines = new Queue<string>();
    }

    public void AddLineToBackLog(string line)
    {
        m_BacklogLines.Enqueue(line);
        if (m_BacklogLines.Count > m_MaxNumberOfLinesInBacklog)
        {
            m_BacklogLines.Dequeue();
        }
    }

    void ClearBacklog()
    {
        foreach (Transform child in m_BacklogContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    void GenerateBackLog()
    {
        foreach (string line in m_BacklogLines)
        {
            var textWrapper = GameObject.Instantiate(m_BacklogTextWrapperPrefab);
            textWrapper.GetComponentInChildren<Text>().text = line;
            textWrapper.transform.SetParent(m_BacklogContent.transform);
        }

        // Set the overall height
        float height = m_BacklogTextWrapperPrefab.GetComponent<RectTransform>().rect.height;
        RectTransform rt = m_BacklogContent.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(0, height * m_BacklogLines.Count);
    }

    public override void DisplayPage()
    {
        ClearBacklog();
        GenerateBackLog();
        base.DisplayPage();
    }
}
