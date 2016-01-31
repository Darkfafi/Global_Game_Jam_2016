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
		Transform t = Instantiate (ParticleSys [0]) as Transform;//, new Vector3 (0, 2, 0), Quaternion.identity);
		t.position = transform.position;
		t.Translate (0, 2.5f, -4);
	}

	public void GreenA ()
	{
		Transform t = Instantiate (ParticleSys [1]) as Transform;
		t.position = transform.position;
		t.Translate (0, 2.5f, -4);
		;//, new Vector3 (0, 2, 0), Quaternion.identity);
	}

	public void RedB ()
	{
		Transform t = Instantiate (ParticleSys [2]) as Transform;
		t.position = transform.position;
		t.Translate (0, 2.5f, -4);
		//, new Vector3 (0, 2, 0), Quaternion.identity);
	}

	public void BlueX ()
	{
		Transform t = Instantiate (ParticleSys [3]) as Transform;
		t.position = transform.position;
		t.Translate (0, 2.5f, -4);//, new Vector3 (0, 2, 0), Quaternion.identity);
	}

}
