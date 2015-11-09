using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject jackalopePrefab;
	private GameObject _enemy;
	public Transform[] respawnPoints;

	void Update() {
		if (_enemy == null) {
			_enemy = Instantiate(jackalopePrefab) as GameObject;
			_enemy.transform.position = respawnPoints[Random.Range(0, respawnPoints.Length)].transform.position;
			float angle = Random.Range(0, 360);
			_enemy.transform.Rotate(0, angle, 0);
		}
	}

}