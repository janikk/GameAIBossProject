using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossAction : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotSpeed = 100f;
    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    public bool isRushing = false;
    public GameObject target;

    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        //Tuuurrrnnn around
        if (transform.position.x < -36)
        {
            transform.position = new Vector2(-36, transform.position.y);
            StartCoroutine(Rotate());
        }
        if (transform.position.x > 36)
        {
            transform.position = new Vector2(36, transform.position.y);
            StartCoroutine(Rotate());
        }
        if (transform.position.y < -16)
        {
            transform.position = new Vector2(transform.position.x, -16);
            StartCoroutine(Rotate());
        }
        if (transform.position.y > 22)
        {
            transform.position = new Vector2(transform.position.x, 22);
            StartCoroutine(Rotate());
        }
        target = GameObject.FindGameObjectWithTag("Player");
        //Move forward in direction facing
        transform.position += transform.right * moveSpeed * Time.deltaTime;
        //If not wandering....
        if (!isWandering)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight)
        {
            //Keep rotating to the right until false
            transform.Rotate(Vector3.back * Time.deltaTime * rotSpeed);
        }
        if (isRotatingLeft)
        {
            //Keep rotating to the left until false
            transform.Rotate(Vector3.forward * Time.deltaTime * -rotSpeed);
        }
    }
    IEnumerator Wander()
    {
        //Some numbers
        int rotTime = Random.Range(1, 3);
        int wait = Random.Range(1, 4);
        int rotLorR = Random.Range(1, 3);
        float rush = Random.Range(0f, 1f);
        //Set wandering to true so update doesn't keep calling this
        isWandering = true;
        //Wait for a few seconds- keep going forward
        if (rush < .85f)
        {
            yield return new WaitForSeconds(wait);
            //Which way are we turning?
            if (rotLorR == 1)
            {
                //Rotate for rotTime seconds
                isRotatingRight = true;
                yield return new WaitForSeconds(rotTime);
                isRotatingRight = false;
            }
            if (rotLorR == 2)
            {
                //Rotate for rotTime seconds (but left)
                isRotatingLeft = true;
                yield return new WaitForSeconds(rotTime);
                isRotatingLeft = false;
            }
        } else
        {
            isRushing = true;
            //Look at target
            Vector3 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //Move fast
            moveSpeed *= 2;
            yield return new WaitForSeconds(wait);
            //Back to normal
            moveSpeed /= 2;
            isRushing = false;

        }
        //Allows us to call this again
        isWandering = false;
    }

    IEnumerator Rotate()
    {
        isRotatingRight = true;
        yield return new WaitForSeconds(2);
        isRotatingRight = false;
    }
}