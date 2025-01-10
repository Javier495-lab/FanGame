using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Range(0, 1)] public float power;
    public bool dark = false;
    public int completados = 0;
    private bool completado = false;
    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (power >= 1)
        {
            dark = true;
            power = 0;
        }
        if (completado)
        {
            completados++;
            completado = false;
        }
        if (completados == 6)
        {
            Debug.Log("has acabado");
        }
    }
    public void AddPower(float plusPower)
    {
        power += plusPower;
    }

    public void SubPower(float subPower)
    {
        power -= subPower;
    }

    public void ResetPower()
    {
        power = 0;
        dark = false;
    }

    public void Completado()
    {
        completado = true;
    }
}
