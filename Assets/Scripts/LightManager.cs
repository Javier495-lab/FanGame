using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light []lucesCasa;
    public Light[] lucesBrightness;
    [SerializeField]private float temporizadorEncendidoManual = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.instance.dark)
        {
            foreach (Light i in lucesCasa)
            {
                i.enabled = false;
            }
            foreach (Light i in lucesBrightness)
            {
                i.enabled = false;
            }
        } else if (GameManager.instance.encendidoManual)
        {
            foreach (Light i in lucesCasa)
            {
                i.enabled = true;
            }
            foreach (Light i in lucesBrightness)
            {
                i.enabled = true;
            }
            
            if (temporizadorEncendidoManual >= 1)
            {
                GameManager.instance.encendidoManual = false;
                temporizadorEncendidoManual = 0;
            }
            temporizadorEncendidoManual += Time.deltaTime;
        }
    }

    private void OnMouseDown()
    {
        if (!GameManager.instance.dark)
        {
            if (!GameManager.instance.apagadoSeguro)
            {
                GameManager.instance.SubPower(0.2f);
                foreach (Light i in lucesCasa)
                {
                    i.enabled = false;
                    GameManager.instance.apagadoSeguro = true;
                }
            }
            else if (GameManager.instance.apagadoSeguro)
            {
                GameManager.instance.AddPower(0.2f);
                foreach (Light i in lucesCasa)
                {
                    i.enabled = true;
                    GameManager.instance.apagadoSeguro = false;
                }
            }
        }
    }
}
