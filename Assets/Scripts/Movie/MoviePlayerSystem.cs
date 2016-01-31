using UnityEngine;
using System.Collections;

public class MoviePlayerSystem : MonoBehaviour {

	public delegate void VoidDelegate ();
	public event VoidDelegate VideoStarted;

	public string movieFolder = "";
	private Sprite[] _movie; 

	private SpriteRenderer _renderer;
	private int _currentSpriteIndex = 0;

	[SerializeField]private GameObject _fadeToBlack;

	// Use this for initialization
	void Awake(){
		_renderer = gameObject.AddComponent<SpriteRenderer> ();
		if (movieFolder == "") {
			movieFolder = "Bakatuka"; //If there is no video then just load the first by default
		}
		_movie = Resources.LoadAll<Sprite> ("Climax/" + movieFolder);
	}

	public void PlayMovie (float afterSecondsToMenu = 4.5f) {
		StopCoroutine (VideoSystem ());
		_fadeToBlack.SetActive (false);
		Invoke ("DarkenScreen", afterSecondsToMenu);
		Invoke ("GoBackToMenu", afterSecondsToMenu + 2.5f);

		if (VideoStarted != null) {
			VideoStarted();
		}

		StartCoroutine (VideoSystem ());
	}
	
	// Update is called once per frame
	IEnumerator VideoSystem () {
		_renderer.sprite = _movie [_currentSpriteIndex];
		if (_currentSpriteIndex != _movie.Length - 1) {
			_currentSpriteIndex ++;
		} else {
			_currentSpriteIndex = 0;
		}
		yield return new WaitForSeconds (.03f);
		StartCoroutine (VideoSystem ());
	}
	private void DarkenScreen(){
		_fadeToBlack.SetActive (true);
		_fadeToBlack.GetComponent<Animation> ().Rewind();
		_fadeToBlack.GetComponent<Animation> ().Play ();
	}
	public void GoBackToMenu(){
		Application.LoadLevel (1);
	}
}
