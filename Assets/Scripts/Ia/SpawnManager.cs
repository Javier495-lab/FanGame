using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [Header("Animatronico")]
    public GameObject enemy;
    public Light jumscareLight;
    [Header("Sonidos")]
    public GameObject jumpscareSound;
    public GameObject footstepsSound;
    public GameObject footstepsSound2;
    public GameObject fleeSound;
    public GameObject fleeSoundOut;

    [Header("Fuera")]
    public float speed;
    public int checkpointIndex;
    public int offLightsChance;
    [Header("Dentro")]
    public float insideSpeedMin;
    public float insideSpeedMax;
    public float runningSpeedBlind;
    public float runningSpeed;
    [Header("SpawnPoints")]
    public Transform waitingPoint;
    public Transform[] outsideSpawn;
    public Transform[] insideSpawn;
    public Transform[] checkpoints;
    [Header("TiempoSeguro")]
    public float waitingTimeMax;
    public float waitingTimeMin;
    [Header("Ref. Camaras y Jugador")]
    public GameObject Laptop;
    public GameObject Player;
    public GameObject Consola;    
    

    public void RandomNumber()
    {
        checkpointIndex = Random.Range(0, 5);
    }
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
