using UnityEngine;
using System.Collections;

/* Author: Olivier Grech
 * This class is used to manage the state of a game. It can be serialized in order to be saved on the disk.
 */

[System.Serializable]
public class Game 
{ 
	// A static instance representing the current game
	public static Game current;

    public int nodeIndex;
    public string fileName;

	public Game () 
	{
        this.nodeIndex = 1;
        this.fileName = "file1";
	}

	public void Pretty(string message) 
	{
		Debug.Log (message + " - " + "file " + this.fileName + " line " + this.nodeIndex);
	}

}