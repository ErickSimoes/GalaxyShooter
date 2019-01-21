using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    private float horizontalInput;
    
    void Start() {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update() {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
    }
}
