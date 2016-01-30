using UnityEngine;
using System.Collections;

public class PCcharacter : MonoBehaviour
{

	public Transform RightArmUpper;
	public Transform RightArmLower;

	public Transform LeftArmUpper;
	public Transform LeftArmLower;


	public Transform RightLegUpper;
	public Transform RightLegLower;
	public Transform RightFoot;

	public Transform LeftLegUpper;
	public Transform LeftLegLower;
	public Transform LeftFoot;

	public Transform[] mouth;

	public Transform LeftEye;
	public Transform RightEye;

	public bool isPC = true;

	bool ResetMouthFinsished = true;

	bool MouthBeingPressed = false;

	public AudioClip[] Sounds;

	void Start ()
	{
		StartCoroutine (BlinkEyes ());

		if (!isPC) {
			StartCoroutine (RandomAnimation ());
		}
	}

	void SetMouth (int m)
	{
		if (m < 1) {
			m = 1; 
		}
		GetComponent<AudioSource> ().clip = Sounds [m - 1];
		GetComponent<AudioSource> ().Play ();

		for (int i = 0; i < mouth.Length; i++) {
			if (i == m) {
				mouth [i].gameObject.SetActive (true);
			} else {
				mouth [i].gameObject.SetActive (false);
			}
		}
		Debug.Log ("mouth: " + m);

		//StopCoroutine (ResetMouth ());
		if (ResetMouthFinsished) {
			StartCoroutine (ResetMouth ());
		}
	}

	IEnumerator BlinkEyes ()
	{

		yield return new WaitForSeconds (Random.Range (2, 4));

		LeftEye.localScale = new Vector3 (1, .2f, 1);
		RightEye.localScale = new Vector3 (1, .2f, 1);

		yield return new WaitForSeconds (.2f);
		LeftEye.localScale = new Vector3 (1, 1, 1);
		RightEye.localScale = new Vector3 (1, 1, 1);

		StartCoroutine (BlinkEyes ());
	}

	IEnumerator RandomAnimation ()
	{

		yield return new WaitForSeconds (Random.Range (.5f, 1.5f));

		Debug.Log ("do random animation");

		switch (Random.Range (0, 8)) {
		case 0:
			RightArmUpper.GetComponent<Animation> ().Play ();
			RightArmLower.GetComponent<Animation> ().Play ();
			break;
		case 1:
			LeftArmUpper.GetComponent<Animation> ().Play ();
			LeftArmLower.GetComponent<Animation> ().Play ();
			break;


		case 2:
			RightLegUpper.GetComponent<Animation> ().Play ();
			break;


		case 3:
			LeftLegUpper.GetComponent<Animation> ().Play ();
			break;


		case 4:
			SetMouth (1);
			break;


		case 5:
			SetMouth (2);
			break;


		case 6:
			SetMouth (3);
			break;


		case 7:
			SetMouth (4);
			break;

		}

		StartCoroutine (RandomAnimation ());
	}



	IEnumerator ResetMouth ()
	{
		ResetMouthFinsished = false;
		yield return new WaitForSeconds (.5f);

		SetMouth (0);
		ResetMouthFinsished = true;
	}

	void Update ()
	{
		if (isPC) {
			//	transform.localScale = new Vector3 (1, Mathf.Sin (Time.time) + .9f, 1);


			transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime, 0, 0);


			if (Input.GetKeyDown (KeyCode.Q) || InputManager.Instance.GetXButtonDown ()) {
				SetMouth (1);
			}

			if (Input.GetKeyDown (KeyCode.W) || InputManager.Instance.GetYButtonDown ()) {
				SetMouth (2);
			}

			if (Input.GetKeyDown (KeyCode.E) || InputManager.Instance.GetBButtonDown ()) {
				SetMouth (3);
			}

			if (Input.GetKeyDown (KeyCode.R) || InputManager.Instance.GetAButtonDown ()) {
				SetMouth (4);
			}

			if (Input.GetKey (KeyCode.RightArrow) || InputManager.Instance.GetLeftBumberButtonDown ()) {
				Debug.Log ("right arm animation");
				RightArmUpper.GetComponent<Animation> ().Play ();
				RightArmLower.GetComponent<Animation> ().Play ();
			}

			if (Input.GetKey (KeyCode.LeftArrow) || InputManager.Instance.GetRightBumberButtonDown ()) {
				Debug.Log ("right arm animation");
				LeftArmUpper.GetComponent<Animation> ().Play ();
				LeftArmLower.GetComponent<Animation> ().Play ();
			}

			if (Input.GetKey (KeyCode.UpArrow) || Input.GetAxis ("LeftTriggerMac") > .5f || Input.GetAxis ("LeftTriggerWin") > .5f) {
				Debug.Log ("right arm animation");
				RightLegUpper.GetComponent<Animation> ().Play ();
				//	RightLegLower.GetComponent<Animation> ().Play ();
				//	RightFoot.GetComponent<Animation> ().Play ();
			}

			if (Input.GetKey (KeyCode.DownArrow) || Input.GetAxis ("RightTriggerMac") > .5f || Input.GetAxis ("RightTriggerWin") > .5f) {
				Debug.Log ("right arm animation");
				LeftLegUpper.GetComponent<Animation> ().Play ();
				//	LeftLegLower.GetComponent<Animation> ().Play ();
				//	LeftFoot.GetComponent<Animation> ().Play ();
			}
		}
	}
}
