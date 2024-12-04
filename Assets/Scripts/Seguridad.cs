using UnityEngine;
using UnityEngine.UI;

public class Seguridad : MonoBehaviour
{
    public Canvas camaras;
    public Canvas oficina;
    public Camera[] secCamaras;
    private Camera camaraActual;
    public Light[] lights;
    [SerializeField]private int currentCam;

    void OnMouseDown()
    {
        oficina.enabled = false;
        camaras.enabled = true;
        secCamaras[0].enabled = false;
        camaraActual = secCamaras[1];
        camaraActual.enabled = true;
    }

    public void CambioCamara(int numeroCamara)
    {
        camaraActual.enabled = false;
        camaraActual = secCamaras[numeroCamara];
        currentCam = numeroCamara;
        camaraActual.enabled = true;
    }

    public void Flash()
    {
        if (!lights[currentCam-1].enabled)
        {
            lights[currentCam-1].enabled = true;
        } else if (lights[currentCam - 1].enabled)
        {
            lights[currentCam-1].enabled = false;
        }
    }

    public void Volver()
    {
        camaras.enabled = false;
        oficina.enabled=true;
        CambioCamara(0);
    }
}
