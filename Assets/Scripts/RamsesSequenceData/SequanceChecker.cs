using UnityEngine;
using System.Collections;

public class SequanceChecker : MonoBehaviour {

	public static bool RotationInRange(float rotation, float minRot, float maxRot){
		if (rotation > minRot && rotation < maxRot) {
			return true;
		} else {
			return false;
		}
	}
}
