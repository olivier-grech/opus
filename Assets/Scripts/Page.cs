using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/* Author: Olivier Grech
 * This class is used to provides basic functions for the settings page, the saves page, etc.
 */
public class Page : MonoBehaviour
{
    public GameObject m_Canvas;
    protected List<GameObject> m_ObjectsToHide;

    public virtual void Awake()
    {
        m_ObjectsToHide = new List<GameObject>();
    }

    public virtual void DisplayPage()
    { 
    	m_Canvas.SetActive(true);
        foreach (GameObject objectToHide in GameObject.FindGameObjectsWithTag("ToHide"))
        {
            m_ObjectsToHide.Add(objectToHide);
            objectToHide.SetActive(false);
        }
     
    }

    public void HidePage()
    {
        m_Canvas.SetActive(false);
        foreach (GameObject objectToHide in m_ObjectsToHide)
        {
            objectToHide.SetActive(true);
        }
        m_ObjectsToHide.Clear();
    }

	
    



}
