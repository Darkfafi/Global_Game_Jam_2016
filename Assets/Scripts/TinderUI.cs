using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class TinderUI : MonoBehaviour
{
	public List<LevelName> levels = new List<LevelName> ();
	public List<GameObject> backgrounds = new List<GameObject> ();
	public List<GameObject> matches = new List<GameObject> ();
	public Button likeButton;
	public Button dislikeButton;

	public GameObject bgMatch;

	private Vector3 pos;
	private Quaternion rot;

	private int _indexToSwap = 0;

	private Sequence likeSequence;
	private Sequence dislikeSequence;

	// Use this for initialization
	void Start ()
	{
		likeButton.onClick.AddListener (() => Liked ());
		dislikeButton.onClick.AddListener (() => Disliked ());

		_indexToSwap = levels.Count - 1;

		pos = levels [_indexToSwap].transform.position;
		rot = levels [_indexToSwap].transform.rotation;
		//todo make work
	}

	void Update ()
	{
		if (InputManager.Instance.GetAButton ()) {
			Liked ();
		}

		if (InputManager.Instance.GetBButton ()) {
			Disliked ();
		}

#if UNITY_WINDOWS
		if(Input.GetAxis("LeftTriggerWin") < -.5f)
		{
			Disliked();
		}

		if(Input.GetAxis("LeftTriggerWin") > .5f)
		{
			Liked();
		}
#else
		if (Input.GetAxis ("LeftTriggerMac") < -.5f) {
			Disliked ();
		}

		if (Input.GetAxis ("LeftTriggerMac") > .5f) {
			Liked ();
		}
#endif

	}


	private void Liked ()
	{
		DOTween.CompleteAll (true);

		levels [_indexToSwap].transform.DOMoveX (16, 0.5f).SetEase (Ease.InSine).OnComplete (LikeCompleted);
		levels [_indexToSwap].transform.DOMoveY (10, 0.4f).SetEase (Ease.InCirc);
		levels [_indexToSwap].transform.DORotate (new Vector3 (0, 0, 40), 0.45f);

		int nextIndex = _indexToSwap == 0 ? levels.Count - 1 : _indexToSwap - 1;
		levels [nextIndex].transform.DOScale (levels [nextIndex].transform.localScale *= 0.96f, 0);
		levels [nextIndex].transform.DOScale (Vector3.one, 0.3f);

		backgrounds [_indexToSwap].transform.DOScale (transform.localScale * 1.1f, 0.8f).SetEase (Ease.OutCubic);

		levels [_indexToSwap].like.SetActive (true);

		for (int i = 0; i < levels.Count; i++) {

			if (i != _indexToSwap) {
				//Destroy(levels[i].gameObject);
				// Not so pretty for juicyness
			}
		}
	}

	private void LikeCompleted ()
	{
		//todo check if actually can play
		if (LevelManager.Instance.MayChooseLevel (_indexToSwap, levels.Count)) {
			// you may choose aka match

			// TODO fix ugly ui snap when appear
			// todo add sound
			Vector3 scale = matches [_indexToSwap].transform.localScale;
			matches [_indexToSwap].transform.DOScale (Vector3.zero, 0f);

			matches [_indexToSwap].SetActive (true);
			bgMatch.SetActive (true);

			matches [_indexToSwap].transform.DOScale (scale, 0.3f).SetEase (Ease.InQuint);
			matches [_indexToSwap].transform.DOPunchScale (Vector3.one * 0.1f, 0.2f, 10, 0.5f).SetDelay (0.3f);

			matches [_indexToSwap].transform.DOMove (matches [_indexToSwap].transform.position, 0f).SetDelay (3f).OnComplete (MatchCompleted);

			levels [_indexToSwap].GetComponent<AudioSource> ().Play ();

		} else {
			levels [_indexToSwap].transform.SetAsFirstSibling ();

			levels [_indexToSwap].transform.position = pos;
			levels [_indexToSwap].transform.rotation = rot;

			levels [_indexToSwap].like.SetActive (false);

			_indexToSwap--;
			if (_indexToSwap == -1) {
				_indexToSwap = levels.Count - 1;
			}
		}

		// TODO what if level to load does not exist?
	}

	private void MatchCompleted ()
	{
		print ("load level: " + levels [_indexToSwap].levelName);
		LevelManager.Instance.ChooseLevel (_indexToSwap, levels.Count);
	}

	private void Disliked ()
	{

		print ("disliked");

		DOTween.CompleteAll (true);

		levels [_indexToSwap].transform.DOMoveX (-16, 0.5f).SetEase (Ease.InSine).OnComplete (DislikeCompleted);
		levels [_indexToSwap].transform.DOMoveY (10, 0.4f).SetEase (Ease.InCirc);
		levels [_indexToSwap].transform.DORotate (new Vector3 (0, 0, -40), 0.45f);

		int nextIndex = _indexToSwap == 0 ? levels.Count - 1 : _indexToSwap - 1;
		levels [nextIndex].transform.DOScale (levels [nextIndex].transform.localScale *= 0.96f, 0);
		levels [nextIndex].transform.DOScale (Vector3.one, 0.3f);

		backgrounds [_indexToSwap].transform.SetAsFirstSibling ();

		levels [_indexToSwap].dislike.SetActive (true);


		//next frame
	}

	private void DislikeCompleted ()
	{

		print ("dislikecompl");
		levels [_indexToSwap].transform.SetAsFirstSibling ();

		levels [_indexToSwap].transform.position = pos;
		levels [_indexToSwap].transform.rotation = rot;

		levels [_indexToSwap].dislike.SetActive (false);


		_indexToSwap--;
		if (_indexToSwap == -1) {
			_indexToSwap = levels.Count - 1;
		}
	}
}
