using UnityEngine;
using System.Collections;
//using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
	public static InputManager Instance;

//	public List<Transform> Players = new List<Transform> ();

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
		Debug.Log ("A pressed");
		#if UNITY_WINDWOWS 
		return Input.GetKey (KeyCode.Joystick1Button0);
		#else
		return Input.GetKey (KeyCode.Joystick1Button16);
		#endif
	}

	public bool GetBButton ()
	{
		Debug.Log ("B pressed");
		#if UNITY_WINDWOWS 
		return Input.GetKey (KeyCode.Joystick1Button1);
		#else
		return Input.GetKey (KeyCode.Joystick1Button17);
		#endif
	}

	public bool GetXButton ()
	{
		Debug.Log ("X pressed");
		#if UNITY_WINDWOWS 
		return Input.GetKey (KeyCode.Joystick1Button2);
		#else
		return Input.GetKey (KeyCode.Joystick1Button18);
		#endif
	}

	public bool GetYButton ()
	{
		Debug.Log ("Y pressed");
		#if UNITY_WINDWOWS 
		return Input.GetKey (KeyCode.Joystick1Button3);
		#else
		return Input.GetKey (KeyCode.Joystick1Button19);
		#endif
	}


	public bool GetLeftBumberButton ()
	{
		#if UNITY_WINDWOWS 
		return Input.GetKey (KeyCode.Joystick1Button4);
		#else
		return Input.GetKey (KeyCode.Joystick1Button13);
		#endif
	}


	public bool GetRightBumberButton ()
	{
		#if UNITY_WINDWOWS 
		return Input.GetKey (KeyCode.Joystick1Button3);
		#else
		return Input.GetKey (KeyCode.Joystick1Button14);
		#endif
	}


	public bool GetAButtonDown ()
	{
		Debug.Log ("A pressed");
		#if UNITY_WINDWOWS 
		return Input.GetKey (KeyCode.Joystick1Button0);
		#else
		return Input.GetKey (KeyCode.Joystick1Button16);
		#endif
	}
	
	public bool GetBButtonDown ()
	{
		Debug.Log ("B pressed");
		#if UNITY_WINDWOWS 
		return Input.GetKeyDown (KeyCode.Joystick1Button1);
		#else
		return Input.GetKeyDown (KeyCode.Joystick1Button17);
		#endif
	}
	
	public bool GetXButtonDown ()
	{
		Debug.Log ("X pressed");
		#if UNITY_WINDWOWS 
		return Input.GetKeyDown (KeyCode.Joystick1Button2);
		#else
		return Input.GetKeyDown (KeyCode.Joystick1Button18);
		#endif
	}
	
	public bool GetYButtonDown ()
	{
		Debug.Log ("Y pressed");
		#if UNITY_WINDWOWS 
		return Input.GetKeyDown (KeyCode.Joystick1Button3);
		#else
		return Input.GetKeyDown (KeyCode.Joystick1Button19);
		#endif
	}
	
	
	public bool GetLeftBumberButtonDown ()
	{
		#if UNITY_WINDWOWS 
		return Input.GetKeyDown (KeyCode.Joystick1Button4);
		#else
		return Input.GetKeyDown (KeyCode.Joystick1Button13);
		#endif
	}
	
	
	public bool GetRightBumberButtonDown ()
	{
		#if UNITY_WINDWOWS 
		return Input.GetKeyDown (KeyCode.Joystick1Button3);
		#else
		return Input.GetKeyDown (KeyCode.Joystick1Button14);
		#endif
	}


	/*
	public bool GetLeftTriggerButton ()
	{
		#if UNITY_WINDWOWS 
		return Input.GetKey (KeyCode.Joystick1Button4);
		#else
		return Input.GetKey (KeyCode.Joystick1Button13);
		#endif
	}
	
	
	public bool GetRightTriggerButton ()
	{
		#if UNITY_WINDWOWS 
		return Input.GetKey (KeyCode.Joystick1Button3);
		#else
		return Input.GetKey (KeyCode.Joystick1Button14);
		#endif
	}
*/



	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
