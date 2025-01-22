using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light []lucesCasa;
    private bool encendido = true;
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
                encendido = false;
            }
        }
        else
        {
            foreach (Light i in lucesCasa)
            {
                i.enabled = true;
                encendido = true;
            }
        }
    }

    private void OnMouseDown()
    {
        if (!GameManager.instance.dark)
        {
            if (encendido)
            {
                GameManager.instance.SubPower(0.2f);
                foreach (Light i in lucesCasa)
                {
                    i.enabled = false;
                    encendido = false;
                }
            }
            else if (!encendido)
            {
                GameManager.instance.AddPower(0.2f);
                foreach (Light i in lucesCasa)
                {
                    i.enabled = true;
                    encendido = true;
                }
            }
        }
    }
}
