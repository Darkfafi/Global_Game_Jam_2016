using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoviePlayer : MonoBehaviour
{
	public List<Sprite> spriteList = new List<Sprite> ();

	public Sprite goalSprite;

	public	int videoCounter = 0;

	void Start ()
	{
		StartCoroutine (VideoSystem ());
	}

	IEnumerator VideoSystem ()
	{
		GetComponent<SpriteRenderer> ().sprite = spriteList [videoCounter];

		if (videoCounter <= 88) {
			videoCounter++;
		} else {
			videoCounter = 0;
		}
		yield return new WaitForSeconds (.03f);
		StartCoroutine (VideoSystem ());
	}
	
}
