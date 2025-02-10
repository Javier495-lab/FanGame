using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] outsideSpawn; // Spawn points del grupo A
    public Transform[] insideSpawn; // Spawn points del grupo B
    public float tiempoEntreTeleports = 5f; // Tiempo antes de cambiar de posición

    private Transform[] spawnActual; // Grupo de spawn activo
    private float timer;

    void Start()
    {
        SeleccionarGrupo();
        timer = tiempoEntreTeleports;
        TeleportarEnemigo(); // Hacer que empiece en un punto aleatorio
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            TeleportarEnemigo();
            timer = tiempoEntreTeleports; // Reiniciar el temporizador
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

    // Método para ajustar la frecuencia de teletransporte en tiempo real
    public void AjustarFrecuencia(float nuevaFrecuencia)
    {
        tiempoEntreTeleports = nuevaFrecuencia;
    }
}
