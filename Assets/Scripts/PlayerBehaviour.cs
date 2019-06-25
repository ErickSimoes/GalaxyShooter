using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
	private GameObject shieldPrefab;

	[SerializeField]
	private float fireRate = 0.25f;
	private float nextFire = 0.0f;
	
	private float powerupTime = 5.0f;
	private bool canTripleShot = false;
	private bool canSpeed = false;

	private int lifes = 3;
	public int score = 0;
	public Text scoreText;

	[SerializeField]
	private GameObject explosionPrefab;

	void Start() {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update() {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space)) {
			Shoot();
		}

		if (lifes < 1) {
			GameObject explosionClone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			explosionClone.GetComponent<ExplosionBehaviour>().gameObject2Destroy = this.gameObject;
			GetComponent<SpriteRenderer>().enabled = false;
			StartCoroutine(GoToGameOverScene());
		}

		scoreText.text = score.ToString();
	}

	IEnumerator GoToGameOverScene() {
		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene("GameOver");
	}

	private void Shoot() {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject laser1 = Instantiate(laserPrefab, transform.position + new Vector3(0, 0.8f), Quaternion.identity);
			laser1.GetComponent<LaserBehaviour>().player = this.gameObject;
			if (canTripleShot) {
				GameObject laser2 = Instantiate(laserPrefab, transform.position + new Vector3(-0.55f, -0.03f), Quaternion.identity);
				GameObject laser3 = Instantiate(laserPrefab, transform.position + new Vector3(0.55f, -0.03f), Quaternion.identity);

				laser2.GetComponent<LaserBehaviour>().player = this.gameObject;
				laser3.GetComponent<LaserBehaviour>().player = this.gameObject;
			}
		}
	}

	private void Movement() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

		if (canSpeed) {
			transform.Translate(Vector3.right * (speed + 7f) * horizontalInput * Time.deltaTime);
			transform.Translate(Vector3.up * (speed + 7f) * verticalInput * Time.deltaTime);
		} else {
			transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
			transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
		}

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

	public void Hit() {
		lifes--;
		Debug.Log("Lifes: " + lifes);
	}

	public void TripleShotPowerOn() {
		canTripleShot = true;
		StartCoroutine(TripleShotPowerDownRoutine());
	}

	public void SpeedPowerOn() {
		canSpeed = true;
		StartCoroutine(SpeedPowerDownRoutine());
	}

	public void ShieldPowerupOn() {
		Instantiate(shieldPrefab, transform.position, Quaternion.identity, transform);
	}

	IEnumerator TripleShotPowerDownRoutine() {
		yield return new WaitForSeconds(powerupTime);
		canTripleShot = false;
	}

	IEnumerator SpeedPowerDownRoutine() {
		yield return new WaitForSeconds(powerupTime);
		canSpeed = false;
	}
}
