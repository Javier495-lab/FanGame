using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void Load()
    {
        SceneManager.LoadScene(1);
    }
}
