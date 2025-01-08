using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinCondition : MonoBehaviour
{
    public float[] values = new float[6]; // Los 6 valores
    public float maxValue = 100f;         // Valor m�ximo
    public float increaseSpeed = 20f;     // Velocidad de incremento
    public Button[] buttons;             // Referencias a los botones
    public Text[] valueTexts;            // Referencias a los textos que muestran los valores

    private bool[] isIncreasing = new bool[6]; // Bandera para saber si el bot�n est� presionado

    void Start()
    {
        // Inicializar valores a 0
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = 0f;
            int index = i; // Necesario para evitar problemas con closures en lambdas
            buttons[i].onClick.AddListener(() => StartIncrease(index));
        }
    }

    void Update()
    {
        // Incrementar valores si est�n en aumento
        for (int i = 0; i < values.Length; i++)
        {
            if (isIncreasing[i])
            {
                values[i] += increaseSpeed * Time.deltaTime;
                if (values[i] > maxValue)
                {
                    values[i] = maxValue;
                }
                valueTexts[i].text = values[i].ToString("F1"); // Actualizar el texto
            }
        }
    }

    public void StartIncrease(int index)
    {
        isIncreasing[index] = true; // Iniciar el incremento
        Invoke("StopIncrease", 0.1f); // Detener el incremento despu�s de un breve lapso
    }

    public void StopIncrease()
    {
        for (int i = 0; i < isIncreasing.Length; i++)
        {
            isIncreasing[i] = false; // Detener todos los incrementos
        }
    }
}
