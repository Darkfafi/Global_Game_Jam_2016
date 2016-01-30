using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
	public delegate void VoidDelegate ();
	public event VoidDelegate TimerEnd;

	public Image timerImage;
	public float timeInSeconds;
	private float time = 0;

	void OnEnable ()
	{

	}

	// Use this for initialization
	void Start ()
	{
		timerImage.fillAmount = 0;
	}

	// Update is called once per frame
	void Update ()
	{
		time += Time.deltaTime;
		timerImage.fillAmount = time / timeInSeconds;
		if (time >= timeInSeconds) {
			print ("TIME GONE");
			time = 0;
			if (TimerEnd != null) {
				TimerEnd ();
			}
		}
	}
}
