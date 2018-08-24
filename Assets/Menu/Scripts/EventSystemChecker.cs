using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EventSystemChecker : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static public void InitSceneCallback()
    {
        SceneManager.sceneLoaded += SceneWasLoaded;
    }

    static public void SceneWasLoaded(Scene scene, LoadSceneMode mode)
	{
		if(!FindObjectOfType<EventSystem>())
		{
			GameObject obj = new GameObject("EventSystem");

			obj.AddComponent<EventSystem>();
			obj.AddComponent<StandaloneInputModule>().forceModuleActive = true;
		}
	}
}
