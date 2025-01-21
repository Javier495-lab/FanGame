using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Aguja : MonoBehaviour
{
    [Range(0, 1)] private float rotacion;
    private float minAngle = 146f;
    private float maxAngle = -146;
    void Update()
    {
        rotacion = GameManager.instance.power;
        float angle = Mathf.Lerp(minAngle, maxAngle, rotacion);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angle);
    }
}
