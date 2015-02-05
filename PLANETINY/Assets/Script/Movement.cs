using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	public float movementSpeed = 0.5f;
	public int obj_spawn_time;
	// Use this for initialization
	void Awake () {

	}


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);

		if (Input.touchCount == 1)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (collider2D == Physics2D.OverlapPoint(touchPos))
			{
				Destroy (this.gameObject);
			}
		}
	}

	/*
	void OnMouseDown(){
		// this object was clicked - do something
		Destroy (this.gameObject);
	}
	*/


}
