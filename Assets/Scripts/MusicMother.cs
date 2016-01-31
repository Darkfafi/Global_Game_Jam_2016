using UnityEngine;
using System.Collections;

public class MusicMother : MonoBehaviour {
    public AudioClip musicTheme;
    public AudioClip musicMating;

	public static MusicMother Instance { get; private set; }

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
    }

	public void PlayTheme()
	{
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = musicTheme;
        GetComponent<AudioSource>().Play();
    }

	public void PlayMating()
	{
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = musicMating;
        GetComponent<AudioSource>().Play();
	}
}
