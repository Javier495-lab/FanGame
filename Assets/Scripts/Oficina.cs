using System.Collections;
using TMPro;
using UnityEngine;

public class Oficina : MonoBehaviour
{
    public Vector3[] camPositions;
    public Vector3[] camRotations;
    private Vector3 targetPosition; 
    private Vector3 targetRotation;

    public GameObject[] posButtons;
    private GameObject currentButtons;
    
    public float moveSpeed;   
    public float rotateSpeed;

    public float currenPos;

    void Start()
    {
        currentButtons = posButtons[0];
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
                Debug.Log("Destino");
                currentButtons.SetActive(true);
                yield break; 
            }
            yield return null;
        }
    }
}
