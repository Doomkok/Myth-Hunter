using UnityEngine;
using System.Collections;

[RequireComponent(typeof(reactiveTarget))]
public class defensiveAI : MonoBehaviour {
	
	public float walkSpeed = 5.0f;
	public float currentSpeed = 5.0f;
	public float runSpeed = 10.0f;
	public float obstacleRange = 0.5f;
	private float attackCooldown = 1.5f;
	public float currentAttackCooldown = 1.5f;
	private Transform playerTransform;
	private GameObject playerCol;
	private reactiveTarget rT;
	
	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag ("Player").gameObject.transform;
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

		}

		currentAttackCooldown -= Time.deltaTime;
	}

	void FixedUpdate () {
		if (Vector3.Distance (this.playerTransform.position , this.transform.position) < 30) {
			transform.LookAt(new Vector3 (this.playerTransform.position.x, this.transform.position.y, this.playerTransform.position.z));
		}
		if (Vector3.Distance (this.playerTransform.position, this.transform.position) < 10) {
			GetComponent<Rigidbody> ().AddForce( this.transform.forward * runSpeed);
			if (Vector3.Distance(this.playerTransform.position, this.transform.position) > 2) { 
				GetComponent<Rigidbody>().velocity = Vector3.zero;
				GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
				//anim.Play ("run");
			}
		}
		if (Vector3.Distance (this.playerTransform.position, this.transform.position) < 3) {
			//anim.Play ("Attack");
			if (currentAttackCooldown < 0) {
			Attack();
			}
		}
//		if (Vector3.Distance (this.playerTransform.position, this.transform.position) < 2) {
//			GetComponent<Rigidbody>().velocity = Vector3.zero;
//			GetComponent<Rigidbody>().angularVelocity = Vector3.zero; 
//		}
	
	
	}

	void Attack() {
			playerTransform.gameObject.GetComponent<PlayerStats> ().currentHealth -= 25;
			currentAttackCooldown = attackCooldown;
	}

}
