using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAction : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float rotSpeed = 100f;

    private bool attackgoing = false;
    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Move forward in direction facing
        transform.position += transform.right * moveSpeed * Time.deltaTime;
        //If not wandering....
        if (!isWandering)
        {
            int attacktype = Random.Range(1,4);
            
            print(attacktype);
            if(!attackgoing){
                attackgoing = true;
                StartCoroutine(attack(attacktype));
            }
           // while(attackgoing){}
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

    IEnumerator attack(int attacktype)
    {
        BulletSpawnerBoss attacking = transform.GetComponent<BulletSpawnerBoss>();
        if(attacktype == 1){
            attacking.FireNormal();
            yield return new WaitForSeconds(1);
            attacking.FireNormal();
            yield return new WaitForSeconds(.5f);
            attacking.FireNormal();
            yield return new WaitForSeconds(.5f);
            attacking.FireNormal();
            yield return new WaitForSeconds(3);
        }
        else if(attacktype == 2){
            attacking.FireHoming();
            yield return new WaitForSeconds(1);
            attacking.FireHoming();
            yield return new WaitForSeconds(4);
        }
        else{
            attacking.FireSplit();
            yield return new WaitForSeconds(2);
            attacking.FireSplit();
            yield return new WaitForSeconds(2);
            attacking.FireSplit();
            yield return new WaitForSeconds(3);
        }

        //Allows us to call this again
        attackgoing = false;
    }

    IEnumerator Wander()
    {
        //Some numbers
        int rotTime = Random.Range(1, 3);
        int wait = Random.Range(1, 4);
        int rotLorR = Random.Range(1, 3);

        //Set wandering to true so update doesn't keep calling this
        isWandering = true;

        //Wait for a few seconds- keep going forward
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

        //Allows us to call this again
        isWandering = false;
    }
}
