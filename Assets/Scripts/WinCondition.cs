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

    public bool[] isIncreasing = new bool[6];
    public bool[] goal = new bool[6];

    void OnMouseDown()
    {
        if (!GameManager.instance.dark)
        {
            oficina.enabled = false;
            consola.enabled = true;
        }
    }
    public void Volver()
    {
        consola.enabled = false;
        oficina.enabled = true;
    }

    void Start()
    {
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = 0f;
            int index = i;
            buttons[i].onClick.AddListener(() => StartIncrease(index));
        }
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
                buttons[i].enabled = false;
                goal[i] = true;
            }
        }
            if (GameManager.instance.dark)
        {
            consola.enabled = false;
            oficina.enabled = true;
            StopIncreases();
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
