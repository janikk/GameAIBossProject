using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStates : MonoBehaviour {

    private int HP;

    private bool attack = false;

    enum AttackState
    {
        STRAIGHT,
        HOMING
    }

    AttackState AS;

	// Use this for initialization
	void Start () {
        AS = AttackState.STRAIGHT;
	}
	
	// Update is called once per frame
	void Update () {
        //Get health
        HP = int.Parse(GameObject.Find("Boss_HP").GetComponent<Text>().text);
        //Generate number to determine attack
        float attackType = Random.Range(0f, 1f);

        //If attacking is false, attack
        if (!attack)
        {
            //Attack difficulty determined by health
            if (AS == AttackState.STRAIGHT)
            {
                StartCoroutine(StraightAttack(attackType));
            }
            else if (AS == AttackState.HOMING)
            {
                StartCoroutine(HomingAttack(attackType));
            }
        }
        if (HP < 30)
        {
            AS = AttackState.HOMING;
        }
	}

    IEnumerator StraightAttack(float attackType)
    {
        //Attacking- don't want to have a barrage of bullets
        attack = true;
        BulletSpawnerBoss attacking = transform.GetComponent<BulletSpawnerBoss>();
        //Don't attack 50% of the time
        if (attackType >= 0.5f)
        {
            Debug.Log("30+ health, don't attack");
            yield return new WaitForSeconds(2);
        }
        //Straight shot 25% of the time
        else if (attackType >= .25f)
        {
            Debug.Log("30+ health, straight shot");
            attacking.FireNormal();
            yield return new WaitForSeconds(2);
        }
        //Straight homing shot 13% of the time
        else if (attackType >= .12f)
        {
            Debug.Log("30+ health, homing shot");
            attacking.FireHoming();
            yield return new WaitForSeconds(2);
        }
        //Scattered homing shot 12% of the time
        else
        {
            Debug.Log("30+ health, split homing");
            attacking.FireSplit();
            yield return new WaitForSeconds(2);
        }
        //No longer attacking
        attack = false;
    }

    IEnumerator HomingAttack(float attackType)
    {
        //Attacking- don't want to have a barrage of bullets
        attack = true;
        BulletSpawnerBoss attacking = transform.GetComponent<BulletSpawnerBoss>();
        //Scattered homing shot 25% of the time
        if (attackType >= 0.75f)
        {
            Debug.Log("<30 health, split homing");
            attacking.FireSplit();
            yield return new WaitForSeconds(1);
        }
        //Straight homing shot 25% of the time
        else if (attackType >= .5f)
        {
            Debug.Log("<30 health, homing shot");
            attacking.FireHoming();
            yield return new WaitForSeconds(1);
        }
        //Summon minions 30% of the time
        else if (attackType >= .2f)
        {
            Debug.Log("<30 health, summon minions");
            //attacking.SummonMinions();
            yield return new WaitForSeconds(1);
        }
        //Straight shot 20% of the time
        else
        {
            Debug.Log("<30 health, straight shot");
            attacking.FireNormal();
            yield return new WaitForSeconds(1);
        }
        attack = false;
    }
}
