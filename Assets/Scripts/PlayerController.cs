using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;
	public GameObject projectile;
	public float projectileSpeed;

	float fireRate = 0.5f;
	float nextFire = 0f;
	PlayerObjects playerObjects;
	Animator anim;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		playerObjects = GetComponent<PlayerObjects>();
		anim = GetComponent<Animator>();
	}

	void FixedUpdate() {
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");
		Vector2 targetVelocity = new Vector2(inputX, inputY) * speed;
		rb.velocity = IsometricUtils.IsoFrom2D(targetVelocity);
		anim.SetFloat("speed", rb.velocity.magnitude);

		if (inputX > 0 && inputY > 0) {
			anim.SetInteger("dir", 0);
		} else if (inputX > 0 && inputY < 0) {
			anim.SetInteger("dir", 1);
		} else if (inputX < 0 && inputY > 0) {
			anim.SetInteger("dir", 3);
		} else if (inputX < 0 && inputY < 0) {
			anim.SetInteger("dir", 2);
		} else if (inputY > 0) {
			anim.SetInteger("dir", 3);
		} else if (inputY < 0) {
			anim.SetInteger("dir", 1);
		} else if (inputX > 0f) {
			anim.SetInteger("dir", 0);
		} else if (inputX < 0f) {
			anim.SetInteger("dir", 2);
		}

		if (Input.GetMouseButtonDown(0) && playerObjects.CanShoot()) {
			ShootItem();
		}
	}

	void ShootItem() {
		var now = Time.time;
		if (now > nextFire) {
			nextFire = now + fireRate;

			Vector3 clickPos = GetClickPos();
			Vector2 directionVec = (clickPos - transform.position).normalized;
			var sh = playerObjects.Shoot();
			if (sh == -1) return;
			GameObject projInstance = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
			projInstance.GetComponent<SpriteController>().SetSprite(sh);
			projInstance.GetComponent<Rigidbody2D>().AddForce(directionVec * projectileSpeed, ForceMode2D.Impulse);
		}
	}

	Vector3 GetClickPos() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		return ray.origin + (ray.direction * 10);
	}
}
