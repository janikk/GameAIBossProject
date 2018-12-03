using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shooting : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject homingPrefab;

    private Vector2 PlayerCoords;
	// Use this for initialization
	void Start () {
        PlayerCoords = new Vector2(transform.localPosition.x, transform.localPosition.y);
    }

	void Fire()
	{
       // Vector2 mouse = new Vector2(transform.localPosition.x, transform.localPosition.y); //Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
				bulletPrefab,
				PlayerCoords,
				Quaternion.identity);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 65;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}

	void FireHoming()
	{
		//Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
				homingPrefab,
				PlayerCoords,
				Quaternion.identity);

		// Add velocity to the bullet

		Destroy(bullet, 2.0f);
		// Destroy the bullet after 2 seconds
	}

	// Update is called once per frame
	void Update () {
        PlayerCoords = new Vector2(transform.localPosition.x, transform.localPosition.y);
        if (Input.GetMouseButtonDown(0))
		{
			Fire();
		}
		else if (Input.GetMouseButtonDown(1))
		{
			FireHoming();
		}
	}
}
