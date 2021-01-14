/**
 *
 * Copyright (c) SEIKO EPSON CORPORATION 2016 - 2017. All rights reserved.
 *
 */
using UnityEngine;
using System.Collections;

public class SirenFlasher : MonoBehaviour {

	public float flashingPeriod = 0.5f;

	private float elapse = 0.0f;

	public GameObject BlueSiren;
	public GameObject OrangeSiren;

	// Use this for initialization
	void Start () {
		BlueSiren.SetActive (true);
		OrangeSiren.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		elapse += Time.deltaTime;
		if (elapse > flashingPeriod) {
			BlueSiren.SetActive (!BlueSiren.activeSelf);
			OrangeSiren.SetActive (!OrangeSiren.activeSelf);
			elapse = 0;
		}
	}
}
