using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoming : MonoBehaviour {

	GameObject target;

	Vector3 dir;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Boss");
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		dir = (target.transform.position - transform.position).normalized;

		rb.velocity = new Vector2(dir.x * 65, dir.y * 65); 
	}
}
