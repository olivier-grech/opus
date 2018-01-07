using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BacklogManager : MonoBehaviour
{
	[HideInInspector] public static BacklogManager instance;


    public GameObject m_Backlog;
    public GameObject m_BacklogContent;

    public GameObject m_BacklogTextWrapperPrefab;

    private Queue<string> m_BacklogLines;
    public int m_MaxNumberOfLinesInBacklog = 10;

    void Awake()
    {
		instance = this;
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
        //Debug.Log(rt.rect.width);
        rt.rect.Set(x: rt.rect.x, y: rt.rect.y, width: rt.rect.width, height: height * m_BacklogLines.Count);
        //rt.sizeDelta = new Vector2(rt.rect.width, height * m_BacklogLines.Count);
        //Debug.Log(rt.rect.width);
    }

    public void DisplayBacklog()
    {
        ClearBacklog();
		GenerateBackLog();
        m_Backlog.SetActive(true);
    }

    public void HideBacklog()
    {
        m_Backlog.SetActive(false);
    }
}
