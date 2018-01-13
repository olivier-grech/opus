using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [HideInInspector] public static SceneManager instance;

    public Image m_BackgroundImage;
    public VNDictionnaryBackgrounds m_VNBackgroundsDictionnary;
    private Dictionary<string, Sprite> m_BackgroundsDictionnary;

    public Image m_CharacterImage;
    public VNDictionnaryCharacters m_VNCharactersDictionnary;
    private Dictionary<string, Sprite[]> m_CharactersDictionnary;

    // Use this for initialization
    void Awake()
    {
        instance = this;

        // Load backgrounds dictionnary into a "real" dictionnary
        m_BackgroundsDictionnary = new Dictionary<string, Sprite>();
        foreach (VNDictionnaryBackgrounds.Backgrounds background in m_VNBackgroundsDictionnary.m_Backgrounds)
        {
            m_BackgroundsDictionnary.Add(background.name, background.sprite);
        }

        // Load characters dictionnary into a "real" dictionnary
        m_CharactersDictionnary = new Dictionary<string, Sprite[]>();
        foreach (VNDictionnaryCharacters.Characters character in m_VNCharactersDictionnary.m_Characters)
        {
            m_CharactersDictionnary.Add(character.name, character.sprites);
        }
    }

    // Lookup a background sprite in the background sprites dictionnary and display it as the current background
    public void changeBackgroundSprite(string backgroundName)
    {
        Sprite sprite = m_BackgroundsDictionnary[backgroundName];
        m_BackgroundImage.sprite = sprite;
    }

    // Lookup a character sprite in the character sprites dictionnary and display it as the current character
    public void changeCharacterSprite(string characterName, int mood = 0)
    {
        Sprite sprite = m_CharactersDictionnary[characterName][mood];
        m_CharacterImage.sprite = sprite;
    }


}
