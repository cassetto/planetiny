using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//using UnityEditor;

public class SaveLoad : MonoBehaviour{

	public static SaveLoad saveandload;
	//public string SavePath;
	public int Level;
	public int Score;
	public int time;
	

	public void Awake () {

		if (saveandload == null)
		{
			DontDestroyOnLoad (gameObject);
			saveandload = this;
		} 
		else if (saveandload != this) 
		{
			Destroy(gameObject);
		}
		//SavePath = Application.persistentDataPath +"savedGames.gd";
	}



	

	public void Save() {

		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd");
		Game game = new  Game ();
		game.Level = Level;
		game.Score = Score;
		game.time = time;
		bf.Serialize(file, game);
		file.Close();

		if (File.Exists (Application.persistentDataPath + "/savedGames.gd")) 
		{
			Debug.Log(" SAVE COMPLETO");
		}
	}

	public void Load() {
		if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) 
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			Game game = (Game)bf.Deserialize(file);
			Level = game.Level;
			Score = game.Score;
			time = game.time;
			file.Close();
		}

	}

	public void Delete() {

		if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) 
		{
			File.Delete(Application.persistentDataPath + "/savedGames.gd");  
			//BinaryFormatter bf = new BinaryFormatter();

			//FileUtil.DeleteFileOrDirectory(Application.persistentDataPath + "/savedGames.gd");
		}


	}


	[System.Serializable]
	public class Game {
	
		public int Level;
		public int Score;
		public int time;

	}



}