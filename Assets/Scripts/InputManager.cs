using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
	public static InputManager Instance;

	public List<Transform> Players = new List<Transform> ();

	void Awake ()
	{
		if (Instance != null) {
			Debug.Log ("Input manager instance already exists");
		} else {
			Instance = this;

		}
	}


	public bool GetAButton ()
	{
		#if UNITY_WINDWOWS || UNITY_EDITOR
		return Input.GetKey (KeyCode.Joystick1Button0);
		#endif
			
		#if UNITY_EDITOR_OSX ||  UNITY_STANDALONE_OSX
		return Input.GetKey (KeyCode.Joystick1Button16);
		#endif
	}

	public bool GetBButton ()
	{
		#if UNITY_WINDWOWS || UNITY_EDITOR
		return Input.GetKey (KeyCode.Joystick1Button1);
		#endif
			
		#if UNITY_EDITOR_OSX ||  UNITY_STANDALONE_OSX
		return Input.GetKey (KeyCode.Joystick1Button17);
		#endif
	}


	public bool GetXButton ()
	{
		#if UNITY_WINDWOWS || UNITY_EDITOR
		return Input.GetKey (KeyCode.Joystick1Button2);
		#endif
			
		#if UNITY_EDITOR_OSX ||  UNITY_STANDALONE_OSX
		return Input.GetKey (KeyCode.Joystick1Button18);
		#endif
	}


	public bool GetYButton ()
	{
		#if UNITY_WINDWOWS || UNITY_EDITOR
		return Input.GetKey (KeyCode.Joystick1Button3);
		#endif
		
		#if UNITY_EDITOR_OSX ||  UNITY_STANDALONE_OSX
		return Input.GetKey (KeyCode.Joystick1Button19);
		#endif
	}

	/*
	public float GetLeftBumberButton ()
	{
		#if UNITY_WINDWOWS || UNITY_EDITOR
		return Input.GetKey (KeyCode.Joystick1Button4);
		#endif
		
		#if UNITY_EDITOR_OSX ||  UNITY_STANDALONE_OSX
		return Input.GetKey (KeyCode.Joystick1Button13);
		#endif
	}


	public float GetRightBumberButton ()
	{
		#if UNITY_WINDWOWS || UNITY_EDITOR
		return Input.GetAxis(
		#endif
		
		#if UNITY_EDITOR_OSX ||  UNITY_STANDALONE_OSX
		return Input.GetKey (KeyCode.Joystick1Button14);
		#endif
	}
*/


	void Update ()
	{
	
		if (Input.GetAxis ("Horizontal") > .1f || Input.GetAxis ("Horizontal") < -.1f) {
			Debug.Log ("test x: " + Input.GetAxis ("Horizontal"));
		}

		if (Input.GetAxis ("Vertical") > .1f || Input.GetAxis ("Vertical") < -.1f) {
			Debug.Log ("test y: " + Input.GetAxis ("Vertical"));
		}








	}
}
