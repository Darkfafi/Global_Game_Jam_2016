using UnityEngine;
using System.Collections;

public class SoundHint : MonoBehaviour
{

	static public SoundHint Instance;

	public Transform[] hints;

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

	}

	public void GreenA ()
	{
		
	}

	public void RedB ()
	{
		
	}

	public void BlueX ()
	{
		
	}

}
