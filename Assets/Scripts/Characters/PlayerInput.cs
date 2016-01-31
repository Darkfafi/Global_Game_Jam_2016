using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{

	private Character _character;
	void Awake ()
	{
		_character = gameObject.GetComponent<Character> ();
	}

	void Update ()
	{

#if UNITY_WINDOWS

		if (Input.GetKeyDown (KeyCode.Q) || Input.GetKeyDown (KeyCode.JoystickButton0)) {
			_character.SetMouth (1);
		}
		
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.JoystickButton1)) {
			_character.SetMouth (2);
		}
		
		if (Input.GetKeyDown (KeyCode.E) || Input.GetKeyDown (KeyCode.JoystickButton2)) {
			_character.SetMouth (3);
		}
		
		if (Input.GetKeyDown (KeyCode.R) || Input.GetKeyDown (KeyCode.JoystickButton3)) {
			_character.SetMouth (4);
		}
		
		if (Input.GetKeyDown (KeyCode.O) || Input.GetKeyDown (KeyCode.JoystickButton4)) {
			Debug.Log ("right arm animation");
			_character.CallPart (Tags.MOVE_PART_A);
		}
		
		if (Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown (KeyCode.JoystickButton5)) {
			Debug.Log ("right arm animation");
			_character.CallPart (Tags.MOVE_PART_B);
		}
		Debug.Log (Input.GetAxis ("RightTriggerWin"));
		if (Input.GetKeyDown (KeyCode.K) || Input.GetKeyDown (KeyCode.JoystickButton6)) {
			Debug.Log ("right arm animation");
			_character.CallPart (Tags.MOVE_PART_C);
		}
		
		if (Input.GetKeyDown (KeyCode.L) || Input.GetKeyDown (KeyCode.JoystickButton7)) {
			Debug.Log ("right arm animation");
			_character.CallPart (Tags.MOVE_PART_D);
		}
	
#else
		if (Input.GetKeyDown (KeyCode.Q) || Input.GetKeyDown (KeyCode.JoystickButton16)) {
			_character.SetMouth (1);
		}
	
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.JoystickButton17)) {
			_character.SetMouth (2);
		}
	
		if (Input.GetKeyDown (KeyCode.E) || Input.GetKeyDown (KeyCode.JoystickButton18)) {
			_character.SetMouth (3);
		}
	
		if (Input.GetKeyDown (KeyCode.R) || Input.GetKeyDown (KeyCode.JoystickButton19)) {
			_character.SetMouth (4);
		}
	
		if (Input.GetKeyDown (KeyCode.O) || Input.GetKeyDown (KeyCode.JoystickButton13)) {
			Debug.Log ("right arm animation");
			_character.CallPart (Tags.MOVE_PART_A);
		}
	
		if (Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown (KeyCode.JoystickButton14)) {
			Debug.Log ("right arm animation");
			_character.CallPart (Tags.MOVE_PART_B);
		}
		Debug.Log (Input.GetAxis ("RightTriggerWin"));
		if (Input.GetKeyDown (KeyCode.K) || Input.GetKeyDown (KeyCode.JoystickButton10)) {
			Debug.Log ("right arm animation");
			_character.CallPart (Tags.MOVE_PART_C);
		}
	
		if (Input.GetKeyDown (KeyCode.L) || Input.GetKeyDown (KeyCode.JoystickButton9)) {
			Debug.Log ("right arm animation");
			_character.CallPart (Tags.MOVE_PART_D);
		}

#endif


	}
}