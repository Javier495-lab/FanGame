using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class WinCondition : MonoBehaviour
{
    public Canvas consola;
    public Canvas oficina;
    [Range(0, 100)]public float[] values;
    public float maxValue = 100f;
    public float increaseSpeed;
    public Button[] buttons;
    public TextMeshProUGUI[] valueTexts;
    private bool quitarCanvasOficina = true;

    public bool[] isIncreasing = new bool[6];
    public bool[] goal = new bool[6];

    public BoxCollider palancaColl;
    private MeshCollider meshCollider;

    void OnMouseDown()
    {
        if (!GameManager.instance.dark)
        {
            palancaColl.enabled = false;
            oficina.enabled = false;
            consola.enabled = true;
            quitarCanvasOficina = true;
            meshCollider.enabled = false;
        }
    }
    public void Volver()
    {
        consola.enabled = false;
        oficina.enabled = true;
        palancaColl.enabled = true;
        meshCollider.enabled = true;
    }

    void Start()
    {
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = 0f;
            int index = i;
            buttons[i].onClick.AddListener(() => StartIncrease(index));
        }
        meshCollider = GetComponent<MeshCollider>();
    }

    void Update()
    {
        for (int i = 0; i < values.Length; i++)
        {
            if (isIncreasing[i])
            {
                values[i] += increaseSpeed * Time.deltaTime;
                if (values[i] > maxValue)
                {
                    values[i] = maxValue;
                }
                valueTexts[i].text = values[i].ToString("F1");
            }
        }
        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] >= 100f && !goal[i])
            {
                GameManager.instance.Completado();
                GameManager.instance.SubPower(0.3f);
                buttons[i].enabled = false;
                goal[i] = true;
            }
        }
        if (GameManager.instance.dark && quitarCanvasOficina)
        {
            consola.enabled = false;
            oficina.enabled = true;
            StopIncreases();
            quitarCanvasOficina = false;
            meshCollider.enabled = true;
        }
    }

    public void StartIncrease(int index)
    {
        if (isIncreasing[index])
        {
            GameManager.instance.SubPower(0.3f);
            isIncreasing[index] = !isIncreasing[index];
        } else if (!isIncreasing[index])
        {
            GameManager.instance.AddPower(0.3f);
            isIncreasing[index] = !isIncreasing[index];
        }
    }

    private void StopIncreases()
    {
        for (int i = 0; i < isIncreasing.Length; i++)
        {
            isIncreasing[i] = false;
        }
    }
}
