using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletSpawnerBoss : MonoBehaviour
{

	public GameObject bulletPrefab;
	public GameObject homingPrefab;
	public GameObject splitPrefab;
	public GameObject minionPrefab;

	private Vector2 PlayerCoords;

	// Use this for initialization
	void Start()
	{
		PlayerCoords = new Vector2(transform.localPosition.x, transform.localPosition.y);
	}

	public void FireNormal()
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

	public void FireHoming()
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

	public void FireSplit()
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
	public void SummonMinions(){
		var manager = (GameObject)Instantiate(
				minionPrefab,
				PlayerCoords,
				Quaternion.identity);
	}

	// Update is called once per frame
	void Update()
	{
		PlayerCoords = new Vector2(transform.localPosition.x, transform.localPosition.y);
		/*if (Input.GetMouseButtonDown(0))
		{
			FireNormal();
		}
		else if (Input.GetMouseButtonDown(1))
		{
			FireHoming();
		}
		else if (Input.GetKeyDown(KeyCode.Tab))
		{
			FireSplit();
		}*/
	}
}
