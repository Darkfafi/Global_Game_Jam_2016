using UnityEngine;
using System.Collections;

public class SoundHint : MonoBehaviour
{
	static public SoundHint Instance;

	public Transform[] ParticleSys;

	void Awake ()
	{
		if (Instance != null) {
			Debug.LogError ("SoundHint Already exists");
		} else {
			Instance = this;
		}
	}

	public void YellowY ()
	{
		Instantiate (ParticleSys [0]);
	}

	public void GreenA ()
	{
		Instantiate (ParticleSys [1]);
	}

	public void RedB ()
	{
		Instantiate (ParticleSys [2]);
	}

	public void BlueX ()
	{
		Instantiate (ParticleSys [3]);
	}

}
