using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SeduceList : MonoBehaviour {

	//[SerializeField]private Character _character;
	public List<string> allPartsNeedMoving = new List<string> ();
	public int wantedSoundIndex = 0; //TODO replace WantedSound with this.

	public void SetList(SeduceData data){
		allPartsNeedMoving = data.partsWantMoving;
		wantedSoundIndex = data.audioIndex;
	}

	public bool CheckIfMatch(Character character){
		bool match = false;
		List<Transform> list = character.characterData.GetAllContolledParts ();
		AudioClip targetClip = null;
		int matches = 0;
		for (int j = 0; j < list.Count; j++) {
			if(list[j].GetComponent<Animation>().isPlaying){
				if(IsAPartNeedMoving(character,list[j])){
					matches ++;
				}else{
					matches = 0;
					break;
				}
			}
		}
		if (matches == allPartsNeedMoving.Count) {
			match = true;
		}
		if (match && wantedSoundIndex != 0) {
			targetClip = character.GetComponent<AudioSource> ().clip;
			if(targetClip == null || (character.GetIndexOfAudio(targetClip) + 1) != wantedSoundIndex){ // BECAUSE 0 == DEFAULT == NO SOUND
				match = false;
			}
		}
		return match;
	}

	private bool IsAPartNeedMoving(Character ch,Transform trans){
		bool result = false;
		for (int i = 0; i < allPartsNeedMoving.Count; i++) {
			if(ch.characterData.GetContolledPart(allPartsNeedMoving[i]) == trans){
				result = true;
				break;
			}
		}
		return result;
	}
}
public class SeduceData{
	public List<string> partsWantMoving = new List<string>();
	public int audioIndex = 0; // 0 == no audio (Default mouth)
}
