using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public int LovePoints = 0;

	public int LovePointsToNextLevel = 10;

	bool levelEnded = false;

	public Transform fadeToBlack;

	void Awake ()
	{
		if (Instance != null) {
			Debug.LogError ("Gamemanager already exists");
		} else {
			Instance = this;
		}
	}

	public void AddLovePoints (int points)
	{
		LovePoints += points;
		if (LovePoints > LovePointsToNextLevel) {
			fadeToBlack.gameObject.SetActive (true);
			StartCoroutine (DelayLoadLevel ());
		}
	}

	IEnumerator DelayLoadLevel ()
	{
		yield return new WaitForSeconds (5);
		Application.LoadLevel (Application.loadedLevel - 1);//to replaced later
	}
}
