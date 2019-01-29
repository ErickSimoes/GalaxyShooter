using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    private float horizontalInput;
    private float verticalInput;

    public float xMax;
    public float yMax;
    
    void Start() {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update() {
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
