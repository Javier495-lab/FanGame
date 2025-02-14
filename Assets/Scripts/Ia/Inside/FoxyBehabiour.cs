using UnityEngine;

public class FoxyBehabiour : StateMachineBehaviour
{
    public GameObject Animatronic;
    public GameObject player;
    private int runIndex;
    private float speed;
    private float runningSpeedB;
    private bool ahiEsta = false;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ahiEsta = false;
        runIndex = 1;
        speed = 6;
        Animatronic = animator.GetComponent<SpawnManager>().enemy;
        speed = animator.GetComponent<SpawnManager>().runningSpeed;
        runningSpeedB = animator.GetComponent<SpawnManager>().runningSpeedBlind;
        player = animator.GetComponent<SpawnManager>().Player;
        animator.GetComponent<SpawnManager>().footstepsSound.SetActive(true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        runningSpeedB -= Time.deltaTime;
        if (runningSpeedB <= 0)
        {
            Animatronic.transform.position = Vector3.MoveTowards(Animatronic.transform.position, animator.GetComponent<SpawnManager>().insideSpawn[runIndex].position, speed * Time.deltaTime);
            Animatronic.transform.LookAt(animator.GetComponent<SpawnManager>().insideSpawn[runIndex]);
            if (Vector3.Distance(Animatronic.transform.position, animator.GetComponent<SpawnManager>().insideSpawn[1].position) <= 0.2f)
            {
                animator.GetComponent<SpawnManager>().footstepsSound.SetActive(false);
                animator.GetComponent<SpawnManager>().footstepsSound2.SetActive(true);
                runIndex = 4;
                ahiEsta = true;
            }
            else if (player.GetComponent<Oficina>().flashlightB && ahiEsta)
            {
                animator.SetBool("Flee", true);
            }
            if (Vector3.Distance(Animatronic.transform.position, animator.GetComponent<SpawnManager>().insideSpawn[4].position) <= 0.4f)
            {
                animator.SetTrigger("Jumpscare");
            }
        }
        
        if (GameManager.instance.encendidoManual || !GameManager.instance.apagadoSeguro && !GameManager.instance.dark)
        {
            animator.SetBool("Flee", true);
        }
    }
}
