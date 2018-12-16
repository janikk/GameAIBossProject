using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStates : MonoBehaviour
{

    private int HP;

    private GameObject Player_HP;
    public bool attack = false;

    enum AttackState
    {
        STRAIGHT,
        HOMING
    }

    AttackState AS;

	// Use this for initialization
	void Start () {
        Player_HP = GameObject.Find("Character_HP");
        AS = AttackState.STRAIGHT;
	}
	
	// Update is called once per frame
	void Update () {
        //Get health
        HP = int.Parse(GameObject.Find("Boss_HP").GetComponent<Text>().text);
        //Generate number to determine attack
        float attackType = Random.Range(0f, 1f);
        //Rushing? If so, don't attack
        bool rush = GetComponent<BossAction>().isRushing;
        //If attacking and rushing are false, attack
        if (!attack&&!rush)
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
        //Don't attack 20% of the time
        if (attackType >= 0.80f)
        {
            Debug.Log("30+ health, don't attack");
            yield return new WaitForSeconds(2);
        }
        //Straight shot 45% of the time
        else if (attackType >= .35f)
        {
            Debug.Log("30+ health, straight shot");
            attacking.FireNormal();
            yield return new WaitForSeconds(2);
        }
        //Straight homing shot 18% of the time
        else if (attackType >= .17f)
        {
            Debug.Log("30+ health, homing shot");
            attacking.FireHoming();
            yield return new WaitForSeconds(2);
        }
        //Scattered homing shot 17% of the time
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
            attacking.SummonMinions();
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            {
                int Health = int.Parse(Player_HP.GetComponent<Text>().text);
                Health-=4;
                Player_HP.GetComponent<Text>().text = Health.ToString();
        }
    }
}
