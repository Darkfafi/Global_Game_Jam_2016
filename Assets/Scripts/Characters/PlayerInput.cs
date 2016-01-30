using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	private Character _character;

	void Awake(){
		_character = gameObject.GetComponent<Character> ();
	}

	void Update(){
		/*
		if(Input.GetKey (KeyCode.JoystickButton0)){
			_character.CallPart(Tags.MOVE_PART_A);
		}
		if(Input.GetKey (KeyCode.JoystickButton1)){
			_character.CallPart(Tags.MOVE_PART_B);
		}
		if(Input.GetKey (KeyCode.JoystickButton2)){
			_character.CallPart(Tags.MOVE_PART_C);
		}
		if(Input.GetKey (KeyCode.JoystickButton3)){
			_character.CallPart(Tags.MOVE_PART_D);
		}*/
		if (Input.GetKeyDown (KeyCode.Q) || Input.GetKey (KeyCode.JoystickButton0)) {
			_character.SetMouth (1);
		}
		
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKey (KeyCode.JoystickButton1)) {
			_character.SetMouth (2);
		}
		
		if (Input.GetKeyDown (KeyCode.E) || Input.GetKey (KeyCode.JoystickButton2)) {
			_character.SetMouth (3);
		}
		
		if (Input.GetKeyDown (KeyCode.R) || Input.GetKey (KeyCode.JoystickButton3)) {
			_character.SetMouth (4);
		}
		
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.JoystickButton5)) {
			Debug.Log ("right arm animation");
			_character.CallPart(Tags.MOVE_PART_A);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.JoystickButton4)) {
			Debug.Log ("right arm animation");
			_character.CallPart(Tags.MOVE_PART_B);
		}
		Debug.Log (Input.GetAxis ("RightTriggerWin"));
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.JoystickButton6)) {
			Debug.Log ("right arm animation");
			_character.CallPart(Tags.MOVE_PART_C);
			//	RightFoot.GetComponent<Animation> ().Play ();
		}
		
		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey(KeyCode.JoystickButton7)) {
			Debug.Log ("right arm animation");
			_character.CallPart(Tags.MOVE_PART_D);
		}
	}

}
