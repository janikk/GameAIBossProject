using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
	public GameObject target; 
	public float maxAcceleration;
	public float maxSpeed;
	Kinematic kinematic;
	// Use this for initialization
	void Start () {
		kinematic = new Kinematic();
	}
	
	// Update is called once per frame
	void Update () {
		print ("...");
		steeringOutput steering = new steeringOutput();
		steering.linear = target.transform.position - kinematic.position;
		print (target.transform.position);
		//steering.linear.normalize();
		steering.linear = steering.linear * maxAcceleration;
        steering.linear = Vector3.ClampMagnitude(steering.linear, maxAcceleration);

        kinematic.velocity = Vector3.ClampMagnitude(kinematic.velocity + steering.linear, maxSpeed);
        transform.position += kinematic.velocity * Time.deltaTime;
        kinematic.position = transform.position;



	}
}
