using UnityEngine;

public class Consola : MonoBehaviour
{
    public Canvas consola;
    public Canvas oficina;
    public Light[] lights;

    void OnMouseDown()
    {
        oficina.enabled = false;
        consola.enabled = true;
    }

    /*public void CambioCamara(int numeroCamara)
    {
        camaraActual.enabled = false;
        camaraActual = secCamaras[numeroCamara];
        camaraActual.enabled = true;
    }*/

    public void Volver()
    {
        consola.enabled = false;
        oficina.enabled = true;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
