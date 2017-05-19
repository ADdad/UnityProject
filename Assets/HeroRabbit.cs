using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRabbit : MonoBehaviour {


	public float speed = 1;

	Rigidbody2D myBody = null;
	

	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D> ();
		LevelController.current.setStartPosition(transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		float value = Input.GetAxis ("Horizontal");

		Animator animator = GetComponent<Animator>();
		if(Mathf.Abs(value)>0)animator.SetBool("run",true);
		else animator.SetBool("run", false);
	}

	void FixedUpdate () {
		
		float value = Input.GetAxis ("Horizontal");
		
		SpriteRenderer sr = GetComponent<SpriteRenderer>();

		if (value<0) sr.flipX = true;
		else if (value>0) sr.flipX = false;

		if (Mathf.Abs (value) > 0) {
			Vector2 vel = myBody.velocity;
			vel.x = value * speed;
			myBody.velocity = vel;
		}

		Vector3 from = transform.position+Vector3.up*0.3f;
		Vector3 to = transform.position+Vector3.down * 0.1f;
		int layer_id = 1 << LayerMask.NameToLayer("Ground");

		RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);

		if(hit) {
			isGrounded = true;
		}
		else isGrounded = false;

		Debug.DrawLine(from, to, Color.red);


	}
}
 