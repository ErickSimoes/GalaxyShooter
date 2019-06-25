using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	[SerializeField]
	private GameObject enemyPrefab;
	[SerializeField]
	private GameObject[] powerupsPrefab;

	private readonly float xMax = 8f;
	private readonly float yPos = 6.25f;

	void Start() {
		InvokeRepeating("InstantiateEnemy", 1f, 2f);
    }

    void Update() {
		
    }

	private void InstantiateEnemy() {
		Vector3 randomPosition = new Vector3(Random.Range(xMax, -xMax), yPos);
		Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
	}
}
