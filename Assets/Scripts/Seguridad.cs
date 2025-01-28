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
    public float batería;
    [SerializeField]private int currentCam;
    private bool quitarCanvasOficina = true;

    private void Start()
    {
        camaraActual = secCamaras[1];
    }
    private void Update()
    {
        if (GameManager.instance.dark && quitarCanvasOficina)
        {
            oficina.enabled = true;
            camaras.enabled = false;
            mainCamera.enabled = true;
            camaraActual.enabled = false;
            foreach (Light i in lights)
            {
                i.enabled = false;
            }
            quitarCanvasOficina = false;
        }
    }
    void OnMouseDown()
    {
        if (!GameManager.instance.dark)
        {
            oficina.enabled = false;
            camaras.enabled = true;
            mainCamera.enabled = false;
            camaraActual = secCamaras[currentCam];
            camaraActual.enabled = true;
            quitarCanvasOficina = true;
        }
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
            GameManager.instance.AddPower(0.1f);
            lights[currentCam].enabled = true;
        } else if (lights[currentCam].enabled)
        {
            GameManager.instance.SubPower(0.1f);
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
