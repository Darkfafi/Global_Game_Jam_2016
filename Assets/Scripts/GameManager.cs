using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public int LovePoints = 0;

	public int LovePointsToNextLevel = 10;

	bool levelEnded = false;

	public Transform fadeToBlack;

	public Transform loveFX;

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
			StartCoroutine (DelayLoadLevel ());
		}
	}

	IEnumerator DelayLoadLevel ()
	{
		loveFX.gameObject.SetActive (true);
		yield return new WaitForSeconds (2);
		fadeToBlack.gameObject.SetActive (true);
		yield return new WaitForSeconds (5);
		Application.LoadLevel (Application.loadedLevel - 1);//to replaced later
	}
}
