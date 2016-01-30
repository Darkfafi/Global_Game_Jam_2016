using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SeduceableTarget : MonoBehaviour
{

	private Character _character;
<<<<<<< HEAD
	[SerializeField]
	private Character _targetCharacter;
	[SerializeField]
	private Transform _timerTransform;
=======
	[SerializeField]private Character _targetCharacter;

	public int baseDificulty = 0;
	public int currentDifficulty = 0;

>>>>>>> 7daa87f4b187d5d9b9ed0e3088c2b80737768862
	private SeduceList _seduceList;
	private int _seducePatternIndex = 0;

	private int _timesSeduces = 0;
	private int _timesIncorrectGuess = 0;
	private int _timesTolorateIncorrect = 2;

	private bool _listeningToSeduction = false;

<<<<<<< HEAD
	void Start ()
	{
=======
	private float _timeIdle = 0;

	void Start(){
>>>>>>> 7daa87f4b187d5d9b9ed0e3088c2b80737768862
		_character = gameObject.GetComponent<Character> ();
		_seduceList = gameObject.GetComponent<SeduceList> ();
		_targetCharacter.DidMove += CheckCorrectMove;
		ChooseSeduction (); //Difficulty has no fucntion yet..
<<<<<<< HEAD
		StartCoroutine (WaitForListen (3));
	}

	private void ChooseSeduction (bool playRev = false)
	{
=======
		StartCoroutine(WaitForListen (3));
		currentDifficulty = baseDificulty;
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
>>>>>>> 7daa87f4b187d5d9b9ed0e3088c2b80737768862
		int index = Random.Range (0, PatternLibrary.TOTAL_PATTERNS);
		if (index == _seducePatternIndex) {
			if (_seducePatternIndex < PatternLibrary.TOTAL_PATTERNS - 1) {
				index++;
			} else {
				index = Random.Range (0, PatternLibrary.TOTAL_PATTERNS - 1);
			}
		}
		_seducePatternIndex = index;
		_seduceList.SetList (PatternLibrary.GetPatternByIndex (index,currentDifficulty));
		if (playRev) {
			PlayReversedAnimation ();
		}
	}

	private void PlayReversedAnimation ()
	{
		for (int i = 0; i < _seduceList.allPartsNeedMoving.Count; i++) {
<<<<<<< HEAD
			_character.CallPart (_seduceList.allPartsNeedMoving [i]);
			_character.SetMouth (_seduceList.GetReversedAudio (_seduceList.wantedSoundIndex));
=======
			_character.CallPart(_seduceList.allPartsNeedMoving[i]);
			_character.SetMouth(_seduceList.wantedSoundIndex);
>>>>>>> 7daa87f4b187d5d9b9ed0e3088c2b80737768862
		}
		if (_seduceList.allPartsNeedMoving.Count == 0) {
			_character.SetMouth(_seduceList.wantedSoundIndex);
		}
		_timeIdle = 0;
	}

<<<<<<< HEAD
	private void CheckCorrectMove ()
	{
		if (_seduceList.CheckIfMatch (_targetCharacter)) {
			_timesSeduces ++;
			_listeningToSeduction = false;
			_timerTransform.gameObject.SetActive (false);
			ChooseSeduction ();
			ShowLove ();
		} else {
			_timesIncorrectGuess++;
			if (_timesIncorrectGuess == _timesTolorateIncorrect) {
				PlayReversedAnimation ();
				_timesIncorrectGuess = 0;
				_timesTolorateIncorrect = Random.Range (3, 6);
=======
	private void CheckCorrectMove(){
		if (_listeningToSeduction) {
			if (_seduceList.CheckIfMatch (_targetCharacter)) {
				_timesSeduces ++;
				if(currentDifficulty < 2){
					currentDifficulty ++;
				}
				_listeningToSeduction = false;
				PlayReversedAnimation();
				ChooseSeduction ();
				_character.MoveToDirection(-1);
				_targetCharacter.MoveToDirection(1);
				ShowLove ();
			} else {
				_timesIncorrectGuess++;
				if (_timesIncorrectGuess == _timesTolorateIncorrect) {
					PlayReversedAnimation ();
					_timesIncorrectGuess = 0;
					_timesTolorateIncorrect = Random.Range (3, 6);
				}
>>>>>>> 7daa87f4b187d5d9b9ed0e3088c2b80737768862
			}
		}
	}
	IEnumerator WaitForListen (int seconds = 1)
	{

		yield return new WaitForSeconds (seconds);
		PlayReversedAnimation ();
		_listeningToSeduction = true;
		_timerTransform.gameObject.SetActive (true);
	}
	private void ShowLove ()
	{
		//TODO heart above head and show new pattern after x seconds.
<<<<<<< HEAD
		Instantiate (Resources.Load<GameObject> ("Prefabs/Heart"), new Vector3 (), Quaternion.identity);
		StartCoroutine (WaitForListen (3));
=======
		Instantiate (Resources.Load<GameObject> ("Prefabs/Heart"), new Vector3 (0,0,-1), Quaternion.identity);
		StartCoroutine(WaitForListen (2));
>>>>>>> 7daa87f4b187d5d9b9ed0e3088c2b80737768862
	}
}