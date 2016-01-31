using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour
{

	bool fadeOut = false;

	// Use this for initialization
	void Start ()
	{
		//Destroy (this.gameObject, 1.5f);
		StartCoroutine (delayedStartFade ());
	}

	IEnumerator delayedStartFade ()
	{

		yield return new WaitForSeconds (.5f);

		fadeOut = true;
	}


	void Update ()
	{
		if (fadeOut) {
			Color color = GetComponent<SpriteRenderer> ().color;
			GetComponent<SpriteRenderer> ().color = new Color (color.r + 255, color.g, color.b, color.a - (0.8f * Time.deltaTime));
			if (color.a <= 0) {
				Destroy (this.gameObject);
			}
		}
	}
}
