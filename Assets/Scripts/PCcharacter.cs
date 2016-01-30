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

	bool DoingMove = false;

	public AudioClip[] Sounds;

	public Transform heartPlaceholder;

	int chosenMove = 0;

	public Transform timer;

	void Start ()
	{
		StartCoroutine (BlinkEyes ());

		if (!isPC) {
			StartCoroutine (RandomAnimation ());
		}
	}

	void SetMouth (int m)
	{

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

		if (m < 1) {
			m = 1; 
		}
		GetComponent<AudioSource> ().clip = Sounds [m - 1];
		GetComponent<AudioSource> ().pitch = Random.Range (.7f, 1.4f);
		GetComponent<AudioSource> ().Play ();

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

		yield return new WaitForSeconds (Random.Range (.9f, 1.5f));

		Debug.Log ("do random animation");

		if (!DoingMove) {
			switch (Random.Range (0, 12)) {
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
			case 9:
				DoMove ();
				break;
			case 10:
				DoMove ();
				break;
			case 11:
				DoMove ();
				break;
			}
		}
		StartCoroutine (RandomAnimation ());
	}

	void DoMove ()
	{


		timer.gameObject.SetActive (true);

		Debug.LogWarning ("Doing Move!");

		DoingMove = true;
		chosenMove = Random.Range (0, 4);

		//debug reasons
		//chosenMove = 0;

		switch (chosenMove) {
		case 0:
			SetMouth (3);
			LeftArmUpper.GetComponent<Animation> ().Play ();
			LeftArmLower.GetComponent<Animation> ().Play ();
			RightLegUpper.GetComponent<Animation> ().Play ();


			break;
		case 1:

			SetMouth (4);
			LeftArmUpper.GetComponent<Animation> ().Play ();
			LeftArmLower.GetComponent<Animation> ().Play ();
			LeftLegUpper.GetComponent<Animation> ().Play ();

			break;
		case 2:

			SetMouth (2);
			LeftArmUpper.GetComponent<Animation> ().Play ();
			LeftArmLower.GetComponent<Animation> ().Play ();
			RightLegUpper.GetComponent<Animation> ().Play ();

			break;
		case 3:
			SetMouth (1);
			RightArmUpper.GetComponent<Animation> ().Play ();
			RightArmLower.GetComponent<Animation> ().Play ();
			LeftLegUpper.GetComponent<Animation> ().Play ();
			break;
		}

		StartCoroutine (ResetMove ());
	}

	IEnumerator ResetMove ()
	{
		yield return new WaitForSeconds (5);
		DoingMove = false;
	
		timer.gameObject.SetActive (false);
	}

	IEnumerator ResetMouth ()
	{
		ResetMouthFinsished = false;
		yield return new WaitForSeconds (.5f);

		SetMouth (0);

		ResetMouthFinsished = true;
	}

	IEnumerator DisableWinHeartEffect ()
	{

		yield return new WaitForSeconds (3);
		heartPlaceholder.gameObject.SetActive (false);

	}

	void WinMove ()
	{
		GameManager.Instance.AddLovePoints (1);
		//	timer.GetComponent<Timer> ().timeInSeconds = 5;
		timer.gameObject.SetActive (false);
		heartPlaceholder.gameObject.SetActive (true);
		StartCoroutine (DisableWinHeartEffect ());
	}


	void LooseMove ()
	{
		// do loose move stuff
		timer.gameObject.SetActive (false);
		chosenMove = 11;
		DoingMove = false;
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

			if (Input.GetKey (KeyCode.RightArrow) || InputManager.Instance.GetRightBumberButtonDown ()) {
				Debug.Log ("right arm animation");
				RightArmUpper.GetComponent<Animation> ().Play ();
				RightArmLower.GetComponent<Animation> ().Play ();
			}

			if (Input.GetKey (KeyCode.LeftArrow) || InputManager.Instance.GetLeftBumberButtonDown ()) {
				Debug.Log ("right arm animation");
				LeftArmUpper.GetComponent<Animation> ().Play ();
				LeftArmLower.GetComponent<Animation> ().Play ();
			}

			if (Input.GetKey (KeyCode.UpArrow) || Input.GetAxis ("RightTriggerMac") > .5f || Input.GetAxis ("RightTriggerWin") > .5f) {
				Debug.Log ("right arm animation");
				RightLegUpper.GetComponent<Animation> ().Play ();
				//	RightLegLower.GetComponent<Animation> ().Play ();
				//	RightFoot.GetComponent<Animation> ().Play ();
			}

			if (Input.GetKey (KeyCode.DownArrow) || Input.GetAxis ("LeftTriggerMac") > .5f || Input.GetAxis ("LeftTriggerWin") > .5f) {
				Debug.Log ("right arm animation");
				LeftLegUpper.GetComponent<Animation> ().Play ();
				//	LeftLegLower.GetComponent<Animation> ().Play ();
				//	LeftFoot.GetComponent<Animation> ().Play ();
			}
		} else {
			if (DoingMove) {
				//check for player move temporary solution

				switch (chosenMove) {
				case 0:
					//build filter for filtering out button mash

					if (Input.anyKey) {
						if (InputManager.Instance.GetBButton () && InputManager.Instance.GetLeftBumberButton () && (Input.GetKey (KeyCode.UpArrow) || Input.GetAxis ("RightTriggerMac") > .5f || Input.GetAxis ("RightTriggerWin") > .5f)) {
							WinMove ();
						} else {

							if (InputManager.Instance.GetXButton () || InputManager.Instance.GetYButton () || InputManager.Instance.GetAButton () || InputManager.Instance.GetRightBumberButton () || Input.GetKey (KeyCode.DownArrow) || Input.GetAxis ("LeftTriggerMac") > .5f || Input.GetAxis ("LeftTriggerWin") > .5f) {
								LooseMove ();
							}
						}

					}
					/*
					SetMouth (3);
					LeftArmUpper.GetComponent<Animation> ().Play ();
					LeftArmLower.GetComponent<Animation> ().Play ();
					RightLegUpper.GetComponent<Animation> ().Play ();
					*/

					break;
				case 1:
					if (Input.anyKey) {
						if (InputManager.Instance.GetAButton () && InputManager.Instance.GetLeftBumberButton () && (Input.GetKey (KeyCode.DownArrow) || Input.GetAxis ("LeftTriggerMac") > .5f || Input.GetAxis ("LeftTriggerWin") > .5f)) {
							WinMove ();
							//	Debug.LogError ("WE DID IT WE MADE A COMBINATION!");
						} else {
							if (InputManager.Instance.GetXButton () || InputManager.Instance.GetYButton () || InputManager.Instance.GetBButton () || InputManager.Instance.GetRightBumberButton () || Input.GetKey (KeyCode.UpArrow) || Input.GetAxis ("RightTriggerMac") > .5f || Input.GetAxis ("RightTriggerWin") > .5f) {
								LooseMove ();
							}
						}
					}
					/*
					SetMouth (4);
					LeftArmUpper.GetComponent<Animation> ().Play ();
					LeftArmLower.GetComponent<Animation> ().Play ();
					LeftLegUpper.GetComponent<Animation> ().Play ();
					*/

					break;
				case 2:
					if (Input.anyKey) {
						if (InputManager.Instance.GetYButton () && InputManager.Instance.GetLeftBumberButton () && (Input.GetKey (KeyCode.UpArrow) || Input.GetAxis ("RightTriggerMac") > .5f || Input.GetAxis ("RightTriggerWin") > .5f)) {
							WinMove ();
							//	Debug.LogError ("WE DID IT WE MADE A COMBINATION!");
						} else {
							if (InputManager.Instance.GetBButton () || InputManager.Instance.GetXButton () || InputManager.Instance.GetAButton () || InputManager.Instance.GetRightBumberButton () || Input.GetKey (KeyCode.DownArrow) || Input.GetAxis ("LeftTriggerMac") > .5f || Input.GetAxis ("LeftTriggerWin") > .5f) {
								LooseMove ();
							}
						}
					}
					/*
					SetMouth (2);
					LeftArmUpper.GetComponent<Animation> ().Play ();
					LeftArmLower.GetComponent<Animation> ().Play ();
					RightLegUpper.GetComponent<Animation> ().Play ();
					*/
					break;
				case 3:
					if (Input.anyKey) {
						if (InputManager.Instance.GetXButton () && InputManager.Instance.GetRightBumberButton ()) {
							WinMove ();
							//	Debug.LogError ("WE DID IT WE MADE A COMBINATION!");
						} else {
							if (InputManager.Instance.GetYButton () || InputManager.Instance.GetBButton () || InputManager.Instance.GetAButton () || InputManager.Instance.GetLeftBumberButton () || Input.GetKey (KeyCode.DownArrow) || Input.GetAxis ("LeftTriggerMac") > .5f || Input.GetAxis ("LeftTriggerWin") > .5f || Input.GetKey (KeyCode.UpArrow) || Input.GetAxis ("RightTriggerMac") > .5f || Input.GetAxis ("RightTriggerWin") > .5f) {
								LooseMove ();
							}
						}
					}
					/*
					SetMouth (2);
					RightArmUpper.GetComponent<Animation> ().Play ();
					RightArmLower.GetComponent<Animation> ().Play ();
					*/
					break;
				}

			}
		}
	}
}
