using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

	public static SceneManager instance;

	public Image m_BackgroundSprite;

	public Image m_CharacterSprite;

	// Use this for initialization
	void Awake () {
		instance = this;
	}

	// Lookup a background sprite in the background sprites dictionnary and display it as the background
	void changeBackgroundSprite(string spriteName) {

	}

	// Lookup a background sprite in the background sprites dictionnary and display it as the background
	void changeCharacterSprite(string spriteName) {

	}
	

}
