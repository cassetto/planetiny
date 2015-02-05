using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

	public Scrollbar healthbar;
	public float maxHealth = 500;
	public float Health = 0;

	public void Start () {
		Health = 0;
		healthbar.size = 0;
	}
	// Update is called once per frame

	//}

	public void Update () {
		if ((Health == 0) || (Health < 0))
		{
			Health = 0;
		}
		if ((Health == maxHealth) || (Health > maxHealth))
		{
			Debug.Log ("hai vinto");
		}


		healthbar.size = Health / maxHealth;
		 

	}





}
