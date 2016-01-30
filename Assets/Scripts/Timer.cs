using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
	public Image timerImage;
	public float timeInSeconds;
	private float time = 0;

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
			time = timeInSeconds;
		}
	}
}
