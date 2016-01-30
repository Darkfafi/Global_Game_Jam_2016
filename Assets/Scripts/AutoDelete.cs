using UnityEngine;
using System.Collections;

public class AutoDelete : MonoBehaviour
{
	void Start ()
	{
		Destroy (gameObject, 5);
	}
}
