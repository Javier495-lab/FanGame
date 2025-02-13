using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Seguridad : MonoBehaviour
{
    public Canvas camaras;
    public Canvas oficina;
    public Camera mainCamera;
    public Camera[] secCamaras;
    private Camera camaraActual;
    public Button flash;
    public float flashDuration;  
    public Light[] lights;
    public float bateria;
    [SerializeField]private int currentCam;
    private bool quitarCanvasOficina = true;
    [Range(0, 100)] public float[] integrities;
    public float decreaseRate = 2f;
    [SerializeField] private bool[] goal = new bool[5];
    public TextMeshProUGUI integrity;
    
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
            UpdateIntegrityText();
        }
    }

    public void CambioCamara(int numeroCamara)
    {
        camaraActual.enabled = false;
        camaraActual = secCamaras[numeroCamara];
        currentCam = numeroCamara;
        camaraActual.enabled = true;
        UpdateIntegrityText();
    }
    public void Flash()
    {
        StartCoroutine(Flashear());
    }
    private IEnumerator Flashear()
    {
        
        if (!lights[currentCam].enabled)
        {
            GameManager.instance.AddPower(0.4f);
            lights[currentCam].enabled = true;
            flash.gameObject.SetActive(false);
            GameManager.instance.SubPowerLight(0.4f);
            float elapsedTime = 0f;
            while (lights[currentCam].intensity > 0)
            {
                elapsedTime += Time.deltaTime;
                lights[currentCam].GetComponent<Light>().intensity = Mathf.Lerp(1000, 0f, elapsedTime / flashDuration);

                yield return null;
            }
            lights[currentCam].enabled = false;
            lights[currentCam].intensity = 1000;
            flash.gameObject.SetActive(true);
        }
    }

    public void Volver()
    {
        oficina.enabled = true;
        camaras.enabled = false;
        mainCamera.enabled = true;
        camaraActual.enabled = false;
    }

    private void UpdateIntegrityText()
    {
        
        integrity.text = "Integrity: " + integrities[currentCam].ToString("F0");
        
    }

    public void DecreaseIntegrity(int damagedCheckpoint)
    {
        for (int i = 0; i < integrities.Length; i++)
        {
            if (integrities[i] > 0)
            {
                integrities[damagedCheckpoint] -= decreaseRate * Time.deltaTime;
                //integrities[i] = Mathf.Clamp(integrities[i], 0, 100);
            }
        }

        if (currentCam < integrities.Length)
        {
            UpdateIntegrityText();
        }
    }
}
