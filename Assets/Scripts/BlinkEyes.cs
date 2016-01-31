using UnityEngine;
using System.Collections;

public class BlinkEyes : MonoBehaviour
{
	public int retardBlinkChance = 30;

	public	Transform LeftEye;
	public	Transform RightEye;

	void Start ()
	{
		StartCoroutine (BlinkWithEyes ());
	}
	
	IEnumerator BlinkWithEyes ()
	{
		int randomBlink = Random.Range (0, 100);
		yield return new WaitForSeconds (Random.Range (2, 4));
		
		LeftEye.localScale = new Vector3 (1, .2f, 1);
		if (RightEye != null) {
			RightEye.localScale = new Vector3 (1, .2f, 1);
		}
		yield return new WaitForSeconds (.2f);
		LeftEye.localScale = new Vector3 (1, 1, 1);
		if (randomBlink < retardBlinkChance) {
			yield return new WaitForSeconds (.1f);
		}
		if (RightEye != null) {
			RightEye.localScale = new Vector3 (1, 1, 1);
		}
		StartCoroutine (BlinkWithEyes ());
	}
}
