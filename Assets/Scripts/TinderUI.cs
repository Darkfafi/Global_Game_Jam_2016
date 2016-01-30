using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class TinderUI : MonoBehaviour
{
    public List<LevelName> levels = new List<LevelName>();
    public List<GameObject> backgrounds = new List<GameObject>();
    public Button likeButton;
    public Button dislikeButton;

    private Vector3 pos;
    private Quaternion rot;


    private int _indexToSwap = 3;

    private Sequence likeSequence;
    private Sequence dislikeSequence;

    // Use this for initialization
    void Start()
    {
        likeButton.onClick.AddListener(() => Liked());
        dislikeButton.onClick.AddListener(() => Disliked());

        pos = levels[_indexToSwap].transform.position;
        rot = levels[_indexToSwap].transform.rotation;
        //todo make work
    }

    void Update()
    {
        if (InputManager.Instance.GetAButton())
        {
            Liked();
        }

        if (InputManager.Instance.GetBButton())
        {
            Disliked();
        }
    }


    private void Liked()
    {
        DOTween.CompleteAll(true);

        levels[_indexToSwap].transform.DOMoveX(16, 0.5f).SetEase(Ease.InSine).OnComplete(LikeCompleted);
        levels[_indexToSwap].transform.DOMoveY(10, 0.4f).SetEase(Ease.InCirc);
        levels[_indexToSwap].transform.DORotate(new Vector3(0, 0, 40), 0.45f);
        backgrounds[_indexToSwap].transform.DOScale(transform.localScale * 1.1f, 0.5f).SetEase(Ease.OutCubic);

		for (int i = 0; i < levels.Count; i++)
        {

            if (i != _indexToSwap)
            {
                //Destroy(levels[i].gameObject);
				// Not so pretty for juicyness
            }
        }

        // choose this level
    }

    private void LikeCompleted()
    {
        print("load level: " + levels[_indexToSwap].levelName);
        Application.LoadLevel(levels[_indexToSwap].levelName);

        // TODO what if level to load does not exist?
    }

    private void Disliked()
    {

        print("disliked");

        DOTween.CompleteAll(true);

        levels[_indexToSwap].transform.DOMoveX(-16, 0.5f).SetEase(Ease.InSine).OnComplete(DislikeCompleted);
        levels[_indexToSwap].transform.DOMoveY(10, 0.4f).SetEase(Ease.InCirc);
        levels[_indexToSwap].transform.DORotate(new Vector3(0, 0, -40), 0.45f);

        backgrounds[_indexToSwap].transform.SetAsFirstSibling();


        //next frame
    }

    private void DislikeCompleted()
    {

        print("dislikecompl");
        levels[_indexToSwap].transform.SetAsFirstSibling();

        levels[_indexToSwap].transform.position = pos;
        levels[_indexToSwap].transform.rotation = rot;


        _indexToSwap--;
        if (_indexToSwap == -1)
        {
            _indexToSwap = levels.Count - 1;
        }
    }
}
