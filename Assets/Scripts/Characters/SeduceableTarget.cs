﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeduceableTarget : MonoBehaviour
{

	private Character _character;
	[SerializeField]
	private Character
		_targetCharacter;

	[SerializeField]
	private Transform
		_timerTransform;

	[SerializeField]
	private Transform
		_heartAnimation0;
	[SerializeField]
	private Transform
		_heartAnimation1;
	[SerializeField]
	private Transform
		_heartAnimation2;



	[SerializeField]
	private Transform
		_loveFX;

	[SerializeField]
	private Transform
		_fadeToBlack;

	[SerializeField]
	private AudioClip
		_endCharacterSounds;
	[SerializeField]
	private MoviePlayerSystem
		_climaxMoviePlayer;

	private Transform movie;

	public int baseDificulty = 0;
	public float currentDifficulty = 0;

	private SeduceList _seduceList;
	private int _seducePatternIndex = 0;

	private int _timesSeducesInRow = 0;
	private int _timesTimerDownInRow = 0;

	private int _timesIncorrectGuess = 0;
	private int _timesTolorateIncorrect = 2;

	private bool _listeningToSeduction = false;

	private float _timeIdle = 0;

	private int _position = 0;

	void Start ()
	{
		_character = gameObject.GetComponent<Character> ();
		_seduceList = gameObject.GetComponent<SeduceList> ();
		_targetCharacter.DidMove += CheckCorrectMove;
		ChooseSeduction (); //Difficulty has no fucntion yet..
		StartCoroutine (WaitForListen (3));
		currentDifficulty = baseDificulty;
		_timerTransform.GetComponent<Timer> ().TimerEnd += LoseTimerEnd;
	}

	void Update ()
	{
		if (Input.anyKey) {
			_timeIdle = 0;
		}
		_timeIdle += Time.deltaTime;
		if (_timeIdle > 2f) {
			if (_listeningToSeduction) {
				PlayReversedAnimation ();
			}
		}
	}

	private void ChooseSeduction (bool playRev = false)
	{
		int index = Random.Range (0, PatternLibrary.TOTAL_PATTERNS);
		if (index == _seducePatternIndex) {
			if (_seducePatternIndex < PatternLibrary.TOTAL_PATTERNS - 1) {
				index++;
			} else {
				index = Random.Range (0, PatternLibrary.TOTAL_PATTERNS - 1);
			}
		}
		_seducePatternIndex = index;
		_seduceList.SetList (PatternLibrary.GetPatternByIndex (index, Mathf.RoundToInt (currentDifficulty)));
		if (playRev) {
			PlayReversedAnimation ();
		}
	}

	private void PlayReversedAnimation ()
	{
		if (!_character.GetComponent<AudioSource> ().isPlaying) {
			for (int i = 0; i < _seduceList.allPartsNeedMoving.Count; i++) {
				_character.CallPart (_seduceList.allPartsNeedMoving [i]);
				_character.SetMouth (_seduceList.wantedSoundIndex);
			}

			if (_seduceList.allPartsNeedMoving.Count == 0) {
				_character.SetMouth (_seduceList.wantedSoundIndex);
			}
		}

		_timeIdle = 0;
	}

	private void CheckCorrectMove ()
	{
		if (_listeningToSeduction) {
			if (_seduceList.CheckIfMatch (_targetCharacter)) {
				_listeningToSeduction = false;
				_timerTransform.gameObject.SetActive (false);
				WinCondition ();
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

	IEnumerator WaitForListen (int seconds = 1)
	{

		yield return new WaitForSeconds (seconds);
		PlayReversedAnimation ();
		_listeningToSeduction = true;
		_timerTransform.gameObject.SetActive (true);
	}

	private void LoseTimerEnd ()
	{
		_timerTransform.gameObject.SetActive (false);
		LoseCondition ();
	}

	private void WinCondition ()
	{
		_timesSeducesInRow++;
		_timesTimerDownInRow = 0;
		if (currentDifficulty < 2) {
			currentDifficulty += 0.5f;
		}
		_timerTransform.GetComponent<Timer> ().Reset ();
		_listeningToSeduction = false;
		PlayReversedAnimation ();
		ChooseSeduction ();
		ShowLove ();
		if (_position == 4) {
			_loveFX.gameObject.SetActive (true);
			Invoke ("FadeToBlack", 4);
			Invoke ("WinClimax", 6);
		} else {
			StartCoroutine (WaitForListen (2));
		}
	}
	/*
	private void CreateEndMovie(){
		MoviePlayerSystem playerSys;
		GameObject movieObj = new GameObject("Movie");
		movieObj.transform.position = new Vector3 (0, 0, -4);
		playerSys = movieObj.AddComponent<MoviePlayerSystem> ();
		playerSys.movieFolder = _climaxMovieFolder;
		playerSys.PlayMovie ();
	}*/



	private void FadeToBlack ()
	{
		GetComponent<AudioSource> ().clip = _endCharacterSounds;
		GetComponent<AudioSource> ().Play ();

		_fadeToBlack.gameObject.SetActive (true);
	}

	private void WinClimax ()
	{
		Debug.Log ("Win"); //TODO Show WIN effect and go back to menu.
		LevelManager.Instance.SetMated (LevelManager.Instance.GetCurrentLevel (), LevelManager.Instance.totalLevels, true);
		_climaxMoviePlayer.PlayMovie (7);
		//Application.LoadLevel ("StartMenu");
		MusicMother.Instance.PlayTheme ();
	}



	private void LoseCondition ()
	{
		_timesTimerDownInRow++;
		_timesSeducesInRow = 0;
		if (currentDifficulty > baseDificulty) {
			currentDifficulty -= 0.5f;
		}
		_listeningToSeduction = false;
		ChooseSeduction ();
		ShowHate ();
		if (_position == -4) {
			Debug.Log ("End"); //TODO Show LOSE effect and go back to menu.
			LevelManager.Instance.SetMated (LevelManager.Instance.GetCurrentLevel (), LevelManager.Instance.totalLevels, false);
			Application.LoadLevel ("StartMenu");
		} else {
			StartCoroutine (WaitForListen (2));
		}
	}

	private void ShowLove ()
	{
		_character.MoveToDirection (-1);
		_targetCharacter.MoveToDirection (1);
		_position++;
		Instantiate (Resources.Load<GameObject> ("Prefabs/Heart"), new Vector3 (0, 0, -1), Quaternion.identity);
		//Invoke ("HeartAnimation", 1);
		if (_position == 1) {
			_heartAnimation0.gameObject.SetActive (true);
		} else if (_position == 2) {
			_heartAnimation1.gameObject.SetActive (true);
		} else if (_position == 3) {
			_heartAnimation2.gameObject.SetActive (true);
		}
	}

	private void ShowHate ()
	{
		_character.MoveToDirection (1);
		_targetCharacter.MoveToDirection (-1);
		_position--;
		Instantiate (Resources.Load<GameObject> ("Prefabs/Wrong"), new Vector3 (0, 0, -1), Quaternion.identity);
		if (_position == 0) {
			_heartAnimation0.gameObject.SetActive (false);
		} else if (_position == 1) {
			_heartAnimation1.gameObject.SetActive (false);
		} else if (_position == 2) {
			_heartAnimation2.gameObject.SetActive (false);
		}
	}
}