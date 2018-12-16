using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionFlock : MonoBehaviour {
	struct Kinematic{
		public Vector3 position;
		public float orientation;
		public Vector3 velocity;
		public float rotation;
	}
	struct steeringOutput{
		public Vector3 linear;
		public float angular;
	}
	public float seperationWeight;
	public float followWeight;
	public float cohesionWeight;

	public GameObject target; 
	public float maxAcceleration;
	public float maxSpeed;
	public MinionFlockManager minionManager;
    private GameObject Player_HP;
	Kinematic kinematic;
	// Use this for initialization
	void Start () {
		kinematic = new Kinematic();
        Player_HP = GameObject.Find("Character_HP");
	}
	
	// Update is called once per frame
	void Update () {
		steeringOutput steering = new steeringOutput();
		steering.linear = target.transform.position - kinematic.position;
		//steering.linear.normalize();
		steering.linear = steering.linear * maxAcceleration;
        steering.linear = Vector3.ClampMagnitude(steering.linear, maxAcceleration);
        Vector3 seperate = separation();
        Vector3 cohesi = cohesion();
        seperate = Vector3.ClampMagnitude(seperate, maxAcceleration);
        cohesi = Vector3.ClampMagnitude(cohesi, maxAcceleration);
        kinematic.velocity = Vector3.ClampMagnitude(kinematic.velocity + steering.linear * followWeight  + seperate *seperationWeight + cohesi *cohesionWeight, maxSpeed);
        transform.position += kinematic.velocity * Time.deltaTime;
        kinematic.position = transform.position;
	}
	public Vector3 separation()
    {
        // To add distances
        Vector3 sum = Vector3.zero;
        float strength = 0f;
        // To get a count of birbs
        int count = 0;
        // Loop through all units
        foreach (GameObject other in minionManager.GetComponent<MinionFlockManager>().minions)
        {
            // Skip ourself!
            if (other == this.gameObject||other ==null)
            {
                continue;
            }
            // Get distance between this and other units
            float d = Vector3.Distance(kinematic.position, other.GetComponent<MinionFlock>().kinematic.position);
            // If it's close enough, calculate strength of repulsion
            if (d < 5)
            {
                count++;
                sum += kinematic.position - other.GetComponent<MinionFlock>().kinematic.position;
                strength += Mathf.Min(.3f * d * d, minionManager.GetComponent<MinionFlockManager>().maxVelocity);
            }
        }
        // If we had neighbors...
        if (count > 0)
        {
            // Change direction
            sum /= count;
            Vector3 steer = sum;
            return steer*strength;
        }
        // Otherwise, don't change direction
        return Vector3.zero;
    }

    public Vector3 cohesion(){
        // Get distance of furthest neighbor
        float neighborDist = minionManager.GetComponent<MinionFlockManager>().neighborDistance;
        // To add distances
        Vector3 sum = Vector3.zero;
        // To get an average of alignment
        int count = 0;
        // Loop through all units
        foreach (GameObject other in minionManager.GetComponent<MinionFlockManager>().minions)
        {
            // Skip ourself and super far away minions!
            if (other == this.gameObject ||other ==null || Vector3.Distance(kinematic.position, other.GetComponent<MinionFlock>().kinematic.position) > 20)
            {
                continue;
            }
            sum += other.GetComponent<MinionFlock>().kinematic.position;
            count++;
        }
        // If we had neighbors...
        if (count > 0)
        {
            // Get average position to follow
            sum /= count;
            return (sum - kinematic.position);
        }
        // Otherwise, don't change direction
        return Vector3.zero;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.tag + "In the thiiiiing");
        if(collision.gameObject.tag == "PlayerBullet")
        {
            print("yeah obviously");
            minionManager.destroyThis(this);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            print("are you real????");
            DepleteHealth();
            minionManager.destroyThis(this);
            Destroy(gameObject);
        }
    }
    private void DepleteHealth()
    {
        int Health = int.Parse(Player_HP.GetComponent<Text>().text);
        Health-=2;
        Player_HP.GetComponent<Text>().text = Health.ToString();
    }

}
