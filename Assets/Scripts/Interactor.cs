using TMPro;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    LayerMask mask;
    public float interactRange;
    public TextMeshProUGUI leyenda;
    RaycastHit hit;
    void Start()
    {
        mask = LayerMask.GetMask("Raycast Detect");
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out hit, interactRange, mask))
        {
            leyenda.gameObject.SetActive(true);
            Door();
        }
        else
        {
            leyenda.gameObject.SetActive(false);
        }
    }

    void Door()
    {
        if (hit.collider.CompareTag("Door"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                hit.collider.transform.GetComponent<Door>().Abrir();
            }
            if (Input.GetMouseButtonDown(1))
            {
                hit.collider.transform.GetComponent<Door>().Cerrar();
            }
        }
    }
}
