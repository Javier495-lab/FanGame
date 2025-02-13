using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Range(0, 1)] public float power;
    public bool dark = false;
    public int completados = 0;
    private bool completado = false;
    public bool encendidoManual = false;
    public bool apagadoSeguro = false;
    private bool checkCompletado = false;
    public int checkCompletados = 0;
    public static GameManager instance { get; private set; }

    private GameObject enemigo;

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
        enemigo = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void Update()
    {
        if (power >= 1)
        {
            dark = true;
            power = 0;
            apagadoSeguro= false;
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

        if (checkCompletado)
        {
            checkCompletados++;
            checkCompletado = false;
        }
        if (checkCompletados == 5)
        {
            encendidoManual = true;
            dark = false;
            power = 0.2f;
            checkCompletados = 0;
        }
    }
    public void ModificarMaxTeleportRate(float nuevoTiempo)
    {
        enemigo.GetComponent<SpawnManager>().waitingTimeMax = nuevoTiempo;
    }
    public void ModificarMinTeleportRate(float nuevoTiempo)
    {
        enemigo.GetComponent<SpawnManager>().waitingTimeMin = nuevoTiempo;
    }

    public void AddPower(float plusPower)
    {
        power += plusPower;
    }
    
    public void SubPower(float subPower)
    {
        power -= subPower;
    }
    public void SubPowerLight(float subPower)
    {
        StartCoroutine(ReducePowerGradually(subPower));
    }
    private IEnumerator ReducePowerGradually(float amount)
    {
        float remainingAmount = amount;

        while (remainingAmount > 0f)
        {
            float reductionStep = Time.deltaTime *0.02f;

            if (remainingAmount < reductionStep)
            {
                power -= remainingAmount;
                break;
            }

            power -= reductionStep;
            remainingAmount -= reductionStep;

            yield return null;
        }
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

    public void CheckCompletado()
    {
        checkCompletado = true;
    }
}
