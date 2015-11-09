using UnityEngine;
using System.Collections;

public class shootScript : MonoBehaviour {
	public GameObject mainCamera;
	public GameObject firstPersonCamera;
	public GameObject crosshair;
	[SerializeField]
	private Camera _RayCastcamera;
	public float fireRate = 2f;
	public int damage = 25;
	float cooldown = 0;
	public Transform gunFXPoint;
	public GameObject gunFX;
	
	// Use this for initialization
	void Start () {
		//Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		cooldown -= Time.deltaTime;
		
		if (Input.GetButton ("Fire2")) {
			mainCamera.SetActive (false);
			firstPersonCamera.SetActive (true);
			GetComponent<relativeMovement>().enabled = false;
			GetComponent<move>().enabled = true;
			GetComponent<mouseLookX>().enabled = true;
			crosshair.SetActive (true);
			
			if (Input.GetButton ("Fire1")) {
				if (cooldown < 0) {
					cooldown = fireRate;
					Instantiate(gunFX, gunFXPoint.position, gunFXPoint.rotation);
					Vector3 point = new Vector3 (_RayCastcamera.pixelWidth/2, _RayCastcamera.pixelHeight/2,0);
					Ray ray = _RayCastcamera.ScreenPointToRay(point);
					RaycastHit hit;
					if (Physics.Raycast(ray, out hit)) {
						GameObject hitObject = hit.transform.gameObject;
						reactiveTarget target = hitObject.GetComponent<reactiveTarget>();
						if (target != null) {
							target.ReactToHit(damage);
						} else {
							StartCoroutine(HitIndicator(hit.point));
						}
					}
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
	
	private IEnumerator HitIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.position = pos;
		
		yield return new WaitForSeconds (1);
		
		Destroy (sphere);
		
	}
	
	
}
