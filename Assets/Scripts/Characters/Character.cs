using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour , ICharacter {

	private CharacterData _characterData;

	[SerializeField]private List<AudioClip> _allCharacterAudios = new List<AudioClip> ();

	private void Awake(){
		_characterData = gameObject.AddComponent<CharacterData> ();
	}

	public CharacterData characterData{
		get{return _characterData;}
	}

	public abstract void CallPart(string namePart,int range);
}
