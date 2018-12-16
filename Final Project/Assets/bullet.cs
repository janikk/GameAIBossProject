using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bullet : MonoBehaviour {
    private GameObject Boss_HP;
    private bool DestroyThis = false;
	// Use this for initialization
	void Start () {
        Boss_HP = GameObject.Find("Boss_HP");
	}
	
	// Update is called once per frame
	void Update () {
        if (DestroyThis)
        {
            DestroyImmediate(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Boss")
        {
            DestroyThis = true;
            DepleteBossesHealth();
        }
        if(collision.gameObject.tag == "Minion")
        {
            DestroyThis = true;
        }
    }

    private void DepleteBossesHealth()
    {
        int Health = int.Parse(Boss_HP.GetComponent<Text>().text);
        Health--;
        Boss_HP.GetComponent<Text>().text = Health.ToString();
    }
}
