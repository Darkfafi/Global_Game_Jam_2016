using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TinderUI : MonoBehaviour
{
    public List<LevelName> levels = new List<LevelName>();
    public Button likeButton;
    public Button dislikeButton;

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
		print("load level: "+levels[_indexToSwap].levelName);

		// choose this level
    }

	private void Disliked()
	{
		print("disliked");
        levels[_indexToSwap].transform.SetAsFirstSibling();
        _indexToSwap--;
		if (_indexToSwap == -1)
		{
            _indexToSwap = 3;
        }

		//next frame
	}
}
