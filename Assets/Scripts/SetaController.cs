using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaController : MonoBehaviour {

	public float speed = 8f;
	public bool grounded = true;
	
	private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer spr;
	
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
	}
	
	void FixedUpdate () {
		//Vector2 movement1 = new Vector2(0.5f, 0f);
		Vector2 movement1 = new Vector2(-0.5f, 0f);
		rb2d.AddForce(movement1 * speed); 
	}
	
	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag == "Tuberia"){
			Vector2 movement2 = new Vector2(0.5f, 0f);
			rb2d.AddForce(movement2 * speed); 
		}
		if (col.gameObject.tag == "Vacio"){
			this.gameObject.SetActive (false);
		}
	}
}
