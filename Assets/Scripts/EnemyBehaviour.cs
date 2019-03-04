﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	[SerializeField]
	private float speed = 0.8f;
	private float xMax = 8f;
	private float yMax = 6f;
	private float xRandom;

	void Start() {
        
    }

    void Update() {

		transform.Translate(Vector3.down * speed * Time.deltaTime);

		if (transform.position.y <= -yMax) {
			xRandom = Random.Range(-xMax, xMax);
			transform.position = new Vector3(xRandom, yMax);
		}
		
    }
}
