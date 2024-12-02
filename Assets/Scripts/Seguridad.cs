using UnityEngine;
using UnityEngine.UI;

public class Seguridad : MonoBehaviour
{
    public Canvas camaras;
    public Canvas oficina;
    public Camera[] secCamaras;
    private Camera camaraActual;

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
        camaraActual.enabled = true;
    }

    public void Volver()
    {
        camaras.enabled = false;
        oficina.enabled=true;
        CambioCamara(0);
    }
}
