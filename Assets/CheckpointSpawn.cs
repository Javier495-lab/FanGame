using UnityEngine;
using UnityEngine.UIElements;

public class CheckpointSpawn : StateMachineBehaviour
{
    public GameObject Animatronic;
    public Transform Objective;
    public int CheckpointIndex;
    public float speed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("Ambos", 0);
        animator.SetBool("OnTheMove", false);

        CheckpointIndex = Random.Range(0, 5);

        speed = animator.GetComponent<SpawnManager>().speed;
        Animatronic = animator.GetComponent<SpawnManager>().enemy;
        Animatronic.transform.position = animator.GetComponent<SpawnManager>().outsideSpawn[CheckpointIndex].position;
        Objective = animator.GetComponent<SpawnManager>().checkpoints[CheckpointIndex];
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Animatronic.transform.position = Vector3.MoveTowards(Animatronic.transform.position, Objective.position, speed * Time.deltaTime);
        Animatronic.transform.LookAt(Objective);
    }
}
