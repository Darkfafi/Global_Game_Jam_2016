using UnityEngine;
using System.Collections;

public class LoveFX : MonoBehaviour
{

	public Transform otherLoveFX;

	void Start ()
	{
		StartCoroutine (WaitToStartLoveFX ());
	}

	IEnumerator WaitToStartLoveFX ()
	{
		yield return new WaitForSeconds (.5f);
		if (otherLoveFX != null) {
			otherLoveFX.gameObject.SetActive (true);
		}
	}

}
