using UnityEngine;
using System.Collections;

public class PCcharacter : MonoBehaviour
{

	public Transform RightArm;

	void Update ()
	{
	

		//	if (InputManager.Instance.GetRightBumberButton) {
		//		RightArm.GetComponent<Animator> ().Play ("RightUpperArm");
		//	}

		if (Input.GetAxis ("RightBumperMac") > .1f) {
			Debug.Log ("Right bumper pressed");
			RightArm.GetComponent<Animator> ().Play ("RightUpperArm");
		}

	}
}
