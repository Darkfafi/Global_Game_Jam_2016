using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SequanceManager : MonoBehaviour
{
	public static SequanceManager Instance;

	public List<Transform> MoveList = new List<Transform> ();

	public Transform target;


	void Awake ()
	{
		if (Instance != null) {
			Instance = this;
		} else {
			Debug.Log ("Sequence manager already exists");
		}
	}

	void Start ()
	{
		StartCoroutine (DanceRoutineLoop ());
	}

	IEnumerator DanceRoutineLoop ()
	{


		yield return new WaitForSeconds (1);
	
		DoNextMove ();

		StartCoroutine (DanceRoutineLoop ());
	}


	public void DoNextMove ()
	{

	}

}
