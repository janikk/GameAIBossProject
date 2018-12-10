using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoming : MonoBehaviour {

	public bool isBoss;
	public GameObject target;
	public float speed;

	Vector3 dir;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		if (isBoss)
		{
			target = GameObject.Find("Character");
		}
		else
		{
			target = GameObject.Find("Boss");
		}
	}
	
	// Update is called once per frame
	void Update () {
		dir = (target.transform.position - transform.position).normalized;
		rb.velocity = new Vector2(dir.x * speed, dir.y * speed);
	}
}
