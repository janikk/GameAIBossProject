using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNormal : MonoBehaviour {

	public bool isBoss;
	public float speed;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		if (isBoss)
		{
			if (GameObject.Find("Character").transform.localScale.x > transform.localScale.x){
				rb.velocity = Vector2.right * speed;
			}
			else{
				rb.velocity = Vector2.left * speed;
			}
		}
		else
		{	
			if (GameObject.Find("Character").GetComponent<movement>().right){
				rb.velocity = Vector2.right * speed;
			}
			else{
				rb.velocity = Vector2.left * speed;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
