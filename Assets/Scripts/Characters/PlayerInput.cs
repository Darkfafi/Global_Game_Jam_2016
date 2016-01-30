using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	private Character _character;

	void Awake(){
		_character = gameObject.GetComponent<Character> ();
	}

	void Update(){
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
		}
	}
}
