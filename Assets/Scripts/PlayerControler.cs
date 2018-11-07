using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour {

	public float speed = 8f;
 	public float jumpPower = 4f;
	public bool grounded;
	public bool dead;
	public AudioClip jumpSound;
	public Text winText;
    public Text loseText;
	
	private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;
    private SpriteRenderer spr;
	private AudioSource fuenteAudio;
	
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
		fuenteAudio = GetComponent<AudioSource>();
		winText.text = "";
		loseText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
		anim.SetBool("Dead", dead);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded){
        	jump = true;
			fuenteAudio.clip = jumpSound;
			fuenteAudio.Play();
        }
	}

	void FixedUpdate () {
		float h = Input.GetAxis("Horizontal");
		Vector2 movement = new Vector2(h, 0f);
		rb2d.AddForce(movement * speed);

        if(h < 0){
        	spr.flipX = true;
        }else if(h > 0){
        	spr.flipX = false;
        }

        if (jump){
        	rb2d.AddForce(Vector2.up * jumpPower,ForceMode2D.Impulse);
        	jump = false;
        }
	}

	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag == "Ground"){
			grounded=true;
		}
		if (col.gameObject.tag == "Tuberia"){
			grounded=true;
		}
		if (col.gameObject.tag == "Cuadrado"){
			grounded=true;
		}
		if (col.gameObject.tag == "Puerta"){
			this.gameObject.SetActive (false);
			winText.text = "You Win!";
		}
		if (col.gameObject.tag == "Seta"){
			dead=true;
			loseText.text = "GAME OVER!!!!!";
		}
		if (col.gameObject.tag == "Vacio"){
			dead=true;
			loseText.text = "GAME OVER!!!!!";
		}
	}

	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "Ground"){
			grounded=false;
		}
	}
}
