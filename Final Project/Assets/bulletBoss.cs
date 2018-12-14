using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bulletBoss : MonoBehaviour
{
	private GameObject Player_HP;
	private bool DestroyThis = false;
	// Use this for initialization
	void Start()
	{
		Player_HP = GameObject.Find("Character_HP");
	}

	// Update is called once per frame
	void Update()
	{
		if (DestroyThis)
		{
			DestroyImmediate(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log(collision.gameObject.tag);
		if (collision.gameObject.tag == "Player")
		{
			DestroyThis = true;
			DepleteHealth();
		}
	}

	private void DepleteHealth()
	{
		int Health = int.Parse(Player_HP.GetComponent<Text>().text);
		Health--;
		Player_HP.GetComponent<Text>().text = Health.ToString();
	}
}