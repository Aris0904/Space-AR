using UnityEngine;
using System.Collections;

public class CameraFacingController : MonoBehaviour {

	public Camera FacingCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform textLookAt = FacingCamera.transform;
		textLookAt.rotation = Quaternion.identity;
		transform.LookAt(textLookAt);
	}
}
