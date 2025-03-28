using UnityEngine;

public class WaitToEnter : StateMachineBehaviour
{
    public float waitingTime;
    private float playerPos;
    private int tipoDeEntrada;
    public GameObject Animatronic;
    public GameObject player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("OnTheMove", false);
        animator.SetInteger("Spawn1_Bestia", 5);
        animator.SetInteger("Ambos", 0);
        tipoDeEntrada = Random.Range(1, 5);
        waitingTime = Random.Range(animator.GetComponent<SpawnManager>().waitingTimeMin, animator.GetComponent<SpawnManager>().waitingTimeMax);
        Animatronic = animator.GetComponent<SpawnManager>().enemy;
        Animatronic.transform.position = animator.GetComponent<SpawnManager>().insideSpawn[0].position;
        player = animator.GetComponent<SpawnManager>().Player;
        animator.GetComponent<SpawnManager>().fleeSound.SetActive(false);
        animator.GetComponent<SpawnManager>().footstepsSound2.SetActive(false);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waitingTime -= Time.deltaTime;
        playerPos = player.GetComponent<Oficina>().currenPos;
        if (waitingTime <= 0)
        {
            if (tipoDeEntrada < 4 && playerPos != 2)
            {
                animator.SetInteger("Spawn1_Bestia", tipoDeEntrada);
            }
            else
            {
                animator.SetInteger("Spawn1_Bestia", tipoDeEntrada);
            }
        }
        if (GameManager.instance.encendidoManual || !GameManager.instance.apagadoSeguro && !GameManager.instance.dark)
        {
            animator.SetBool("Flee", true);
        }
    }
}
