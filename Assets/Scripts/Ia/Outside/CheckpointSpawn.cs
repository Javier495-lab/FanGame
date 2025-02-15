using UnityEngine;
using UnityEngine.UIElements;

public class CheckpointSpawn : StateMachineBehaviour
{
    public GameObject Animatronic;
    public GameObject camaras;
    public Transform Objective;
    public int checkpointIndex;
    private float speed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("OnTheMove", false);

        speed = animator.GetComponent<SpawnManager>().speed;
        Animatronic = animator.GetComponent<SpawnManager>().enemy;
        camaras = animator.GetComponent<SpawnManager>().Laptop;
        animator.GetComponent<SpawnManager>().fleeSoundOut.SetActive(false);

        int GenerateValidRandomIndex()
        {
            int randomIndex;
            do
            {
                animator.GetComponent<SpawnManager>().RandomNumber();
                randomIndex = animator.GetComponent<SpawnManager>().checkpointIndex;
            }
            while (camaras.GetComponent<Seguridad>().goal[randomIndex]);

            return randomIndex;
        }

        checkpointIndex = GenerateValidRandomIndex();
        Objective = animator.GetComponent<SpawnManager>().checkpoints[checkpointIndex];
        Animatronic.transform.position = animator.GetComponent<SpawnManager>().outsideSpawn[checkpointIndex].position;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Animatronic.transform.position = Vector3.MoveTowards(Animatronic.transform.position, Objective.position, speed * Time.deltaTime);
        Animatronic.transform.LookAt(Objective);
        if (Vector3.Distance(Animatronic.transform.position, Objective.position) <= 0.3f)
        {
            animator.SetTrigger("CheckpointDamage");
        }
        if (camaras.GetComponent<Seguridad>().lights[checkpointIndex].enabled == true)
        {
            animator.SetBool("Flee", true);
        }
    }
}
