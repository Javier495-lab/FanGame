using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] outsideSpawn; // Spawn points del grupo A
    public Transform[] insideSpawn; // Spawn points del grupo B
    public float waitingTime;

    private Transform[] spawnActual; // Grupo de spawn activo
    private float timer;

    void Start()
    {
        SeleccionarGrupo();
        timer = waitingTime;
        TeleportarEnemigo(); // Hacer que empiece en un punto aleatorio
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            TeleportarEnemigo();
            timer = waitingTime; // Reiniciar el temporizador
        }
    }

    void SeleccionarGrupo()
    {
        // Usa booleanos del GameManager para elegir qué grupo de spawn usar
        if (GameManager.instance.dark)
        {
            spawnActual = outsideSpawn;
        }
        else
        {
            spawnActual = insideSpawn;
        }
    }

    void TeleportarEnemigo()
    {
        if (spawnActual.Length == 0) return; // Seguridad para evitar errores

        int index = Random.Range(0, spawnActual.Length); // Elegir un spawn aleatorio
        transform.position = spawnActual[index].position; // Mover el enemigo
    }
}
