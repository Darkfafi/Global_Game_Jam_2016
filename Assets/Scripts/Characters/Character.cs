using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour{

	private CharacterData _characterData;

	[SerializeField]private List<AudioClip> _allCharacterAudios = new List<AudioClip> ();

	private void Awake(){
		_characterData = gameObject.GetComponent<CharacterData> ();
	}

	public CharacterData characterData{
		get{return _characterData;}
	}

	public void CallPart(string namePart){
		Animation currentPartAnimator;
		currentPartAnimator = characterData.GetContolledPart (namePart).GetComponent<Animation> ();
		currentPartAnimator.Play (); //Cal the animation "PartMovement" in the animator
	}
}
