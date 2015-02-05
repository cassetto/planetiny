using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Resume : MonoBehaviour {

	public int Level;
	public int Score;
	public int time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void ChangeToScene (int sceneToChangeTo) {
		if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) 
		{
			SaveLoad.saveandload.Load();
			Debug.Log(SaveLoad.saveandload.Level);
			Debug.Log(SaveLoad.saveandload.Score);
			Debug.Log(SaveLoad.saveandload.time);
			Application.LoadLevel (SaveLoad.saveandload.Level);


		}
	}


}
