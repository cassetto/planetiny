using UnityEngine;
using System.Collections;

public class Collider_border : MonoBehaviour {

	public Touchevent myTouchEvent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Check if the collider is left or right and disable the object collider, set gravity to 0 and increase velocity 
	void  OnTriggerEnter2D  (Collider2D other) 
	{
		if (transform.name =="Collider_SX")  
		{
			myTouchEvent = other.GetComponent<Touchevent>();
			myTouchEvent.isDrag = false;
			other.collider2D.enabled = false;
			other.rigidbody2D.gravityScale = 0;
			other.rigidbody2D.velocity = Vector3.left * 5;
			 


		}
		if (transform.name =="Collider_DX")
		{

			myTouchEvent = other.GetComponent<Touchevent>();;
			myTouchEvent.isDrag = false;
			other.collider2D.enabled = false;
			other.rigidbody2D.gravityScale = 0;
			other.rigidbody2D.velocity = Vector3.right * 5;

			
		}
		
	}
	
	void OnTriggerStay2D (Collider2D other) {
		
	}
	
	void OnTriggerExit2D (Collider2D other) {


		
	}

}
