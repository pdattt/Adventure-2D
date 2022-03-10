using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kanaAttack : MonoBehaviour
{
    private float timeBtnAttack;
    public float startTimeAttack;

    private float timeBtnSkill;
    public float startTimeSkill;
    private float detectTimeWait;
    private bool isSkillReady;
    private float waitTime = 0.5f;

    public static bool isUsingSkill = false;

    public Transform[] skillEndPos;
    private Transform skillEnd;

    Animator anim;
    public int damage;
    public static bool isEnemyInRange;

    public GameObject hero;

    kanaMovement kanaMovement;
    kana kanaStatus;

    void Start()
    {
        anim = GetComponent<Animator>();
        //hero = GetComponent<heroMovement>();
        kanaMovement = GetComponent<kanaMovement>();
        kanaStatus = GetComponent<kana>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!gamePanel.isPause)
            if(kana.health > 0)
                if (hero != null)
                    StartCoroutine(Action(2f));
    }

    void Attack()
    {
        if (timeBtnAttack <= 0)
        {
            if (hero != null)
            {
                if (kana.health <= 0)
                    return;

                if (kanaMovement.Move(hero.gameObject.transform.position, 15f) && !kana.isOnHit)
                {
                    anim.SetTrigger("Attack");

                    DoDelayAttack(0.5f);
                    kana.PlaySound("attack");

                    //sound.PlayAttack();
                    timeBtnAttack = startTimeAttack;
                }
            }
        }
        else
            timeBtnAttack -= Time.deltaTime;
    }

    void UsingSkill()
    {
        if (timeBtnSkill <= 0)
        {
            if(hero != null)
            {
                if (kana.health <= 0)
                    return;

                DelayDetectPlayer();

                isUsingSkill = true;
                anim.SetBool("UsingSkill", true);
                WaitForSkill();

                if (isSkillReady)
                {
                    if (kanaMovement.Move(skillEnd.position, 25f))
                    {
                        //sound.PlayAttack();
                        anim.SetBool("UsingSkill", false);
                        timeBtnSkill = startTimeSkill;
                        isSkillReady = false;
                        waitTime = 0.5f;
                        isUsingSkill = false;
                    }
                }
            }
        }
        else
            timeBtnSkill -= Time.deltaTime;
    }

    void WaitForSkill()
    {
        if (waitTime <= 0)
            isSkillReady = true;
        else
            waitTime -= Time.deltaTime;
    }

    void DelayDetectPlayer()
    {
        if (detectTimeWait <= 0)
        {
            if (hero.gameObject.transform.position.x < gameObject.transform.position.x)
                skillEnd = skillEndPos[0];
            else
                skillEnd = skillEndPos[1];

            detectTimeWait = 1f;
        }
        else
            detectTimeWait -= Time.deltaTime;
    }

    void DoDelayAttack(float delayTime)
    {
        StartCoroutine(DelayAttack(delayTime));
    }

    IEnumerator Action(float delayTime) 
    {
        yield return new WaitForSeconds(delayTime);

        Attack();

        yield return new WaitForSeconds(delayTime);

        UsingSkill();
    }

    IEnumerator DelayAttack(float delayTime)
    {
        kanaMovement.speed = 0;

        yield return new WaitForSeconds(delayTime);

        if (isEnemyInRange)
        {
            if (hero != null)
                hero.GetComponent<heroMovement>().TakeDamage(damage);
        }
    }
}
