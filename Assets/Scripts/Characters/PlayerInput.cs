using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	private Character _character;

	void Awake(){
		_character = gameObject.GetComponent<Character> ();
	}

	void Update(){
		if(InputManager.Instance.GetAButton()){
			_character.CallPart(Tags.MOVE_PART_A,100);
		}
		if(InputManager.Instance.GetAButton()){
			
		}
		if(InputManager.Instance.GetAButton()){
			
		}
		if(InputManager.Instance.GetAButton()){
			
		}
	}
}
