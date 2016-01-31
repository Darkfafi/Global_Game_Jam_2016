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

		otherLoveFX.gameObject.SetActive (true);
	}

}
