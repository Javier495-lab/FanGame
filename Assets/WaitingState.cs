using UnityEngine;

public class WaitingState : StateMachineBehaviour
{
    public float waitingTime;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       waitingTime = Random.Range(animator.GetComponent<SpawnManager>().waitingTimeMin, animator.GetComponent<SpawnManager>().waitingTimeMax);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waitingTime -= Time.deltaTime;
        if (waitingTime <= 0)
        {
            if (GameManager.instance.apagadoSeguro)
            {
                animator.SetTrigger("ApagadoSeguro");
            }
            else
            {
                if (GameManager.instance.dark)
                {
                    animator.SetTrigger("Vulnerable");
                }
                animator.SetBool("OnTheMove", true);
            }
        }
    }
}
