using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Aguja : MonoBehaviour
{
    [Range(0, 1)] private float rotacion;
    private float minAngle = -146f;
    private float maxAngle = 214f;
    void Update()
    {
        rotacion = GameManager.instance.power;
        float angle = Mathf.Lerp(minAngle, maxAngle, 1f - rotacion);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angle);
    }
}
