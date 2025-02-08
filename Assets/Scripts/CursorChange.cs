using UnityEngine;
using UnityEngine.EventSystems;

public class CursorChange : MonoBehaviour
{
    public Texture2D cursorHand; // Imagen del cursor de mano
    private Texture2D cursorDefault; // Cursor por defecto

    void Start()
    {
        cursorDefault = null; // Usa el cursor del sistema
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorHand, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
    }
}
