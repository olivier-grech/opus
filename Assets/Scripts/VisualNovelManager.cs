using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class VisualNovelManager : MonoBehaviour
{
    [HideInInspector] public static VisualNovelManager instance;

    // Used to navigate through a XML document
    public string m_StartingXmlDocumentName;
    private XmlDocument m_CurrentXmlDocument;
    private XmlNode m_CurrentNode;
    private int m_CurrentNodeIndex;

    void Awake()
    {
        instance = this;
        m_CurrentXmlDocument = new XmlDocument();
    }

    // Use this for initialization
    void Start()
    {
        // Check if a save exist
        if (false)
        {

        }
        else
        {
            Load(m_StartingXmlDocumentName, 1);
        }

        ReadNode(firstTime: true);
    }

    // Go to the given node in the given document
    void Load(string documentName, int nodeIndex)
    {
        m_CurrentXmlDocument.LoadXml((Resources.Load(documentName) as TextAsset).text);
        m_CurrentNodeIndex = nodeIndex;
    }

    // Read the next node in the current XML document
    public void Next()
    {
        if (DialogueBoxManager.instance.IsTextScrolling())
        {
            DialogueBoxManager.instance.FinishDisplayingLine();
        }
        else
        {
            ++m_CurrentNodeIndex;
            ReadNode();
        }
    }

    // Read the current node in the current document
    void ReadNode(bool firstTime = false)
    {
        string XPath = "/dialogue/*[" + m_CurrentNodeIndex + "]";
        m_CurrentNode = m_CurrentXmlDocument.SelectSingleNode(XPath);
        XmlNode tempNode = m_CurrentNode;



        switch (tempNode.Name)
        {
            // Basic line
            case "line":
                // Change character sprite and name
                if (firstTime)
                {
                    while (tempNode.Attributes["character"] == null)
                    {
                        tempNode = tempNode.PreviousSibling;
                    }
                }

                if (tempNode.Attributes["character"] != null)
                {
                    string characterName = tempNode.Attributes["character"].InnerText;
                    SceneManager.instance.changeCharacterSprite(characterName);
                    DialogueBoxManager.instance.ChangeNamePlateName(characterName);
                }

                tempNode = m_CurrentNode;

                // Change background
                if (firstTime)
                {
                    while (tempNode.Attributes["background"] == null)
                    {
                        tempNode = tempNode.PreviousSibling;
                    }
                }

                if (tempNode.Attributes["background"] != null)
                {
                    string backgroundName = tempNode.Attributes["background"].InnerText;
                    SceneManager.instance.changeBackgroundSprite(backgroundName);
                }

                tempNode = m_CurrentNode;

                DialogueBoxManager.instance.DisplayNewLine(tempNode.InnerText);


                // Todo: display dialogue
                break;
            case "choices":
                List<string> texts = new List<string>();
                List<UnityEngine.Events.UnityAction> lambdas = new List<UnityEngine.Events.UnityAction>();
               
                foreach (XmlNode choiceNode in m_CurrentNode.ChildNodes)
                {
                    texts.Add(choiceNode.InnerText);

                    UnityEngine.Events.UnityAction lambda = delegate 
                    {
                        Load(choiceNode.Attributes["file"].InnerText, 1);
                        ReadNode();
                    };
                    lambdas.Add(lambda);
                }

                ChoiceManager.instance.displayChoiceButtons(texts, lambdas);
                break;
            default:
                break;

        }
    }


}

