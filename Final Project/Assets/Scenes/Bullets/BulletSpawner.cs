using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletSpawner: MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject homingPrefab;
	public GameObject splitPrefab;

  private Vector2 PlayerCoords;
	// Use this for initialization
	void Start () {
		PlayerCoords = new Vector2(transform.localPosition.x - 2, transform.localPosition.y);
    }

	void FireNormal()
	{
    // Vector2 mouse = new Vector2(transform.localPosition.x, transform.localPosition.y); //Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
				bulletPrefab,
				PlayerCoords,
				Quaternion.identity);

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 10.0f);
	}
/*
	void FireHoming()
	{
		//Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
				homingPrefab,
				PlayerCoords,
				Quaternion.identity);


		Destroy(bullet, 10.0f);
		// Destroy the bullet after 2 seconds
	}

	void FireSplit()
	{
		//Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
				splitPrefab,
				PlayerCoords,
				Quaternion.identity);


		Destroy(bullet, 10.0f);
		// Destroy the bullet after 2 seconds
	}
	*/

	// Update is called once per frame
	void Update () {
		PlayerCoords = new Vector2(transform.localPosition.x, transform.localPosition.y);
		if (Input.GetMouseButtonDown(0))
		{
			FireNormal();
		}/*
		else if (Input.GetMouseButtonDown(2))
		{
			FireHoming();
		}
		else if (Input.GetKeyDown(KeyCode.Tab))
		{
			FireSplit();
		}*/
	}
}
