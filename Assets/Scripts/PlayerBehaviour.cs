using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField]
    private float speed = 5;
    private float horizontalInput;
    private float verticalInput;

    [SerializeField]
    private float xMax = 8.2f;
    [SerializeField]
    private float yMax = 4.1f;

    [SerializeField]
    private GameObject laserPrefab = null;

	[SerializeField]
	private float fireRate = 0.25f;
	private float nextFire = 0.0f;

	public bool canTripleShot = false;
    
    void Start() {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update() {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space)) {
			Shoot();

		}
	}

	private void Shoot() {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(laserPrefab, transform.position + new Vector3(0, 0.8f), Quaternion.identity);

			if (canTripleShot) {
				Instantiate(laserPrefab, transform.position + new Vector3(-0.55f, -0.03f), Quaternion.identity);
				Instantiate(laserPrefab, transform.position + new Vector3(0.55f, -0.03f), Quaternion.identity);
			}
		}
	}

	private void Movement() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

        if (transform.position.x >= xMax) {
            transform.position = new Vector3(-xMax, transform.position.y);
        } else if (transform.position.x <= -xMax) {
            transform.position = new Vector3(xMax, transform.position.y);
        } else if (transform.position.y >= yMax) {
            transform.position = new Vector3(transform.position.x, -yMax);
        } else if (transform.position.y <= -yMax) {
            transform.position = new Vector3(transform.position.x, yMax);
        }
    }
}
