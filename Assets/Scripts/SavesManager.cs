using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SavesManager : Page
{

    [HideInInspector] public static SavesManager instance;

	// When you open the saves menu, you can either open it to save or load
    public enum SAVE_CONTEXT {SAVE, LOAD} 
	private SAVE_CONTEXT m_SaveContext;

	public GameObject m_ContextIndicator;
	public GameObject m_SavesFilesList;

	private Game m_GameToLoad;
    private static Game[] m_SavedGames;

    public override void Awake()
    {
        base.Awake();
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);  
        DontDestroyOnLoad(this);

        m_SavedGames = new Game[5];
		m_GameToLoad = null;
        
		// Read the saves files from disk or create them if not present
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            ReadSavesFromDisk();
        }
        else
        {
            for (int i = 0; i < m_SavedGames.Length; i++)
            {
                m_SavedGames[i] = new Game();
            }
        }

    }

	public void Load(int index)
    {
    	Game.current = m_SavedGames[index];
    }

	/* 
    public Game GetCurrentGame()
    {
        return m_GameToLoad;
    }
	*/

	public void DisplayPage(SAVE_CONTEXT saveContext)
    {
        
		m_SaveContext = saveContext;

		if (m_SaveContext == SAVE_CONTEXT.SAVE)
            m_ContextIndicator.GetComponent<Text>().text = "Save";
        else if (m_SaveContext == SAVE_CONTEXT.LOAD)
             m_ContextIndicator.GetComponent<Text>().text = "Load";

        Button[] _SavesFilesList = m_SavesFilesList.GetComponentsInChildren<Button>();

        // Assign the Save() or Load() function to each button according to the context
		for (int i = 0; i<_SavesFilesList.Length; i++)
        {
            int tmp = i;
			Button file = _SavesFilesList[i];
            UpdateFile(tmp);

            file.onClick.RemoveAllListeners();
           
		    if (m_SaveContext == SAVE_CONTEXT.SAVE)
            {
                file.onClick.AddListener(delegate
                {
                    SaveCurrentGame(tmp);
                    UpdateFile(tmp);
                });
            }
            else if (m_SaveContext == SAVE_CONTEXT.LOAD)
            {
                file.onClick.AddListener(delegate
                {
                    Load(tmp);
					TitleManager.instance.NewGame();
					HidePage();
                });
            }
           
        }
        base.DisplayPage();
    }




	// Update he button corresponding to a given save file
    // TODO: this is temporary, we should decide what to display on a save file
    private void UpdateFile(int index)
    {
        Button file = m_SavesFilesList.GetComponentsInChildren<Button>()[index];
        Text fileText = file.GetComponentInChildren<Text>();
        Game game = GetGameAtIndex(index);
		fileText.text = (game.fileName + " - " + game.nodeIndex);
    }

    public Game GetGameAtIndex(int index)
    {
        return m_SavedGames[index];
    }

    // Writes all saves files in a .gd file
    public static void WriteSavesToDisk()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, SavesManager.m_SavedGames);
        file.Close();
    }

    // Read all saves files from a .gd file
    public static void ReadSavesFromDisk()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
        m_SavedGames = (Game[])bf.Deserialize(file);
        file.Close();
    }

	public void SaveCurrentGame(int index)
	{
		Game gameToSave = new Game();
		gameToSave.nodeIndex = VisualNovelManager.instance.GetCurrentNodeIndex();
		gameToSave.fileName = VisualNovelManager.instance.GetCurrentDocumentName();
		Save(index, gameToSave);
	}

	// Save given game in target save file
    public void Save(int index, Game game)
    {
        // In C# object are copied by reference, so we're forced to create a new object here
        // TODO: use a copy constructor instead
        Game gameToSave = new Game();
        gameToSave.nodeIndex = game.nodeIndex;
		gameToSave.fileName = game.fileName;
		m_SavedGames[index] = gameToSave;
		WriteSavesToDisk();
    }



}
