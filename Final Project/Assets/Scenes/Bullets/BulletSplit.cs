using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSplit : MonoBehaviour {

	public bool isBoss;
	public GameObject bulletPrefab;
	public GameObject target;
	public float speed;
	Rigidbody2D rb;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		if (isBoss)
		{
			rb.velocity = Vector2.left * speed;
			target = GameObject.Find("Character");
		}
		else
		{
			rb.velocity = Vector2.right * speed;
			target = GameObject.Find("Boss");
		}
		StartCoroutine(Split());
	}

	IEnumerator Split()
	{
		yield return new WaitForSeconds(0.5f);
		var bulletUp = (GameObject)Instantiate(
		bulletPrefab,
		transform.position,
		Quaternion.identity);

		var bulletDown = (GameObject)Instantiate(
		bulletPrefab,
		transform.position,
		Quaternion.identity);

		Vector2 two = new Vector2(1, -1);
		Vector2 three = new Vector2(-1, -1);
		Vector2 four = new Vector2(-1, 1);
		if (isBoss)
		{
			bulletUp.GetComponent<Rigidbody2D>().velocity = four * speed;
			bulletDown.GetComponent<Rigidbody2D>().velocity = three * speed;
		}
		else
		{
			bulletUp.GetComponent<Rigidbody2D>().velocity = Vector2.one * speed;
			bulletDown.GetComponent<Rigidbody2D>().velocity = two * speed;
		}

		StartCoroutine(Follow(bulletUp,bulletDown));
	}

	IEnumerator Follow(GameObject bulletUp, GameObject bulletDown)
	{
		yield return new WaitForSeconds(0.75f);
		Vector2 dir = (target.transform.position - transform.position).normalized;
		Vector2 dirUp = (target.transform.position - bulletUp.transform.position).normalized;
		Vector2 dirDown = (target.transform.position - bulletDown.transform.position).normalized;
		bulletUp.GetComponent<Rigidbody2D>().velocity = dirUp * speed;
		bulletDown.GetComponent<Rigidbody2D>().velocity = dirDown * speed;
		rb.velocity = dir * speed;
	}

}
