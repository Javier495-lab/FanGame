using System.Collections;
using TMPro;
using UnityEngine;

public class PorLoQ : MonoBehaviour
{
    public Vector3[] camPositions;
    public Vector3[] camRotations;
    private Vector3 targetPosition;
    private Vector3 targetRotation;

    public GameObject[] posButtons;
    private GameObject currentButtons;
    private Light flashlight;

    public float moveSpeed;
    public float rotateSpeed;
    public bool flashlightB;

    public float currenPos;

    private bool isDark = true;

    void Start()
    {
        currentButtons = posButtons[0];
        flashlight = GetComponentInChildren<Light>();
    }
    private void Update()
    {
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

        if (GameManager.instance.dark && isDark)
        {
            isDark = false;
            currenPos = 0;
            targetPosition = camPositions[0];
            targetRotation = camRotations[0];
            StartCoroutine(CamMovement());
        }
        else if (!GameManager.instance.dark && !isDark)
        {
            isDark = true;
        }
    }

    public void StartMoveAndRotate(int position)
    {
        currentButtons.SetActive(false);
        currentButtons = posButtons[position];
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
