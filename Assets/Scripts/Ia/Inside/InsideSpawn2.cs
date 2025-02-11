using UnityEngine;

public class InsideSpawn2 : StateMachineBehaviour
{
    public float waitingTime;
    private float playerPos;
    public GameObject Animatronic;
    public GameObject player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waitingTime = Random.Range(animator.GetComponent<SpawnManager>().waitingTimeMin, animator.GetComponent<SpawnManager>().waitingTimeMax);
        Animatronic = animator.GetComponent<SpawnManager>().enemy;
        Animatronic.transform.position = animator.GetComponent<SpawnManager>().insideSpawn[2].position;
        player = animator.GetComponent<SpawnManager>().Player;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waitingTime -= Time.deltaTime;
        playerPos = player.GetComponent<Oficina>().currenPos;

        if (waitingTime <= 0 && playerPos != 2)
        {
            animator.SetTrigger("Spawn3");
        }
        else if (player.GetComponent<Oficina>().flashlightB)
        {
            animator.SetBool("Flee", true);
        }
        if (GameManager.instance.encendidoManual || !GameManager.instance.apagadoSeguro)
        {
            animator.SetBool("Flee", true);
        }
    }
}
