using UnityEngine;
using UnityEngine.UIElements;

public class CheckpointSpawn : StateMachineBehaviour
{
    public GameObject Animatronic;
    public GameObject camaras;
    public Transform Objective;
    private int CheckpointIndex;
    private float speed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<SpawnManager>().RandomNumber();
        animator.SetInteger("Ambos", 0);
        animator.SetBool("OnTheMove", false);

        CheckpointIndex = animator.GetComponent<SpawnManager>().checkpointIndex;

        speed = animator.GetComponent<SpawnManager>().speed;
        Animatronic = animator.GetComponent<SpawnManager>().enemy;
        Animatronic.transform.position = animator.GetComponent<SpawnManager>().outsideSpawn[CheckpointIndex].position;
        Objective = animator.GetComponent<SpawnManager>().checkpoints[CheckpointIndex];
        camaras = animator.GetComponent<SpawnManager>().Laptop;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Animatronic.transform.position = Vector3.MoveTowards(Animatronic.transform.position, Objective.position, speed * Time.deltaTime);
        Animatronic.transform.LookAt(Objective);
        if (Vector3.Distance(Animatronic.transform.position, Objective.position) <= 0.3f)
        {
            animator.SetTrigger("CheckpointDamage");
        }
        if (camaras.GetComponent<Seguridad>().lights[CheckpointIndex].enabled == true)
        {
            animator.SetBool("Flee", true);
        }
    }
}
