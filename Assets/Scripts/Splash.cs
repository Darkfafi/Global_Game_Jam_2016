using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Splash : MonoBehaviour {
    public GameObject splash;
    public GameObject bg;

    private Vector3 scale;


    // Use this for initialization
    void Start ()
	{
        scale = splash.transform.localScale;
        splash.transform.DOScale(Vector3.zero, 0f);
        splash.transform.DOScale(scale, 0.3f).SetDelay(0.5f).SetEase(Ease.InQuint);
        splash.transform.DOPunchScale(Vector3.one * 30, 0.2f, 10, 0.5f).SetDelay(0.8f);

        splash.transform.DOMove(splash.transform.position, 3f).OnComplete(GotoLevel);

        GetComponent<AudioSource>().Play();
    }

	private void GotoLevel()
	{
        Application.LoadLevel("StartMenu");
    }

	// Update is called once per frame
	void Update ()
	{

	}
}
