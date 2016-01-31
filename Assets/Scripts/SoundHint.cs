using UnityEngine;
using System.Collections;

public class SoundHint : MonoBehaviour
{


	public Transform[] ParticleSys;
	/*
	static public SoundHint Instance;

	void Awake ()
	{
		if (Instance != null) {
			Debug.LogError ("SoundHint Already exists");
		} else {
			Instance = this;
		}
	}
	*/
	public void YellowY ()
	{
		Instantiate (ParticleSys [0], new Vector3 (0, 2, 0), Quaternion.identity);
	}

	public void GreenA ()
	{
		Instantiate (ParticleSys [1], new Vector3 (0, 2, 0), Quaternion.identity);
	}

	public void RedB ()
	{
		Instantiate (ParticleSys [2], new Vector3 (0, 2, 0), Quaternion.identity);
	}

	public void BlueX ()
	{
		Instantiate (ParticleSys [3], new Vector3 (0, 2, 0), Quaternion.identity);
	}

}
