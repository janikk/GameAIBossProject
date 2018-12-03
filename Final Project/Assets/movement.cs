using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	private Rigidbody2D rb;
	public float JumpForce;
	public float Speed;
	public float Dash;

	private bool isGrounded;
	private bool isJumping;

	private Transform feet;
	private float JumpTimeCounter;

	public float JumpTime;
	public float Radius;
	public LayerMask Ground;

	private bool isDashing;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
		feet = transform.FindChild("Feet");
		isGrounded = true;
		isJumping = false;
		isDashing = true;
		JumpTimeCounter = JumpTime;
	}
	
	// Update is called once per frame
	void Update () {
		
		isGrounded = Physics2D.OverlapCircle(feet.position, Radius, Ground);
		if(isGrounded && Input.GetKeyDown(KeyCode.Space)){
			rb.velocity = Vector2.up * JumpForce;
			isJumping = true;
			JumpTimeCounter = JumpTime;
		}

		if(Input.GetKey(KeyCode.Space) && isJumping){
			if(JumpTimeCounter > 0){
				rb.velocity = Vector2.up * JumpForce;
				JumpTimeCounter -= Time.deltaTime;
			}else{
				isJumping = false;
			}
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			isJumping = false;
		}

	}
    private void FixedUpdate()
    {
        float movex = Input.GetAxis("Horizontal");
        //float movey = Input.GetAxis("Vertical");
        //GetComponent<Rigidbody2D>().velocity = new Vector2(movey * 10f, GetComponent<Rigidbody2D>().velocity.y);
		if(Input.GetKeyDown(KeyCode.LeftShift)){
			rb.velocity = new Vector2(movex * Speed * Dash, rb.velocity.y);
		}else{
			rb.velocity = new Vector2(movex * Speed, rb.velocity.y);
		}


    }
}
