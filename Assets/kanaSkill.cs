using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kanaSkill : MonoBehaviour
{
    private float timeBtwCast;
    public float startTimeCast;
    public Transform[] skillA;
    public int random;

    public static bool isUsingSkill = false;

    kana kanaStatus;
    kanaMovement kanaMovement;
    heroMovement hero;

    void Start()
    {
        kanaMovement = GetComponent<kanaMovement>();
        kanaStatus = GetComponent<kana>();
        hero = GetComponent<heroMovement>();

        random = Random.Range(0, 2);
    }

    void Update()
    {
        SkillCast();

        if (isUsingSkill)
        {
            if (kanaMovement.Move(skillA[random].position))
            {
                if (random == 0 && !kana.isFacingRight)
                    kanaStatus.Flip();
                else if(random == 1 && kana.isFacingRight)
                    kanaStatus.Flip();
            }
        }
    }

    void SkillCast()
    {

        if (timeBtwCast <= 0)
        {
            random = Random.Range(0, 2);
            //soundManager.PlaySound("fireball");
            //animator.SetTrigger("CastSpell");
            //animator.SetTrigger("DrawSword");
            //Instantiate(slash, attackPos.position, Quaternion.identity);
            timeBtwCast = startTimeCast;
            isUsingSkill = false;
        }
        else
        {
            timeBtwCast -= Time.deltaTime;
            isUsingSkill = true;
        }
    }
}
