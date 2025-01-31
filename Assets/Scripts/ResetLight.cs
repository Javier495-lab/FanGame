using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ResetLight : MonoBehaviour
{
    public Canvas reset;
    public Canvas oficina;
    [Range(0, 100)] public float[] checkpoints;
    public float maxValue = 100f;
    public float increaseSpeed;
    public Button[] buttons;
    public TextMeshProUGUI[] valueTexts;

    [SerializeField] private bool[] isIncreasing = new bool[5];
    [SerializeField]private bool[] goal = new bool[5];
    void OnMouseDown()
    {
        if (GameManager.instance.dark)
        {
            oficina.enabled = false;
            reset.enabled = true;
        }
    }
    public void Volver()
    {
        reset.enabled = false;
        oficina.enabled = true;
    }

    void Start()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i] = 0f;
            int index = i;
            buttons[i].onClick.AddListener(() => StartIncrease(index));
        }
    }

    void Update()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            if (isIncreasing[i])
            {
                checkpoints[i] += increaseSpeed * Time.deltaTime;
                if (checkpoints[i] > maxValue)
                {
                    checkpoints[i] = maxValue;
                }
                valueTexts[i].text = checkpoints[i].ToString("F1");
            }
        }
        for (int i = 0; i < checkpoints.Length; i++)
        {
            if (checkpoints[i] >= 100f && !goal[i])
            {
                GameManager.instance.CheckCompletado();
                buttons[i].enabled = false;
                goal[i] = true;
            }
        }
        
        if (completado())
        {
            for (int i = 0; i < checkpoints.Length; i++)
            {
                checkpoints[i] = 0f;
            }
            for (int i = 0; i < goal.Length; i++)
            {
                goal[i] = false;
            }
            Volver();
        }
    }

    public void StartIncrease(int index)
    {
        isIncreasing[index] = !isIncreasing[index];
    }

    bool completado()
    {
        foreach (bool i in goal)
        {
            if (!i) return false;
        }
        return true;
    }
}
