using UnityEngine;

public class ReduceIntegrity : StateMachineBehaviour
{
    public GameObject camaras;
    public int CheckpointIndex;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        camaras = animator.GetComponent<SpawnManager>().Laptop;
        CheckpointIndex = animator.GetComponent<SpawnManager>().checkpointIndex;
        camaras.GetComponent<Seguridad>().dangerIcons[CheckpointIndex].SetActive(true);
        camaras.GetComponent<Seguridad>().dangerAudio.SetActive(true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        camaras.GetComponent<Seguridad>().DecreaseIntegrity(CheckpointIndex);
        if (camaras.GetComponent<Seguridad>().lights[CheckpointIndex].enabled == true)
        {
            animator.SetBool("Flee", true);
        } else if(camaras.GetComponent<Seguridad>().integrities[CheckpointIndex] <= 0)
        {
            animator.SetBool("Flee", true);
        }
    }
}
