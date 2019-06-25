using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour {

	[SerializeField]
	private float speed = 10;
	public GameObject player;
    
    void Start() {

    }

    void Update() {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y >= 6) {
            Destroy(gameObject);
        }
    }

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Enemy") {
			player.GetComponent<PlayerBehaviour>().score++;
		}
	}
}
