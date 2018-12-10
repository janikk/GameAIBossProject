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
	}
	
	// Update is called once per frame
	void Update () {
		if (isBoss)
		{
			rb.velocity = Vector2.left * speed;
		}
		else
		{
			rb.velocity = Vector2.right * speed;
		}
	}
}
