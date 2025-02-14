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
    public BoxCollider palanca;
    public GameObject BeepingSound;

    [SerializeField] private bool[] isIncreasing = new bool[5];
    [SerializeField]private bool[] goal = new bool[5];

    private BoxCollider boxCollider;
    void OnMouseDown()
    {
        if (GameManager.instance.dark)
        {
            oficina.enabled = false;
            reset.enabled = true;
            boxCollider.enabled = false;
        }
    }
    public void Volver()
    {
        reset.enabled = false;
        oficina.enabled = true;
        palanca.enabled = true;
        boxCollider.enabled = true;
    }

    void Start()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i] = 0f;
            int index = i;
            buttons[i].onClick.AddListener(() => StartIncrease(index));
        }
        boxCollider = GetComponent<BoxCollider>();
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
            valueTexts[0].text = "Choeckpoint 1";
            valueTexts[1].text = "Choeckpoint 2";
            valueTexts[2].text = "Choeckpoint 3";
            valueTexts[3].text = "Choeckpoint 4";
            valueTexts[4].text = "Choeckpoint 5";
            Volver();
        }
    }

    public void StartIncrease(int index)
    {
        isIncreasing[index] = !isIncreasing[index];
        BeepingSound.SetActive(isIncreasing[index]);
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
