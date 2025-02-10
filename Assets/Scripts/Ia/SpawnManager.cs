using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Animatronico")]
    public GameObject enemy;
    public float speed;
    public int checkpointIndex;
    [Header("SpawnPoints")]
    public Transform waitingPoint;
    public Transform[] outsideSpawn;
    public Transform[] insideSpawn;
    public Transform[] checkpoints;
    [Header("TiempoSeguro")]
    public float waitingTimeMax;
    public float waitingTimeMin;
    [Header("Ref. Camaras")]
    public GameObject Laptop;
    

    public void RandomNumber()
    {
        checkpointIndex = Random.Range(0, 5);
    }
}
