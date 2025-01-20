using UnityEngine;
using UnityEngine.UI;

public class Seguridad : MonoBehaviour
{
    public Canvas camaras;
    public Canvas oficina;
    public Camera mainCamera;
    public Camera[] secCamaras;
    private Camera camaraActual;
    public Light[] lights;
    [SerializeField]private int currentCam;

    void OnMouseDown()
    {
        oficina.enabled = false;
        camaras.enabled = true;
        mainCamera.enabled = false;
        camaraActual = secCamaras[currentCam];
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
        if (!lights[currentCam].enabled)
        {
            lights[currentCam].enabled = true;
        } else if (lights[currentCam].enabled)
        {
            lights[currentCam].enabled = false;
        }
    }

    public void Volver()
    {
        oficina.enabled = true;
        camaras.enabled = false;
        mainCamera.enabled = true;
        camaraActual.enabled = false;
    }
}
