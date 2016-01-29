using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	private CharacterData _characterData;
	
	private void Awake(){
		_characterData = gameObject.AddComponent<CharacterData> ();
	}

	public CharacterData characterData{
		get{return _characterData;}
	}
}
