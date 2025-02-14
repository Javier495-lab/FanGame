using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    private float blinkSpeed = 0.1f;
    private RawImage icon;

    private void OnEnable()
    {
        icon = GetComponent<RawImage>();
        StartCoroutine(BlinkCoroutine());
    }

    private IEnumerator BlinkCoroutine()
    {
        while (true)
        {
            icon.enabled = true;
            yield return new WaitForSeconds(blinkSpeed);

            icon.enabled=false;
            yield return new WaitForSeconds(blinkSpeed);
        }
    }
}
