using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light []lucesCasa;
    public Light[] lucesBrightness;
    
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
