using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float speed;
    private float horizontalInput;
    private float verticalInput;

    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMax;

    [SerializeField]
    private GameObject laserPrefab;

	public float fireRate = 0.25f;
	private float nextFire = 0.0f;
    
    void Start() {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update() {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
            Instantiate(laserPrefab, transform.position + new Vector3(0, 0.8f), Quaternion.identity);
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
