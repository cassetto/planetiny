using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using Facebook;
using Facebook.MiniJSON;
using System;


public class Parse_manager : MonoBehaviour {


	public RawImage raw;
	public Text prof;

	public void FBbutton(){
		FB.Init (SetInit, onHideUnity);
	}
	
	
	public void SetInit(){
		

		
		if (FB.IsLoggedIn)
		{
			
			Debug.Log("fb logged in");
			StartCoroutine (UserImage ());

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
			FB.API("/me?fields=id,first_name,name,friends.limit(100).fields(first_name,id)", Facebook.HttpMethod.GET, AuthCallBack);   

			return;         

		}  
		Debug.Log ("RESULT"+result.Text);

		FB.API("/me?fields=name", Facebook.HttpMethod.GET, LoginCallback2);

		Debug.Log ("auth except");

		StartCoroutine (UserImage ());

	}   

	void LoginCallback2(FBResult result)                                                                                              
	{                                                                                                                              
		
		IDictionary dict = Facebook.MiniJSON.Json.Deserialize(result.Text) as IDictionary;
		prof.text = dict["name"].ToString();
			
		}  
	
	IEnumerator UserImage()
	{
				
		var www = new WWW ("https" + "://graph.facebook.com/" + FB.UserId.ToString() + "/picture?type=large"); //+ "?access_token=" + FB.AccessToken);
		yield return www;
		
		Texture2D tempPic = new Texture2D (25, 25);
		www.LoadImageIntoTexture (tempPic);
		raw.texture = tempPic;
		
	}



	// Button for send a facebook feed message
	public void feedButtonClicked()                                                                                                 
	{                                                                                                                            
		                                                                                          
		FB.Feed(                                                                                                                 
		        //linkCaption: "I just smashed " + GameStateManager.Score.ToString() + " friends! Can you beat it?",               
		        picture: "http://www.friendsmash.com/images/logo_large.jpg",                                                     
		        linkName: "Checkout my Friend Smash greatness!",                                                                 
		        link: "http://apps.facebook.com/" + FB.AppId + "/?challenge_brag=" + (FB.IsLoggedIn ? FB.UserId : "guest")       
		        );                                                                                                               
	}  

	// Button for sending an invite game request
	public void RequestButton()                                                                                                 
	{                                                                                                                            

		if (FB.IsLoggedIn)                                                   
		{                                                                    
			                      
			onChallengeClicked() ;                                                   
		}  
	} 

	private void onChallengeClicked()                                                                                              
	{ 
		// OLD VERSION CODE //
		/* 
		FB.AppRequest(
			to: null,
			filters : "",
			excludeIds : null,
			message: "Friend Smash is smashing! Check it out.",
			title: "Play Friend Smash with me!",
			callback:appRequestCallback
			);                                                                                                                
			*/

		FB.AppRequest
			(
				"messaggio invito", // String message
				null, // List of ids to exclude
				null, // User Filter
				null, // Excluded Ids
				50, // Max invites
				"prova prova", // Data Text
				"gioca al mio gioco", // Invite title
				callback: appRequestCallback // callback method
				);
	}         

	public void appRequestCallback (FBResult result2)                                                                              
	{                                                                                                                              
		Debug.Log("appRequestCallback");                                                                                         
		if (result2 != null)                                                                                                        
		{                                                                                                                          
			var responseObject = Json.Deserialize(result2.Text) as Dictionary<string, object>;                                      
			object obj = 0;                                                                                                        
			if (responseObject.TryGetValue ("cancelled", out obj))                                                                 
			{                                                                                                                      
				Debug.Log("Request cancelled");                                                                                  
			}                                                                                                                      
			else if (responseObject.TryGetValue ("request", out obj))                                                              
			{                
				//AddPopupMessage("Request Sent", ChallengeDisplayTime);
				Debug.Log("Request sent"); 
				Debug.Log(result2);
			}                                                                                                                      
		}                                                                                                                          
	}    




}
