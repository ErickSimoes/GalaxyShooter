using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour {

	private float speed = 3f;
	private enum PowerupType {TripleShot, Speed, Shield };
	[SerializeField]
	private PowerupType type;

    void Start() {
        
    }

    void Update() {
		transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

	private void OnTriggerEnter2D(Collider2D collision) {

		if (collision.tag == "Player") {

			switch (type) {
				case PowerupType.TripleShot:
					collision.GetComponent<PlayerBehaviour>().TripleShotPowerOn();
					break;
				case PowerupType.Speed:
					collision.GetComponent<PlayerBehaviour>().SpeedPowerOn();
					break;
				case PowerupType.Shield:
					break;
				default:
					break;
			}
			
		}

		Destroy(this.gameObject);

	}
}
