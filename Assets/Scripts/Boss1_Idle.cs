using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_Idle : StateMachineBehaviour
{
    private int tall;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tall = Random.Range(1, 3);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 2)
        {
            if (tall == 1)
            {
                animator.SetTrigger("Attack_left");
            }
            if (tall == 2)
            {
                animator.SetTrigger("Attack_Right");
            }
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack_Right");
        animator.ResetTrigger("Attack_left");
    }

   
}
