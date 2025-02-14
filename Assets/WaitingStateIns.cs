using UnityEngine;

public class WaitingStateIns : StateMachineBehaviour
{
    public float waitingTime;
    private float notFair;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Vulnerable", false);
        waitingTime = Random.Range(animator.GetComponent<SpawnManager>().waitingTimeMin, animator.GetComponent<SpawnManager>().waitingTimeMax);
        animator.SetBool("Waiting", false);
        notFair = Random.Range(0, animator.GetComponent<SpawnManager>().offLightsChance);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waitingTime -= Time.deltaTime;
        if (waitingTime <= 0)
        {
            if (GameManager.instance.dark)
            {
                animator.SetBool("Vulnerable", true);
            }
            else
            {
                animator.SetBool("Vulnerable", false);
            }

            if (GameManager.instance.dark && notFair == 1)
            {
                animator.SetTrigger("NotFair");
            }
            else
            {
                animator.SetBool("OnTheMove", true);
            }
        }
    }
}
