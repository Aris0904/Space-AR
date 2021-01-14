/**
 *
 * Copyright (c) SEIKO EPSON CORPORATION 2016 - 2017. All rights reserved.
 *
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using MoverioARScript;

/// <summary>
/// Image tracking handler. Updates the UI based on what images are recognized.
/// </summary>
public class ImageTrackingHandler : MonoBehaviour {

	public GameObject[] TrackingTargets;
	
	public Text UIText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (MoverioARSDK.Instance == null || TrackingTargets == null || TrackingTargets.Length == 0) {
			return;
		}
		string recognitionTextResult = "";

		foreach (GameObject target in TrackingTargets) {
			TrackingLoader loader = target.GetComponent<TrackingLoader> ();
			if (loader != null && MoverioARSDK.Instance.IsTracking(loader)) {
				recognitionTextResult += "Image ID " + loader.GetObjectName() + " is recognized.\r\n";
			}
		}

		UIText.text = recognitionTextResult;
			
	}
}
