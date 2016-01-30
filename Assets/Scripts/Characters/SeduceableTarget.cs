using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SeduceableTarget : MonoBehaviour {

	private Character _character;

	void Awake(){
		_character = gameObject.GetComponent<Character> ();
	}

	private void ChooseSeduction(int difficulty){
		//TODO Set seductionPrefs with random transforms seductions from the SequenceManager. The length == the dificulty
			
	}
	
}