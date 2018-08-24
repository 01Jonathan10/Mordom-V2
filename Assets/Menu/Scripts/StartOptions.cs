using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class StartOptions : MonoBehaviour {

	public bool changeMusicOnStart=true;

	[HideInInspector] public bool inMainMenu = true;
	[HideInInspector] public Animator animColorFade;
	[HideInInspector] public Animator animMenuAlpha;
	public AnimationClip fadeColorAnimationClip;
	[HideInInspector] public AnimationClip fadeAlphaAnimationClip;

	private PlayMusic playMusic;
	private float fastFadeIn = .01f;
	private ShowPanels showPanels;
	
	void Awake()
	{
		showPanels = GetComponent<ShowPanels> ();
		playMusic = GetComponent<PlayMusic> ();
	}


	public void StartButtonClicked()
	{
		
		playMusic.FadeDown(fadeColorAnimationClip.length);
		Invoke ("LoadDelayed", fadeColorAnimationClip.length * .5f);
		animColorFade.SetTrigger ("fade");

	}

    void OnEnable()
    {
        SceneManager.sceneLoaded += SceneWasLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneWasLoaded;
    }

    void SceneWasLoaded(Scene scene, LoadSceneMode mode)
    {
		playMusic.PlayLevelMusic ();
	}


	public void LoadDelayed()
	{
		inMainMenu = false;
		showPanels.HideMenu ();
		SceneManager.LoadScene (1);
	}

	public void HideDelayed()
	{
		showPanels.HideMenu();
	}

	public void PlayNewMusic()
	{
		playMusic.FadeUp (fastFadeIn);
		playMusic.PlaySelectedMusic (1);
	}
}
