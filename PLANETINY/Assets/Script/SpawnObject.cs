using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//using UnityEditor; 

public class SpawnObject : MonoBehaviour
{
		// VARIABLE FOR SPAWN
		public GameObject myObject;
		public Transform myObjPos;
		public List<GameObject> spawnPrefabs = new List<GameObject> ();
		// LEVEL INFO
		public float time_spawn_lv;
		public float time_spawn;
		public int time;
		public int Maxtime;
		public int Level;
		public int Score;
		public Text scoreText;
		public Text timeText;
		public RectTransform scorerect;
		public Text computerSpeech;


		public Image spawntime_image;
		public Collider_spawn myCollider_spawn;
		public GameObject my_Spawn_Collider_obj;

		public enum Phrases
		{
				speech0,
				speech1,
				speech2}
		;



		public void Awake ()
		{
				// if there is no Saveandload Object in the scene go to main menu
				if (SaveLoad.saveandload == null) {
						Application.LoadLevel ("MainMenu");
				} 

//		Canvas canvas = GetComponentInParent<Canvas> ();




		}

	
		// Use this for initialization
		void Start ()
		{
				// if a save exist, check the data
				if (File.Exists (Application.persistentDataPath + "/savedGames.gd")) {
						SaveLoad.saveandload.Load ();
						time = SaveLoad.saveandload.time;
						Score = SaveLoad.saveandload.Score;

				}
			// Start Level Countdown




			StartCoroutine (countdown ());


			time_spawn = time_spawn_lv;
			// Start Spawn Countdown
			StartCoroutine (SpawnCountdown ());

		}
	
		// Update is called once per frame
		void Update ()
		{
			//Update the time spawn image
		spawntime_image.fillAmount = time_spawn / time_spawn_lv;

				UpdateScore ();

				timeText.text = "" + time;
				// IF the game is in a level and press Exit, Save and turn to Main Menù
				if (Application.loadedLevelName != "MainMenu") {
						if (Input.GetKey (KeyCode.Escape)) {
				
								Application.LoadLevel ("MainMenu");
								SaveLoad.saveandload.Level = Level;
								SaveLoad.saveandload.time = time;
								SaveLoad.saveandload.Score = Score;
								SaveLoad.saveandload.Save ();
								return;
						}
				}

		}

		// Function to repeat the Spawn Countdown
		public void RepeactCountdown ()
		{
			if (time > 0)
			{
				StartCoroutine (SpawnCountdown ());
			}
				
		}
	
		IEnumerator SpawnCountdown ()
		{
				int prefabIndex = UnityEngine.Random.Range (0, spawnPrefabs.Count);
				//Instantiate (spawnPrefabs[prefabIndex], myObjPos.position, myObjPos.rotation);

				GameObject childObject = Instantiate (spawnPrefabs [prefabIndex], myObjPos.position, myObjPos.rotation) as GameObject;
				childObject.transform.parent = gameObject.transform;
				myObject = childObject;
				//ASSIGN A TAG IN THE CHILD OBJ EQUAL TO THE SPAWNTAG
		foreach(Transform t in myObject.transform)
		{
			t.gameObject.tag = gameObject.transform.tag;
		}
				
				while (time_spawn > 0) {
					time_spawn -= 1;
					yield return new WaitForSeconds (1);
			
				}
				while (time_spawn == 0) {
						if (myObject != null) 
						{
							my_Spawn_Collider_obj.collider2D.isTrigger = true;
				/*
							if (myObject.tag == "A") 
							{
								
								myObject.rigidbody2D.gravityScale = 1;

							}
							if (myObject.tag == "B") 
							{
								Destroy (myObject.gameObject);
							}
								*/
						} 
						else 
						{
							my_Spawn_Collider_obj.collider2D.isTrigger = true;
							
						}
						// RESET TIME SPAWN
						time_spawn = time_spawn_lv;
						yield return new WaitForSeconds (1);
						RepeactCountdown ();	
				}

		}
		/*
	
	IEnumerator Spawn_countdown(float waitTime)
	{
		while (time_spawn == time_spawn_lv)
		{
			time_spawn -= 1;
			int prefabIndex = UnityEngine.Random.Range(0,spawnPrefabs.Count);
			Instantiate (spawnPrefabs[prefabIndex], myObjPos.position, myObjPos.rotation);
			//yield return new WaitForSeconds(1);

		}

	}
		
*/

		IEnumerator countdown ()
		{
				while (time > 0) {
						time -= 1;
						yield return new WaitForSeconds (1);
						//SaveLoad.saveandload.time = time;
			
						//int prefabIndex = UnityEngine.Random.Range(0,spawnPrefabs.Count);
						//Instantiate (spawnPrefabs[prefabIndex], myObjPos.position, myObjPos.rotation);

				}

		}





		public void AddScore (int NewScoreValue)
		{
				Score += NewScoreValue;
				UpdateScore ();
			
		}

		public void DecreaseScore (int NewDScoreValue)
		{
				Score -= NewDScoreValue;
				UpdateScore ();
				//SaveLoad.saveandload.Score = Score;	
		}

		void UpdateScore ()
		{
				scoreText.text = "" + Score;
		}

		void speech0 ()
		{
				computerSpeech.text = ("sono vivo");
		}
	
		void speech1 ()
		{
				computerSpeech.text = ("sono morto");
		}

		void speech2 ()
		{
				computerSpeech.text = ("sono figo");
		}



	


}
