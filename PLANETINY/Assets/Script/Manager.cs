using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {





	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		exitandsave ();
	}


	public void exitandsave(){
		// if the scene is not the Main Menu, go to it and save !
		if (Application.loadedLevelName != "MainMenu")
		{
			if (Input.GetKey(KeyCode.Escape))
			{

				Application.LoadLevel("MainMenu");
				SaveLoad.saveandload.Save();
				return;
			}
			if (Input.GetKey(KeyCode.Menu))
			{
				
				Application.LoadLevel("MainMenu");
				SaveLoad.saveandload.Save();
				return;
			}
			if (Input.GetKey(KeyCode.Home))
			{
				
				Application.LoadLevel("MainMenu");
				SaveLoad.saveandload.Save();
				return;
			}

		}
	}



}
