using UnityEngine;

public class InsideSpawn3 : StateMachineBehaviour
{
    private float deathCountDown = 5;
    public float waitingTime;
    private float playerPos;
    public GameObject Animatronic;
    public GameObject player;
    private bool ahiEsta = false;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ahiEsta = false;
        deathCountDown = 5;
        waitingTime = Random.Range(animator.GetComponent<SpawnManager>().waitingTimeMin, animator.GetComponent<SpawnManager>().waitingTimeMax);
        Animatronic = animator.GetComponent<SpawnManager>().enemy;
        Animatronic.transform.position = animator.GetComponent<SpawnManager>().insideSpawn[3].position;
        player = animator.GetComponent<SpawnManager>().Player;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waitingTime -= Time.deltaTime;
        playerPos = player.GetComponent<Oficina>().currenPos;

        if (waitingTime <= 0)
        {
            //se acabó la fiesta
            ahiEsta = true;
            Animatronic.transform.position = animator.GetComponent<SpawnManager>().insideSpawn[4].position;
            
            deathCountDown -= Time.deltaTime;
            if (deathCountDown <= 0 || playerPos == 2)
            {
                animator.SetTrigger("Jumpscare");
            }
        }
        else if (player.GetComponent<Oficina>().flashlightB && !ahiEsta)
        {
            animator.SetBool("Flee", true);
        }
        if (GameManager.instance.encendidoManual || !GameManager.instance.apagadoSeguro && !ahiEsta && !GameManager.instance.dark)
        {
            animator.SetBool("Flee", true);
        }
    }
}
