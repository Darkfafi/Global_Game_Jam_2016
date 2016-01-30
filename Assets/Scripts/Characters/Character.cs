using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour{

	public delegate void VoidDelegate();
	public event VoidDelegate DidMove;

	private Vector2 _destination;
	private Vector2 _differents;
	private int _directionMoving = 0;

	private CharacterData _characterData;
	[SerializeField]private List<AudioClip> _allCharacterAudios = new List<AudioClip> ();

	private void Awake(){
		_characterData = gameObject.GetComponent<CharacterData> ();
		GetComponent<Animation> ().Play ();
		SetMouth (Random.Range(1,3));
	}

	public CharacterData characterData{
		get{return _characterData;}
	}

	public void CallPart(string namePart){
		Animation currentPartAnimator;
		currentPartAnimator = characterData.GetContolledPart (namePart).GetComponent<Animation> ();
		currentPartAnimator.Play (); //Cal the animation "PartMovement" in the animator
		if (DidMove != null) {
			DidMove();
		}
	}
	public int GetIndexOfAudio(AudioClip clip){
		return _allCharacterAudios.IndexOf (clip);
	}

	public void SetMouth (int m)
	{
		Transform[] mouth = _characterData.GetAllMouths ();

		for (int i = 0; i < mouth.Length; i++) {
			if (i == m) {
				mouth [i].gameObject.SetActive (true);
			} else {
				mouth [i].gameObject.SetActive (false);
			}
		}
		Debug.Log ("mouth: " + m);
		
		//StopCoroutine (ResetMouth ());
		if (m != 0) {
			StartCoroutine (ResetMouth ());
			
			GetComponent<AudioSource> ().clip = _allCharacterAudios[m - 1];
			GetComponent<AudioSource> ().pitch = Random.Range (.7f, 1.4f);
			GetComponent<AudioSource> ().Play ();
		}
		if (m < 1) {
			m = 1; 
		}
		if (DidMove != null) {
			DidMove();
		}
	}
	public void MoveToDirection(int direction){
		_destination = transform.position + new Vector3(0.5f * direction,0,0);
		_directionMoving = direction;
	}

	void Update(){
		if (_directionMoving != 0) {
			transform.position = Vector2.Lerp(transform.position,_destination,0.02f);
			_differents = new Vector2(Mathf.Abs(_destination.x - transform.position.x),Mathf.Abs(_destination.y - transform.position.y));
			if(_differents.x < 0.01f && _differents.y < 0.01f){
				transform.position = _destination;
				_directionMoving = 0;
			}
		}
	}

	IEnumerator ResetMouth ()
	{
		yield return new WaitForSeconds (.5f);
		SetMouth (0);
	}

}
