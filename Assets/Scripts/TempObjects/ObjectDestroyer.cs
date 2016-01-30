using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 1.5f);
	}
	void Update(){
		if (transform.localScale.x > 0) {
			transform.localScale  = new Vector3(Mathf.Lerp(transform.localScale.x,transform.localScale.x - 1,0.1f),transform.localScale.y,transform.localScale.z);
		}else{
			transform.localScale = new Vector3(0,transform.localScale.y,transform.localScale.z);;
		}
		if (transform.localScale.y > 0) {

			transform.localScale = new Vector3(transform.localScale.x,Mathf.Lerp(transform.localScale.y,transform.localScale.y - 1,0.1f),transform.localScale.z);
		}else{
			transform.localScale = new Vector3(transform.localScale.x,0,transform.localScale.z);
		}
		if (transform.localScale.x == 0 && transform.localScale.y == 0) {
			Destroy(this.gameObject);
		}
	}
}
