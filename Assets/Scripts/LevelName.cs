using UnityEngine;
using System.Collections;

public class LevelName : MonoBehaviour {
    public string levelName;
    public GameObject like;
    public GameObject dislike;
    public GameObject mated;
    public GameObject rejected;

	public void MateOrReject(bool matedBool)
	{
		if (matedBool)
		{
            mated.SetActive(true);
        }
		else
		{
            rejected.SetActive(true);
		}
	}
}
