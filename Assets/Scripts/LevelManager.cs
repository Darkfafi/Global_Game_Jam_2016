using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public static LevelManager Instance { get; private set; }

    public int UnlockedLevel { get; private set; }
    private int _currentPlayedLevel = 0;

    // Initialisation
    void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        UnlockedLevel = 4;
		// TODO playerprefs
    }

    public void ChooseLevel(int level, int totalLevels)
	{
        int levelToCheck = totalLevels - level;
        if (!MayChooseLevel(level, totalLevels))
		{
            print("no match aka level locked: "+levelToCheck);
            return;
        }
        _currentPlayedLevel = levelToCheck;
        Application.LoadLevel("Level" + levelToCheck);
    }

    public bool MayChooseLevel(int level, int totalLevels)
    {
        int levelToCheck = totalLevels - level;
        if (levelToCheck > UnlockedLevel)
        {
            print("no match aka level locked: " + levelToCheck);
            return false;
        }
        return true;
    }

    // Call this when your level is completed!!
    public void LevelCompleted()
	{
		if (_currentPlayedLevel == 0)
		{
            Debug.LogError("Y U CALL THIS MOAR THAN ONE TIME");
            return;
        }
        UnlockedLevel++;
        _currentPlayedLevel = 0;
    }
}
