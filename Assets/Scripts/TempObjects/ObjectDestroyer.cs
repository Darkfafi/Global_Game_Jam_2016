using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Destroy (this.gameObject, 1.5f);
	}
	void Update(){
		Color color = GetComponent<SpriteRenderer> ().color;
		GetComponent<SpriteRenderer> ().color = new Color(color.r,color.g,color.b,color.a - (0.8f * Time.deltaTime));
		if (color.a <= 0) {
			Destroy(this.gameObject);
		}
	}
}
