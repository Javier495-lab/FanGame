using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Range(0, 1)] public float power;
    public bool dark = false;
    public static GameManager instance { get; private set; }

    private void Update()
    {
        if (power >= 1)
        {
            dark = true;
        }
    }
    public void AddPower(float plusPower)
    {
        power += plusPower;
    }

    public void SubPower(float subPower)
    {
        power -= subPower;
    }

    public void ResetPower()
    {
        power = 0;
        dark = false;
    }
}
