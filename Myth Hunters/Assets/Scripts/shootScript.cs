using UnityEngine;
using System.Collections;

public class shootScript : MonoBehaviour {
	public GameObject mainCamera;
	public GameObject firstPersonCamera;
	public GameObject crosshair;
	[SerializeField]
	private Camera _camera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire2")) {
			mainCamera.SetActive (false);
			firstPersonCamera.SetActive (true);
			GetComponent<relativeMovement>().enabled = false;
			GetComponent<move>().enabled = true;
			GetComponent<mouseLookX>().enabled = true;
			crosshair.SetActive (true);
			if (Input.GetButton ("Fire1")) {
				Vector3 point = new Vector3 (_camera.pixelWidth/2, _camera.pixelHeight/2,0);
				Ray ray = _camera.ScreenPointToRay(point);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit)) {
					Debug.Log("Hit " + hit.point);
				}
			}
		} else {
			mainCamera.SetActive(true);
			firstPersonCamera.SetActive(false);
			GetComponent<relativeMovement>().enabled = true;
			GetComponent<move>().enabled = false;
			GetComponent<mouseLookX>().enabled = false;
			crosshair.SetActive (false);
		}
	}


}
