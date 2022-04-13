using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    
    private Animator anim;

    
    void Awake()
    {
     anim = GetComponent<Animator>();   
    }
/// <summary>
/// Adjusting enemy animations according to the parameters.
/// </summary>
/// <param name="walk"></param>
    public void Walk (bool walk) // enemy walk animation
    {
        anim.SetBool(AnimationTags.WALK_PARAMETER, walk);
    }

    public void Run (bool run) //enemy run
    {
        anim.SetBool(AnimationTags.RUN_PARAMETER, run);
    }

    public void Attack (){
        anim.SetTrigger(AnimationTags.ATTACK_TRIGGER);
    }

    public void Dead () {
        anim.SetTrigger(AnimationTags.DEAD_TRIGGER);
    }
    public void Hit () {
        anim.SetTrigger(AnimationTags.HIT_TRIGGER);
    }
}// class
