using UnityEngine;

public class Jumpscare : StateMachineBehaviour
{
    public GameObject Animatronic;
    public GameObject camaras;
    public GameObject consola;
    float jumpscareDuration;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jumpscareDuration = 2.5f;
        Animatronic = animator.GetComponent<SpawnManager>().enemy;
        Animatronic.transform.position = animator.GetComponent<SpawnManager>().insideSpawn[5].position;
        camaras = animator.GetComponent<SpawnManager>().Laptop;
        camaras.GetComponent<Seguridad>().Volver();
        consola = animator.GetComponent<SpawnManager>().Consola;
        consola.GetComponent<WinCondition>().Volver();
        camaras.GetComponent<Seguridad>().oficina.enabled = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        jumpscareDuration -= Time.deltaTime;
        if (jumpscareDuration <= 0)
        {
            animator.GetComponent<SpawnManager>().VolverAlMenu();
        }
    }
}
