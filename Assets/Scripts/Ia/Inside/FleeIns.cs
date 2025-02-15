using UnityEngine;

public class FleeIns : StateMachineBehaviour
{
    public GameObject Animatronic;
    private int fleeIndex;
    private float speed;
    private float tiempoDeHuida = 3;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<SpawnManager>().footstepsSound2.SetActive(false);
        tiempoDeHuida = 3;
        animator.SetBool("Flee", false);
        fleeIndex = 1;
        speed = 6;
        Animatronic = animator.GetComponent<SpawnManager>().enemy;
        animator.GetComponent<SpawnManager>().fleeSound.SetActive(true);
        animator.GetComponent<SpawnManager>().footstepsSound2.SetActive(true);
        animator.GetComponent<SpawnManager>().footstepsSound.SetActive(false);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Animatronic.transform.position = Vector3.MoveTowards(Animatronic.transform.position, animator.GetComponent<SpawnManager>().insideSpawn[fleeIndex].position, speed * Time.deltaTime);
        Animatronic.transform.LookAt(animator.GetComponent<SpawnManager>().insideSpawn[fleeIndex]);
        if (Vector3.Distance(Animatronic.transform.position, animator.GetComponent<SpawnManager>().insideSpawn[1].position) <= 0.2f)
        {
            fleeIndex = 0; 
        }
        
        tiempoDeHuida -= Time.deltaTime;
        if (tiempoDeHuida <= 0)
        {
            animator.SetBool("Waiting", true);
        }
    }
}
