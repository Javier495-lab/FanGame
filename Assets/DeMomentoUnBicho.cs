using UnityEngine;

public class DeMomentoUnBicho : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("Ambos", Random.Range(1, 3));
    }
}
