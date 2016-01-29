using UnityEngine;
using System.Collections;

public class Bakatuka : Character {

	public override void CallPart(string namePart, int range){
		bool playNotRange = false;
		switch (namePart) {
		case Tags.MOVE_PART_A:
			playNotRange = true;
			break;
		}
		if (playNotRange) {
			characterData.GetContolledPart (namePart).GetComponent<Animation> ().Play ();
		} else {
			//TODO Stop Animation at frame determined by range, because range is something like axis range etc.
		}

	}
}
