using UnityEngine;

public class Consola : MonoBehaviour
{
    public Canvas consola;
    public Canvas oficina;
    [Range(0, 1)] public float[] cuenta;

    void OnMouseDown()
    {
        oficina.enabled = false;
        consola.enabled = true;
    }

    public void Volver()
    {
        consola.enabled = false;
        oficina.enabled = true;
    }

    public void Energuia(int rele)
    {

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
