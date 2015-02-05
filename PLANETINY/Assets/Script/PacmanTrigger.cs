using UnityEngine;
using System.Collections;


public  class PacmanTrigger : MonoBehaviour {


	public static PacmanTrigger current;

	public GameObject myObject;
	public Healthbar myHealthbar;

	public int scoreValue;
	public SpawnObject spawnobject;

	public GameObject Pacmanobject;
	// Use this for initialization
	void Start () {

		myHealthbar = myObject.GetComponent<Healthbar>();
		GameObject Pacmanobject = GameObject.FindWithTag("pacman");
		if (Pacmanobject != null)
		    {
			spawnobject = Pacmanobject.GetComponent<SpawnObject>();
			}

			

	}
	
	// Update is called once per frame
	void Update () {

		//if (Application.platform == RuntimePlatform.Android)
		//{


		//}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "A") 
		{
			Destroy (other.gameObject); 
			myHealthbar.Health += 10;
			//spawnobject.AddScore (scoreValue);

		}
		if (other.gameObject.tag == "B") 
		{
			Destroy (other.gameObject); 
			if (myHealthbar.Health == 0){
				Debug.Log("GAME OVER");
				Time.timeScale =0;

			}
			if ((myHealthbar.Health > 0) && (myHealthbar.Health < 10))
			{
				Debug.Log("GAME OVER2");
				
			}
			myHealthbar.Health -= 10;
			//spawnobject.DecreaseScore (scoreValue);
			
		}

	}



}
