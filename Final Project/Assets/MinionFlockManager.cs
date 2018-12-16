using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionFlockManager : MonoBehaviour {
    public int numminions;
    public int spawnX, spawnY;
    //Hold all birbs
    public GameObject[] minions;
    //The prefab so we can make the thing
    public GameObject minonPrefab;

    [Range(0, 50)]
    public int neighborDistance = 5;
    [Range(0, 2)]
    public float maxForce = 0.5f;
    [Range(0, 5)]
    public float maxVelocity = 2f;
	// Use this for initialization
	void Start () {
		minions = new GameObject[numminions];
        for(int i = 0; i < numminions; ++i){
            //Determine starting position of birb
            Vector3 pos = new Vector3(Random.Range(-spawnX,spawnX), Random.Range(-spawnY,spawnY), 0);
            //Make birb
            minions[i] = Instantiate(minonPrefab, this.transform.position + pos, Quaternion.identity) as GameObject;
          	minions[i].GetComponent<MinionFlock>().minionManager = this;
          	minions[i].GetComponent<MinionFlock>().target = GameObject.Find("Character");
        }
	}
	// Update is called once per frame
	void Update () {
		if (numminions == 0){
			Destroy(gameObject);
		}
	}
	public void destroyThis(MinionFlock thing){
		 numminions--;
	}
}
