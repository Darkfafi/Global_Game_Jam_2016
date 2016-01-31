using UnityEngine;
using System.Collections;

public class IntroItems : MonoBehaviour {
	private bool _fading = false;
	private TextMesh _mesh;
	void Awake(){
		_mesh = gameObject.GetComponent<TextMesh> ();
		Invoke ("StartFade",3);
	}
	void StartFade(){
		_fading = true;
	}

	void Update(){
		if (_fading) {
			Color c = _mesh.color;
			_mesh.color = new Color (c.r, c.g, c.b, c.a - Time.deltaTime);
			if (_mesh.color.a <= 0) {
				Destroy (this.gameObject);
			}
		}
	}
}
