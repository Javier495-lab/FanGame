using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Consola : MonoBehaviour
{
    public Canvas consola;
    public Canvas oficina;
    [Range(0, 100)] public float[] cuenta;
    public TextMeshProUGUI[] numericos;
    public bool activado;
    public float incrementSpeed;

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
        if (!activado)
        {
            StartCoroutine(IncrementRele(rele));
            GameManager.instance.AddPower(0.3f);
            activado = true;
        } else if (activado)
        {
            StopAllCoroutines();
            GameManager.instance.SubPower(0.3f);
            activado= false;
        }
    }
    private IEnumerator IncrementRele(int rele)
    {
        while (true)
        {
            cuenta[rele] += incrementSpeed * Time.deltaTime;
            cuenta[rele] = (float)Math.Round(cuenta[rele], 2);
            numericos[rele].text = cuenta[rele].ToString() + "%";
            yield return null;
        }
    }
}
