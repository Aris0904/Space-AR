/**
 *
 * Copyright (c) SEIKO EPSON CORPORATION 2016 - 2017. All rights reserved.
 *
 */
using MoverioARInfrastructure.Type;
using MoverioARScript;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Mode switcher. Switch (enable/disable) render models in Tracking mode and Not tracking mode
/// </summary>
public class ModeSwitcher : MonoBehaviour {

	public GameObject MoverioARCamera;

	public GameObject GuidanceModels;
	private bool initialGuidanceModelsActiveState;

	public GameObject TrackingTarget;

	private CameraController cameraController = null;

	public string guidancePoseFile;

	public GameObject GuidanceImage;
	private bool initialGuidanceImageActiveState;

	public GameObject GuidanceImage3D;
	private bool initialGuidanceImage3DActiveState;


	public Button resetButton;
	public UnityEngine.EventSystems.EventSystem eventSystem;

	TrackingLoader target = null;

	// Use this for initialization
	void Start () {
		initialGuidanceModelsActiveState = GuidanceModels.activeInHierarchy;
		initialGuidanceImage3DActiveState = GuidanceImage3D.activeInHierarchy;
		initialGuidanceImageActiveState = GuidanceImage.activeInHierarchy;
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
			MoverioARSDK.Instance.LoadGuidancePoseMatrix (guidancePoseFile, GuidanceModels);
		}

		if (target == null)
			target = TrackingTarget.GetComponent<TrackingLoader> ();
		
		if (target != null && MoverioARSDK.Instance.IsTracking (target)) {
			GuidanceImage.SetActive (false);
			GuidanceImage3D.SetActive (false);
			GuidanceModels.SetActive (false);
		} else {
			MoverioARSDK.Instance.ApplyGuidancePose (GuidanceModels);
			if (cameraController.DisplayMode == DisplayMode.MODE_2D_WITHOUT_NOTIFICATION) {
				if(initialGuidanceModelsActiveState) GuidanceModels.SetActive (true);
				if(initialGuidanceImageActiveState) GuidanceImage.SetActive (true);
				if(initialGuidanceImage3DActiveState) GuidanceImage3D.SetActive (false);
			} else {
				if(initialGuidanceModelsActiveState) GuidanceModels.SetActive (false);
				if(initialGuidanceImageActiveState) GuidanceImage.SetActive (false);
				if(initialGuidanceImage3DActiveState) GuidanceImage3D.SetActive (true);
			}
		}
			
		if (Input.GetKeyDown(KeyCode.UpArrow) && cameraController.DisplayMode != DisplayMode.MODE_3D_WITHOUT_NOTIFICATION)
		{
			cameraController.DisplayMode = MoverioARSDK.Instance.SetDisplayMode (DisplayMode.MODE_3D_WITHOUT_NOTIFICATION);
			if(resetButton !=null) resetButton.image.rectTransform.localScale = new Vector3 (resetButton.image.rectTransform.localScale.x / 2, resetButton.image.rectTransform.localScale.y, resetButton.image.rectTransform.localScale.z);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow) && cameraController.DisplayMode != DisplayMode.MODE_2D_WITHOUT_NOTIFICATION)
		{
			cameraController.DisplayMode = MoverioARSDK.Instance.SetDisplayMode (DisplayMode.MODE_2D_WITHOUT_NOTIFICATION);
			if(resetButton !=null) resetButton.image.rectTransform.localScale = new Vector3 (resetButton.image.rectTransform.localScale.x * 2, resetButton.image.rectTransform.localScale.y, resetButton.image.rectTransform.localScale.z);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) { Application.Quit (); }
	}
}
