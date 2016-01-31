using UnityEngine;
using System.Collections;

public class SoundHint : MonoBehaviour
{
	public Transform[] ParticleSys;

	public void YellowY ()
	{
		Transform t = Instantiate (ParticleSys [0]) as Transform;
		t.position = transform.position;
		t.Translate (0, 2.5f, -4);
	}

	public void GreenA ()
	{
		Transform t = Instantiate (ParticleSys [1]) as Transform;
		t.position = transform.position;
		t.Translate (0, 2.5f, -4);
	}

	public void RedB ()
	{
		Transform t = Instantiate (ParticleSys [2]) as Transform;
		t.position = transform.position;
		t.Translate (0, 2.5f, -4);
		;
	}

	public void BlueX ()
	{
		Transform t = Instantiate (ParticleSys [3]) as Transform;
		t.position = transform.position;
		t.Translate (0, 2.5f, -4);
	}

}
