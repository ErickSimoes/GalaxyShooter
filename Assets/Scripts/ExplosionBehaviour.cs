using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour {

	private float wait = 0.5f;
	private Animator animator;
	public GameObject gameObject2Destroy;

	void Start() {
		animator = GetComponent<Animator>();
		StartCoroutine(DestroyGameObjectWithDelay());
    }

    void Update() {
		if (!AnimationIsPlaying()) {
			Destroy(this.gameObject);
		}
    }

	IEnumerator DestroyGameObjectWithDelay() {
		yield return new WaitForSeconds(wait);
		Destroy(gameObject2Destroy);
	}

	private bool AnimationIsPlaying() {
		return (animator.GetCurrentAnimatorStateInfo(0).length / animator.GetCurrentAnimatorStateInfo(0).speed) > animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
	}
}
