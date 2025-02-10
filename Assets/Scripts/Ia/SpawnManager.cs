using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Animatronico")]
    public GameObject enemy;
    public float speed;
    [Header("SpawnPoints")]
    public Transform waitingPoint;
    public Transform[] outsideSpawn;
    public Transform[] insideSpawn;
    public Transform[] checkpoints;
    [Header("TiempoSeguro")]
    public float waitingTimeMax;
    public float waitingTimeMin;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
