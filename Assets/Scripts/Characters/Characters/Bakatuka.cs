using UnityEngine;
using System.Collections;

public class Bakatuka : Character {

	public override void CallPart(string namePart, int range){
		bool playNotRange = false;
		Animator currentPartAnimator;
		switch (namePart) {
		case Tags.MOVE_PART_A:
			playNotRange = true;
			break;
		}
		currentPartAnimator = characterData.GetContolledPart (namePart).GetComponent<Animator> ();
		currentPartAnimator.Play("PartMovement"); //Cal the animation "PartMovement" in the animator
		if (!playNotRange) {
			currentPartAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime = ((float)range * 0.01f); // sets 0 - 100 to 0 to 1.
		}
	}
}
