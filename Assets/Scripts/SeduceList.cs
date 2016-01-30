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
		AudioSource targetSourceClip = null;
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
			targetSourceClip = character.GetComponent<AudioSource> ();
			if(targetSourceClip.clip == null 
			   || ((character.GetIndexOfAudio(targetSourceClip.clip) + 1) != wantedSoundIndex 
			    || (character.GetIndexOfAudio(targetSourceClip.clip) + 1) == wantedSoundIndex && !targetSourceClip.isPlaying)){ // BECAUSE 0 == DEFAULT == NO SOUND
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
	public string GetReversedMovement(string movementPartConst){
		string returnPart = null;
		switch (movementPartConst) {
		case Tags.MOVE_PART_A:
			returnPart = Tags.MOVE_PART_B;
			break;
		case Tags.MOVE_PART_B:
			returnPart = Tags.MOVE_PART_A;
			break;
		case Tags.MOVE_PART_C:
			returnPart = Tags.MOVE_PART_D;
			break;
		case Tags.MOVE_PART_D:
			returnPart = Tags.MOVE_PART_C;
			break;
		}
		return returnPart;
	}
	public int GetReversedAudio(int audioIndex){
		int returnindex = 0; //0 == no sound
		switch (audioIndex) {
		case 1:
			returnindex = 2;
			break;
		case 2:
			returnindex = 1;
			break;
		case 3:
			returnindex = 4;
			break;
		case 4:
			returnindex = 3;
			break;
		}
		return returnindex;
	}
}
public class SeduceData{
	public List<string> partsWantMoving = new List<string>();
	public int audioIndex = 0; // 0 == no audio (Default mouth)
}
