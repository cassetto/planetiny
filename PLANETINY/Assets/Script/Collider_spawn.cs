using UnityEngine;
using System.Collections;

public class Collider_spawn : MonoBehaviour {

	public Transform myChild;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// LET ACTIVE THE COLLIDER WHEN THE ITEM WITH THE SAME SPAWNTAG TRIGGERING
	void  OnTriggerEnter2D  (Collider2D other) 
		{
		if (transform.name =="ColliderpreSpawn3")
		{
			foreach (Transform tr in other.transform) 
			{ 
				if (tr.tag == "Spawn3")
				{
					myChild = transform.FindChild("ColliderSpawn3");
					myChild.collider2D.isTrigger = false;
				
				}
			}
		}

		if (transform.name =="ColliderpreSpawn2")
		{
			foreach (Transform tr in other.transform) 
			{ 
				if (tr.tag == "Spawn2")
				{
					myChild = transform.FindChild("ColliderSpawn2");
					myChild.collider2D.isTrigger = false;
					
				}
			}
		}


		if (transform.name =="ColliderpreSpawn")
		{
			foreach (Transform tr in other.transform) 
			{ 
				if (tr.tag == "Spawn")
				{
					myChild = transform.FindChild("ColliderSpawn");
					myChild.collider2D.isTrigger = false;
					
				}
			}
		}




	}

	void OnTriggerStay2D (Collider2D other) {
		
	}

	void OnTriggerExit2D (Collider2D other) {
		
	}

}
