using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SeduceableTarget : MonoBehaviour {

	private Character _character;
	[SerializeField]private Character _targetCharacter;
	private SeduceList _seduceList;
	private int _seducePatternIndex = 0;

	private int _timesSeduces = 0;
	private int _timesIncorrectGuess = 0;
	private int _timesTolorateIncorrect = 2;

	private bool _listeningToSeduction = false;

	private float _timeIdle = 0;

	void Start(){
		_character = gameObject.GetComponent<Character> ();
		_seduceList = gameObject.GetComponent<SeduceList> ();
		_targetCharacter.DidMove += CheckCorrectMove;
		ChooseSeduction (); //Difficulty has no fucntion yet..
		StartCoroutine(WaitForListen (3));
	}
	void Update(){
		if (Input.anyKey) {
			_timeIdle = 0;
		}
		_timeIdle += Time.deltaTime;
		if (_timeIdle > 5) {
			if(_listeningToSeduction){
				PlayReversedAnimation();
			}
		}
	}
	private void ChooseSeduction(bool playRev = false){
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
		if (playRev) {
			PlayReversedAnimation ();
		}
	}

	private void PlayReversedAnimation (){
		for (int i = 0; i < _seduceList.allPartsNeedMoving.Count; i++) {
			_character.CallPart(_seduceList.allPartsNeedMoving[i]);
			_character.SetMouth(_seduceList.wantedSoundIndex);
		}
		if (_seduceList.allPartsNeedMoving.Count == 0) {
			_character.SetMouth(_seduceList.wantedSoundIndex);
		}
		_timeIdle = 0;
	}

	private void CheckCorrectMove(){
		if (_listeningToSeduction) {
			if (_seduceList.CheckIfMatch (_targetCharacter)) {
				_timesSeduces ++;
				_listeningToSeduction = false;
				PlayReversedAnimation();
				ChooseSeduction ();
				ShowLove ();
			} else {
				_timesIncorrectGuess++;
				if (_timesIncorrectGuess == _timesTolorateIncorrect) {
					PlayReversedAnimation ();
					_timesIncorrectGuess = 0;
					_timesTolorateIncorrect = Random.Range (3, 6);
				}
			}
		}
	}
	IEnumerator WaitForListen(int seconds = 1){

		yield return new WaitForSeconds (seconds);
		PlayReversedAnimation ();
		_listeningToSeduction = true;
	}
	private void ShowLove(){
		//TODO heart above head and show new pattern after x seconds.
		Instantiate (Resources.Load<GameObject> ("Prefabs/Heart"), new Vector3 (), Quaternion.identity);
		StartCoroutine(WaitForListen (2));
	}
}