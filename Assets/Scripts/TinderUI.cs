using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class TinderUI : MonoBehaviour
{
    public List<LevelName> levels = new List<LevelName>();
    public Button likeButton;
    public Button dislikeButton;

    private bool locked = false;

    private int _indexToSwap = 3;

    // Use this for initialization
    void Start()
    {
		likeButton.onClick.AddListener(() => Liked());
		dislikeButton.onClick.AddListener(() => Disliked());
    }

    // Update is called once per frame
    void Update()
    {

    }

	private void Liked()
	{
        locked = true;

		DOTween.CompleteAll(true);

        levels[_indexToSwap].transform.DOMoveX(16, 0.5f).SetEase(Ease.InSine).OnComplete(()=>LikeCompleted(transform));
        levels[_indexToSwap].transform.DOMoveY(10, 0.4f).SetEase(Ease.InCirc);
        levels[_indexToSwap].transform.DORotate(new Vector3(0, 0, 60), 1f);

        // choose this level
    }

	private void LikeCompleted(Transform t)
	{
		print("load level: "+levels[_indexToSwap].levelName);

        transform.position = t.position;
        transform.rotation = t.rotation;
        locked = false;
    }

	private void Disliked()
	{
		print("disliked");

		DOTween.CompleteAll(true);

        locked = true;

        levels[_indexToSwap].transform.SetAsFirstSibling();
        levels[_indexToSwap].transform.DOMoveX(-16, 0.5f).SetEase(Ease.InSine).OnComplete(()=>DislikeCompleted(transform));
        levels[_indexToSwap].transform.DOMoveY(10, 0.4f).SetEase(Ease.InCirc);
        levels[_indexToSwap].transform.DORotate(new Vector3(0, 0, -60), 1f);


        //next frame
    }

	private void DislikeCompleted(Transform t)
	{
        print("dislikecompl");
        _indexToSwap--;
		if (_indexToSwap == -1)
		{
            _indexToSwap = 3;
        }
        transform.position = t.position;
        transform.rotation = t.rotation;
        locked = false;
	}
}
