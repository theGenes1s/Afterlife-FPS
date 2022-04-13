using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adjusting enemy animations according to the parameters.
/// This helps to make the enemy move on defined triggers and bools.
/// </summary>
public class EnemyAnimator : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool walk) // enemy walk animation parameter
    {
        anim.SetBool(AnimationTags.WALK_PARAMETER, walk);
    }

    public void Run(bool run) //enemy run animation parameter
    {
        anim.SetBool(AnimationTags.RUN_PARAMETER, run);
    }

    public void Attack()
    { //Attack
        anim.SetTrigger(AnimationTags.ATTACK_TRIGGER);
    }

    public void Dead()
    { //Death Animation
        anim.SetTrigger(AnimationTags.DEAD_TRIGGER);
    }

    public void Hit()
    { //Hit Animation
        anim.SetTrigger(AnimationTags.HIT_TRIGGER);
    }
} // class
