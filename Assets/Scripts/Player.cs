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
    
    void Start() {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update() {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(laserPrefab, transform.position, Quaternion.identity);
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
