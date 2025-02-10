using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class PosButtonsPorFase
{
    public GameObject[] posButtons;
}

public class Oficina : MonoBehaviour
{
    [Header("Camara")]
    public Vector3[] camPositions;
    public Vector3[] camRotations;
    private Vector3 targetPosition; 
    private Vector3 targetRotation;
    [Header("Botones para el movimiento")]
    public PosButtonsPorFase[] fase;
    private GameObject currentButtons;
    private Light flashlight;
    [Header("Movimiento")]
    public float moveSpeed;
    public float rotateSpeed;
    public bool flashlightB;
    [Header("Fase y posición")]
    public float currenPos;
    public int currenPhase;

    private bool isDark = true;
    private bool leverTrigger = true;

    public static GameManager Instance { get; private set; }

    void Start()
    {
        currentButtons = fase[0].posButtons[0];
        flashlight = GetComponentInChildren<Light>();
    }
    private void Update()
    {
        #region fase
        if (GameManager.instance.dark)
        {
            currenPhase = 2;
        }
        else if (GameManager.instance.apagadoSeguro)
        {
            currenPhase = 1;
        }
        else
        {
            currenPhase = 0;
        }
        #endregion
        #region linterna
        if (GameManager.instance.dark || GameManager.instance.apagadoSeguro)
        {
            if (Input.GetKeyDown(KeyCode.F) && currenPos == 2)
            {
                flashlightB = !flashlightB;
            }
            if (flashlightB)
            {
                flashlight.enabled = true;
                flashlightB = true;
            }
            else if (!flashlightB)
            {
                flashlight.enabled = false;
                flashlightB = false;
            }
        }
        else
        {
            flashlight.enabled = false;
        }
        #endregion
        #region dark
        if (GameManager.instance.dark && isDark)
        {
            isDark = false;
            StartMoveAndRotate(0);
        }
        else if (!GameManager.instance.dark && !isDark)
        {
            StartMoveAndRotate(0);
            isDark = true;
        }
        if (GameManager.instance.apagadoSeguro && leverTrigger && currenPos == 3)
        {
            leverTrigger = false;
            StartMoveAndRotate(3);
        }
        else if (!GameManager.instance.apagadoSeguro && !leverTrigger && currenPos == 3)
        {
            StartMoveAndRotate(2);
            leverTrigger = true;
        }
        #endregion
    }


    public void StartMoveAndRotate(int button)
    {
        int position = button;
        switch (currenPhase)
        {
            case 0:
                if (button == 2)
                {
                    position = 3;
                }
                break;

            case 2:
                if (button == 1)
                {
                    position = 2;
                }
                break;

        }

        currentButtons.SetActive(false);
        currentButtons = fase[currenPhase].posButtons[button];
        targetPosition = camPositions[position];
        targetRotation = camRotations[position];
        currenPos = position;
        StartCoroutine(CamMovement());
    }

    private IEnumerator CamMovement()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            Quaternion targetRot = Quaternion.Euler(targetRotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);
            if ((Vector3.Distance(transform.position, targetPosition) < 0.1f && Quaternion.Angle(transform.rotation, targetRot) < 0.1f))
            {
                currentButtons.SetActive(true);
                yield break; 
            }
            yield return null;
        }
    }
}
