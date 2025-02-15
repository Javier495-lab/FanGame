using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public GameObject normas;
    private bool isPhoneGuy = false;
    public void Load()
    {
        SceneManager.LoadScene(1);
    }
    public void phoneGuy()
    {
        if (!isPhoneGuy)
        {
            isPhoneGuy = true;
            normas.SetActive(true);
        }
        else
        {
            isPhoneGuy = false;
            normas.SetActive(false);
        }
    }
}
