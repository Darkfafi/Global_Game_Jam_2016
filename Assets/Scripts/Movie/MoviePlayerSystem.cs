using UnityEngine;
using System.Collections;

public class MoviePlayerSystem : MonoBehaviour {
	
	public string movieFolder;
	private Sprite[] _movie; 

	private SpriteRenderer _renderer;
	private int _currentSpriteIndex = 0;
	// Use this for initialization
	void Start () {
		_renderer = gameObject.AddComponent<SpriteRenderer> ();
		_movie = Resources.LoadAll<Sprite> ("Climax/" + movieFolder);
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
}
