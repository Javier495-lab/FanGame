using UnityEngine;

public class ReduceIntegrity : StateMachineBehaviour
{
    public GameObject camaras;
    public int CheckpointIndex;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        camaras = animator.GetComponent<SpawnManager>().Laptop;
        CheckpointIndex = animator.GetComponent<SpawnManager>().checkpointIndex;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        camaras.GetComponent<Seguridad>().DecreaseIntegrity(CheckpointIndex);
        if (camaras.GetComponent<Seguridad>().lights[CheckpointIndex].enabled == true)
        {
            animator.SetBool("Flee", true);
        }
    }
}
