/**
 *
 * Copyright (c) SEIKO EPSON CORPORATION 2016 - 2017. All rights reserved.
 *
 */
using UnityEngine;
using System.Collections;
#if UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif

public class SceneSwitcher : MonoBehaviour 
{	
	public string previousScene;
	public string nextScene;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			Debug.Log(previousScene);
			#if UNITY_5_3_OR_NEWER
			SceneManager.LoadSceneAsync(previousScene, LoadSceneMode.Single);
			#else
			Application.LoadLevel(previousScene);
			#endif
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			Debug.Log(nextScene);
			#if UNITY_5_3_OR_NEWER
			SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Single);
			#else
			Application.LoadLevel(nextScene);
			#endif
		}
	}
}
