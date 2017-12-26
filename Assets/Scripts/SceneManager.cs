using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

	public static SceneManager instance;

	public Image m_BackgroundImage;
	public VNDictionnaryBackgrounds m_VNBackgroundsDictionnary;
	private Dictionary<string, Sprite> m_BackgroundsDictionnary;

	public Image m_CharacterImage;

	// Use this for initialization
	void Awake () {
		instance = this;

		// Load backgrounds dictionnary
		m_BackgroundsDictionnary = new Dictionary<string, Sprite>();
		foreach (VNDictionnaryBackgrounds.Backgrounds background in m_VNBackgroundsDictionnary.m_Backgrounds)
        {
            m_BackgroundsDictionnary.Add(background.name, background.sprite);
        }
	}

	// Lookup a background sprite in the background sprites dictionnary and display it as the background
	void changeBackgroundSprite(string backgroundName) {
		Sprite sprite = m_BackgroundsDictionnary[backgroundName];
		m_BackgroundImage.sprite = sprite;
	}

	// Lookup a background sprite in the background sprites dictionnary and display it as the background
	void changeCharacterSprite(string characterName) {

	}
	

}
