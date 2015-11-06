using UnityEngine;
using System.Collections;

[RequireComponent(typeof(reactiveTarget))]
public class peacefulAI : MonoBehaviour {
	
	public float walkSpeed = 5.0f;
	public float currentSpeed = 5.0f;
	public float runSpeed = 10.0f;
	public float obstacleRange = 0.5f;
	private float attackCooldown = 1.5f;
	public float currentAttackCooldown = 1.5f;
	public Transform playerTransform;
	private GameObject playerCol;
	private reactiveTarget rT;
	private Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, currentSpeed * Time.deltaTime);
		
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		// Check for collisions
		if (Physics.SphereCast (ray, 0.75f, out hit)) {
			if (hit.distance < obstacleRange) {
				float angle = Random.Range (-110, 110);
				transform.Rotate(0, angle, 0);
			}
		}

		rT = GetComponent<reactiveTarget> ();
		if (rT.currentHp < 100) {
			currentSpeed = runSpeed;
			Debug.Log(currentSpeed + " Speed der ");
		}
		
		currentAttackCooldown -= Time.deltaTime;
	}
	
	void FixedUpdate () {
		if (Vector3.Distance (this.playerTransform.position , this.transform.position) < 15) {
			anim.SetFloat("Speed", runSpeed);
			currentSpeed = runSpeed;
			Debug.Log("Running");
		}

		if (Vector3.Distance (this.playerTransform.position , this.transform.position) > 25) {
			anim.SetFloat("Speed", walkSpeed);
			currentSpeed = walkSpeed;
			Debug.Log("Walkin'");
		}
	}
	

	
}
