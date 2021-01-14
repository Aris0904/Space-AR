using MoverioARInfrastructure.Type;
using MoverioARScript;
using UnityEngine;

public class TextEffectHandler : MonoBehaviour {

	public GameObject MoverioARCamera;

	public Vector3 ScaleIn3DMode = new Vector3(0.75f, 0.75f, 0.75f);
	public Vector3 ScaleIn2DMode = new Vector3(1.5f, 1.5f, 1.5f);

	public Vector3 PositionIn3DMode = new Vector3(0f, 50.0f, 50.0f);
	public Vector3 PositionIn2DMode = new Vector3(0f, 55.0f, 55.0f);

	private CameraController cameraController = null;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (cameraController == null) 
		{
			cameraController = MoverioARCamera.GetComponent<CameraController> ();
		} 
		else 
		{
			if (cameraController.DisplayMode == DisplayMode.MODE_3D_WITHOUT_NOTIFICATION) {
				this.transform.localScale = ScaleIn3DMode;
			} else {
				this.transform.localScale = ScaleIn2DMode;
			}
		}

	}
}
