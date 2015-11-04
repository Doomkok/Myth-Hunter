using UnityEngine;
using System.Collections;

public class reactiveTarget : MonoBehaviour {

	public float maxHp = 100;
	public float currentHp;

	public void ReactToHit(int damage) {
		currentHp -= damage;
	}

	// Use this for initialization
	void Start () {
		currentHp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHp < 0) {
			Debug.Log("Wrecked");
			Destroy(gameObject);
		}
	
	}
}
