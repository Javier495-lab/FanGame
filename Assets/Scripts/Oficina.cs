using System.Collections;
using TMPro;
using UnityEngine;

public class Oficina : MonoBehaviour
{
    public Vector3[] camPositions;
    public Vector3[] camRotations;
    private Vector3 targetPosition; 
    private Vector3 targetRotation;

    public Canvas[] posButtons;
    private Canvas currentButtons;
    
    public float moveSpeed;   
    public float rotateSpeed; 

    void Start()
    {
        currentButtons = posButtons[0];
    }

    public void StartMoveAndRotate(int position)
    {
        currentButtons.enabled = false;
        currentButtons = posButtons[position];
        targetPosition = camPositions[position];
        targetRotation = camRotations[position];
        currentButtons.enabled = true;

        StartCoroutine(CamMovement());
    }

    private IEnumerator CamMovement()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            Quaternion targetRot = Quaternion.Euler(targetRotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);
            if ((transform.position == targetPosition)  && (transform.rotation == targetRot))
            {
                Debug.Log("Destino");
                yield break; 
            }
            yield return null;
        }
    }
}
