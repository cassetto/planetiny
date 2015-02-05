using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using Facebook;
using Facebook.MiniJSON;
using System;


public class MainManager : MonoBehaviour {

	public GameObject Resume;
	public Button button;
	public CanvasGroup cg;
	public Texture2D UserImg;
	public GameObject profilePic;
	public RawImage raw;



	public static MainManager gameManager;



	//[SerializeField]
	//private Button MyButton = null; // assign in the editor




	/*
	void Awake () {

		if (gameManager == null) 
		{
			DontDestroyOnLoad (gameObject);
			gameManager = this;
		} 
		else if (gameManager != this) 
		{
			Destroy(gameObject);
		}


	}
	*/
	void Awake () {

		//FB.Init (FBbutton, onHideUnity);
		
	}


	// Use this for initialization
	void Start () {

		cg = cg.GetComponent<CanvasGroup> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "MainMenu")
		{
			if (File.Exists (Application.persistentDataPath + "/savedGames.gd")) 
			{
				cg.alpha = 1;
			}
			else 
			{
				cg.alpha = 0;
			}

		}

	}


	public void QuitGame(){
		Application.Quit ();
		Debug.Log ("quit");
	}


	public void FBbutton(){
		FB.Init (SetInit, onHideUnity);
		// Initialize FB SDK     
		//MyButton.onClick.AddListener(() => { SetInit(); }); 
		    

	}
	
	
	public void SetInit(){

		FBlogin();

		if (FB.IsLoggedIn)
		{

			Debug.Log("fb logged in");
			
			
		} 
		else 
		{
			Debug.Log("effettua login");
			FBlogin();
		}

		
	}
	
	
	private void onHideUnity(bool isGameShown){
		if (!isGameShown)
		{
			Time.timeScale = 0;
		}
		else 
		{
			Time.timeScale = 1;
		}
		
		
	}
	
	
	public void FBlogin(){
		//FB.Login("user_about_me, user_birthday", AuthCallBack);
		FB.Login("user_about_me, email, publish_actions", AuthCallBack);           
	}


	 void AuthCallBack(FBResult result)                                                                                              
	{                                                                                                                              
		     
		if (result.Error != null)                                                                                                  
		{                                                                                                                          
                                                                                       
			// Let's just try again                                                                                                
			FB.API("/me?fields=id,first_name,friends.limit(100).fields(first_name,id)", Facebook.HttpMethod.GET, AuthCallBack);     
			return;                                                                                                                
		}  
		Debug.Log ("auth except");
		StartCoroutine (UserImage ());
		/*
		WWW url = new WWW("https" + "://graph.facebook.com/" + FB.UserId.ToString() + "/picture?type=large");
		Texture2D textFb2 = new Texture2D(128, 128, TextureFormat.DXT1, false); //TextureFormat must be DXT5
		yield return url;
		url.LoadImageIntoTexture(textFb2);
		UserImg = textFb2;
    	*/






	}                                                                                                                              
	
         

                                                                                       
	
	//void OnLoggedIn()                                                                          
	//{                                                                                          
		// Reqest player info and profile picture                                                                           
		//FB.API("/me?fields=id,first_name,friends.limit(100).fields(first_name,id)", Facebook.HttpMethod.GET, APICallback);  
		//LoadPicture(Util.GetPictureURL("me", 128, 128),MyPictureCallback);                                    
	//}                      

	IEnumerator UserImage()
	{
		/*
		WWW url = new WWW("https" + "://graph.facebook.com/" + FB.UserId.ToString() + "/picture?type=large"); //+ "?access_token=" + FB.AccessToken);
		
		Texture2D textFb2 = new Texture2D(128, 128, TextureFormat.DXT1, false); //TextureFormat must be DXT5
		
		yield return url;
		profilePic.renderer.material.mainTexture = textFb2;
		//profilePic.renderer.material = textFb2;
		url.LoadImageIntoTexture(textFb2);
		Debug.Log("Working"); 
		*/

		var www = new WWW ("https" + "://graph.facebook.com/" + FB.UserId.ToString() + "/picture?type=large"); //+ "?access_token=" + FB.AccessToken);
		yield return www;
		
		Texture2D tempPic = new Texture2D (25, 25);
		www.LoadImageIntoTexture (tempPic);
		raw.texture = tempPic;

	}
	
	
	
	
}




