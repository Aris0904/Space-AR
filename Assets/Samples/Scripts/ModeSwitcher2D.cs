/**
 *
 * Copyright (c) SEIKO EPSON CORPORATION 2016 - 2018. All rights reserved.
 *
 */
using MoverioARInfrastructure.Type;
using MoverioARScript;
using UnityEngine;
using UnityEngine.UI;

public class ModeSwitcher2D : MonoBehaviour {

	public GameObject MoverioARCamera;
	private CameraController cameraController = null;

	public Button resetButton;
	public UnityEngine.EventSystems.EventSystem eventSystem;

	// Use this for initialization
	void Start () {
		if(resetButton !=null && eventSystem != null) eventSystem.SetSelectedGameObject (resetButton.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (MoverioARSDK.Instance == null) {
			return;
		}

		if(cameraController == null)
		{
			cameraController = MoverioARCamera.GetComponent<CameraController> ();
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) && cameraController.DisplayMode != DisplayMode.MODE_3D_WITHOUT_NOTIFICATION)
		{
			cameraController.DisplayMode = MoverioARSDK.Instance.SetDisplayMode(DisplayMode.MODE_3D_WITHOUT_NOTIFICATION);
			if (resetButton != null) resetButton.image.rectTransform.localScale = new Vector3(resetButton.image.rectTransform.localScale.x / 2, resetButton.image.rectTransform.localScale.y, resetButton.image.rectTransform.localScale.z);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow) && cameraController.DisplayMode != DisplayMode.MODE_2D_WITHOUT_NOTIFICATION)
		{
			cameraController.DisplayMode = MoverioARSDK.Instance.SetDisplayMode(DisplayMode.MODE_2D_WITHOUT_NOTIFICATION);
			if (resetButton != null) resetButton.image.rectTransform.localScale = new Vector3(resetButton.image.rectTransform.localScale.x * 2, resetButton.image.rectTransform.localScale.y, resetButton.image.rectTransform.localScale.z);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) { Application.Quit (); }
	}
}
