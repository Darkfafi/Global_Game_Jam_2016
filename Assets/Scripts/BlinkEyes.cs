using UnityEngine;
using System.Collections;

public class BlinkEyes : MonoBehaviour
{

	public	Transform LeftEye;
	public	Transform RightEye;

	void Start ()
	{
		StartCoroutine (BlinkWithEyes ());
	}
	
	IEnumerator BlinkWithEyes ()
	{
		
		yield return new WaitForSeconds (Random.Range (2, 4));
		
		LeftEye.localScale = new Vector3 (1, .2f, 1);
		RightEye.localScale = new Vector3 (1, .2f, 1);
		
		yield return new WaitForSeconds (.2f);
		LeftEye.localScale = new Vector3 (1, 1, 1);
		RightEye.localScale = new Vector3 (1, 1, 1);
		
		StartCoroutine (BlinkWithEyes ());
	}
}
