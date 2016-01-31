using UnityEngine;
using System.Collections;

public class superduperHack : MonoBehaviour {
	public MoviePlayerSystem movie;
	public Transform bed;

	// Use this for initialization
	void Awake () {
		bed.gameObject.SetActive (false);
		movie.VideoStarted += Started;
	}
	
	// Update is called once per frame
	void Started () {
		bed.gameObject.SetActive (true);
	}
}
