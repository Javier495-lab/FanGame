using UnityEngine;

public class FleeOutside : StateMachineBehaviour
{
    public GameObject Animatronic;
    public Transform Objective;
    public int CheckpointIndex;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Flee", false);
        CheckpointIndex = animator.GetComponent<SpawnManager>().checkpointIndex;
        Objective = animator.GetComponent<SpawnManager>().outsideSpawn[CheckpointIndex];
        Animatronic = animator.GetComponent<SpawnManager>().enemy;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Animatronic.transform.position = Vector3.MoveTowards(Animatronic.transform.position, Objective.position, 10 * Time.deltaTime);
        Animatronic.transform.LookAt(Objective);
        if (Vector3.Distance(Animatronic.transform.position, Objective.position) <= 0.1f)
        {
            animator.SetBool("Waiting", true);
        }
    }
}
