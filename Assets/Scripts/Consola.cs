using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Consola : MonoBehaviour
{
    public Canvas consola;
    public Canvas oficina;
    private IEnumerator[] corrutinas;
    [Range(0, 100)] public float[] cuenta;
    public TextMeshProUGUI[] numericos;
    public bool[] activado;
    public float incrementSpeed;

    private void Start()
    {
        corrutinas = new IEnumerator[]
        {
            IncrementRele0(),
            IncrementRele1(),
            IncrementRele2(),
            IncrementRele3(),
            IncrementRele4(),
            IncrementRele5()
        };
    }
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
        if (!activado[rele])
        {
            StartCoroutine(corrutinas[rele]);
            GameManager.instance.AddPower(0.3f);
            activado[rele] = true;
        } else if (activado[rele])
        {
            StopCoroutine(corrutinas[rele]);
            GameManager.instance.SubPower(0.3f);
            activado[rele] = false;
        }
    }
    #region corrutinas
    private IEnumerator IncrementRele0()
    {
        while (true)
        {
            cuenta[0] += incrementSpeed * Time.deltaTime;
            cuenta[0] = (float)Math.Round(cuenta[0], 2);
            numericos[0].text = cuenta[0].ToString() + "%";
            yield return null;
        }
    }

    private IEnumerator IncrementRele1()
    {
        while (true)
        {
            cuenta[1] += incrementSpeed * Time.deltaTime;
            cuenta[1] = (float)Math.Round(cuenta[1], 2);
            numericos[1].text = cuenta[1].ToString() + "%";
            yield return null;
        }
    }

    private IEnumerator IncrementRele2()
    {
        while (true)
        {
            cuenta[2] += incrementSpeed * Time.deltaTime;
            cuenta[2] = (float)Math.Round(cuenta[2], 2);
            numericos[2].text = cuenta[2].ToString() + "%";
            yield return null;
        }
    }

    private IEnumerator IncrementRele3()
    {
        while (true)
        {
            cuenta[3] += incrementSpeed * Time.deltaTime;
            cuenta[3] = (float)Math.Round(cuenta[3], 2);
            numericos[3].text = cuenta[3].ToString() + "%";
            yield return null;
        }
    }

    private IEnumerator IncrementRele4()
    {
        while (true)
        {
            cuenta[4] += incrementSpeed * Time.deltaTime;
            cuenta[4] = (float)Math.Round(cuenta[4], 2);
            numericos[4].text = cuenta[4].ToString() + "%";
            yield return null;
        }
    }

    private IEnumerator IncrementRele5()
    {
        while (true)
        {
            cuenta[5] += incrementSpeed * Time.deltaTime;
            cuenta[5] = (float)Math.Round(cuenta[5], 2);
            numericos[5].text = cuenta[5].ToString() + "%";
            yield return null;
        }
    }
    #endregion
}
