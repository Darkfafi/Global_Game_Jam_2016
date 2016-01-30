using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SeduceableTarget : MonoBehaviour {

	private Character _character;
	[SerializeField]private Character _targetCharacter;
	private SeduceList _seduceList;
	private int _seducePatternIndex = 0;

	void Start(){
		_character = gameObject.GetComponent<Character> ();
		_seduceList = gameObject.GetComponent<SeduceList> ();
		_targetCharacter.DidMove += CheckCorrectMove;
		ChooseSeduction (42); //Difficulty has no fucntion yet..
	}

	private void ChooseSeduction(int difficulty){
		int index = Random.Range (0, PatternLibrary.TOTAL_PATTERNS);
		if (index == _seducePatternIndex) {
			if(_seducePatternIndex < PatternLibrary.TOTAL_PATTERNS - 1){
				index++;
			}else{
				index = Random.Range(0,PatternLibrary.TOTAL_PATTERNS - 1);
			}
		}
		_seducePatternIndex = index;
		_seduceList.SetList (PatternLibrary.GetPatternByIndex (index));

		PlayReversedAnimation ();
	}

	private void PlayReversedAnimation (){
		for (int i = 0; i < _seduceList.allPartsNeedMoving.Count; i++) {
			_character.CallPart(_seduceList.GetReversedMovement(_seduceList.allPartsNeedMoving[i]));
			_character.SetMouth(_seduceList.GetReversedAudio(_seduceList.wantedSoundIndex));
		}
	}

	private void CheckCorrectMove(){
		if (_seduceList.CheckIfMatch (_targetCharacter)) {
			Debug.Log ("LOVVEE");
		} else {
			Debug.Log("No Love..");
		}
	}
}