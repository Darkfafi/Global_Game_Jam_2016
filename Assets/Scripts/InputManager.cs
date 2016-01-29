using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{

	public static InputManager Instance;

//public List<Transform> 

	void Awake ()
	{

		if (Instance != null) {
			Instance = this;
		} else {
			Debug.Log ("Input manager instance already exists");
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
