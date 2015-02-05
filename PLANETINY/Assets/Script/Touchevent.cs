using UnityEngine;
using System.Collections;

public class Touchevent : MonoBehaviour {

	public Vector2 deltaPosition;
	public bool isDrag;
	public Vector2 mycenterposition;
	public bool ismoving;


	Vector2 pos;

	// Use this for initialization
	void Start () {
		isDrag = true;
		ismoving = false;
	}
	
	// Update is called once per frame
	void Update () {

		// Check if the Object is in Camera, if it collide with the right ot left edge of the camera, destroy the object
		Vector3 checkPos = Camera.main.WorldToViewportPoint(transform.position);
		if ( (0f <= checkPos.x && checkPos.x <= 1F) && (0f <= checkPos.y && checkPos.y <= 1F) && (Camera.main.transform.position.z < this.transform.position.z) ) 
		{
			//target is in the camera!
		} 

		else if ( (0f > checkPos.x) ) 
		{
			if (isDrag == false)
			{
				Destroy (this.gameObject);
			}
		}

		else if ( (checkPos.x > 1F) ) {

			if (isDrag == false)
			{
				Destroy (this.gameObject);
			}
		} 

		else 
		{
			//target is NOT in the camera!
		}



	
	}
	void FixedUpdate() {
		Ontouchevent ();
		if (ismoving == true)
		{
			transform.position = Vector2.MoveTowards (transform.position, mycenterposition, 3 * Time.deltaTime);

		}
		if (transform.position.x == mycenterposition.x)
		{
			ismoving = false;
		}
	}


	public void Ontouchevent () {

	
	if(Input.touchCount > 0)
	{
		//Touch touch = Input.GetTouch(0);
		Vector2 deltaPosition = Input.GetTouch(0).position;
		
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
		
			//Vector2 touchPos = touch.position;
		switch(Input.GetTouch(0).phase)
		{
			case TouchPhase.Began:
				if (collider2D == Physics2D.OverlapPoint(touchPos))
				{
					Debug.Log("Began");
				}
			break;
			case TouchPhase.Moved:
				if (collider2D == Physics2D.OverlapPoint(touchPos))
				{
					MoveUpdate();
				}

				Debug.Log("Moved");
			break;
		case TouchPhase.Ended:
			Debug.Log("Ended");
			break;
		}
		
	}


	} 
	/*
	void DragObject(Vector2 touchPos){
		cachedTransform.position = new Vector2(
			//Mathf.Clamp((deltaPosition.x * dragSpeed) + cachedTransform.position.x, minX, maxX),
			//Mathf.Clamp((deltaPosition.y * dragSpeed) + cachedTransform.position.y, minY, maxY)
			Mathf.Clamp((touchPos.x * Time.deltaTime) + cachedTransform.position.x, minX, maxX),
			Mathf.Clamp((touchPos.y * Time.deltaTime) + cachedTransform.position.y, minY, maxY)
			);
	}
		*/
	void MoveUpdate()
	{
		pos = Camera.main.ScreenToWorldPoint(new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y));
		transform.position = new Vector2(pos.x, transform.position.y);
		if (collider2D.name == "Collider_SX")
		{
			gameObject.collider2D.enabled = false; 
			gameObject.rigidbody2D.gravityScale = 0;
			rigidbody2D.velocity = Vector3.left * 5;

		}

		/*
		if (pos.x > 5)
		{
			gameObject.rigidbody2D.gravityScale = 0;
			rigidbody2D.velocity = Vector3.right * 5;
			gameObject.collider2D.enabled = false; 

		}
		if (pos.x < 5)
		{
			gameObject.rigidbody2D.gravityScale = 0;
			rigidbody2D.velocity = Vector3.left * 5;
			gameObject.collider2D.enabled = false; 

		}
		*/
	}



	/// MOUSE CODE /// 

	void OnMouseDown()
	{

		mycenterposition = new Vector2(transform.position.x, transform.position.y);
		Vector2 cursorPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);


	}
	void OnMouseDrag()
	{
		if (isDrag == true)
		{
			Vector2 cursorPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = new Vector2(cursorPosition.x, transform.position.y);
		}

		if (isDrag == false)
		{
		}
	
	}


	void OnMouseUp()
	{
		if (isDrag == true)
		{
			ismoving = true;
		}
	}










	public void SaveDelete(){
		SaveLoad.saveandload.Delete ();
		Debug.Log ("save cancellato");
		}

}
