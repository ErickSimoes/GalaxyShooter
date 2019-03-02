using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour {

	private float speed = 3f;

    void Start() {
        
    }

    void Update() {
		transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

	private void OnTriggerEnter2D(Collider2D collision) {

		if (collision.tag == "Player") {
			collision.GetComponent<PlayerBehaviour>().canTripleShot = true;
		}

		Destroy(this.gameObject);

	}
}
