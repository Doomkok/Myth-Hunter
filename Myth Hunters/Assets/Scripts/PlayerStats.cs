using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	[SerializeField]
	private int maxHealth = 100;
	public int currentHealth;
	[SerializeField]
	private GameObject HealthUI;


	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}

	void OnGUI () {
		HealthUI.GetComponent<Text> ().text = "Health: " + currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
		HealthUI.GetComponent<Text> ().text = "Health: " + currentHealth;
	}

	void takeDamage (int damage) {
		currentHealth -= damage;
		if (currentHealth < 0) {
			//die();
		}
	}
}
