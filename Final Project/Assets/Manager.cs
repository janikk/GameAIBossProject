using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    private GameObject Boss_HP;
	private GameObject Player_HP;
	public GameObject endScreen;
	// Use this for initialization
	void Start () {
		Boss_HP = GameObject.Find("Boss_HP");
		Player_HP = GameObject.Find("Character_HP");
	}
	
	// Update is called once per frame
	void Update () {
		if(int.Parse(Player_HP.GetComponent<Text>().text) < 0){
			endScreen.GetComponentInChildren<Text>().text = "Game Over\nPress Escape to close the game";
			Time.timeScale = 0.0f;
		}
		else if(int.Parse(Boss_HP.GetComponent<Text>().text) < 0) {
			endScreen.GetComponentInChildren<Text>().text = "You Win\nPress Escape to close the game";
			Time.timeScale = 0.0f;
		} 
		if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
	}
}
