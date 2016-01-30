using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SeduceList : MonoBehaviour {

	[SerializeField]private Character _character;
	private List<string> _allPartsNeedMoving = new List<string> ();
	private AudioClip _wantedSound = null;

	public bool CheckIfMatch(){
		bool match = true;
		for (int i = 0; i < _allPartsNeedMoving.Count; i++) {
			if(!_character.characterData.GetContolledPart(_allPartsNeedMoving[i]).GetComponent<Animation>().isPlaying){
				match = false;
				break;
			}
		}
		if (match && _wantedSound != null) {
			if(_character.GetComponent<AudioSource>().clip == null || !_character.GetComponent<AudioSource>().clip == _wantedSound){
				match = false;
			}
		}
		return match;
	}
}
