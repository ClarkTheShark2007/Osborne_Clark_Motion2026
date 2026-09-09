using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawner : MonoBehaviour
{
    float spaceBetweenCords = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        squareSize();
        drawSqaure(0, Color.grey);

        if(Mouse.current.leftButton.isPressed)
        {
            drawSqaure(999f, Color.white);
        }
    }

    void drawSqaure(float duration, Color color)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector2 bl =  new Vector2(mousePos.x - spaceBetweenCords, mousePos.y - spaceBetweenCords);
        Vector2 tl =  new Vector2(mousePos.x - spaceBetweenCords, mousePos.y + spaceBetweenCords);
        Vector2 br =  new Vector2(mousePos.x + spaceBetweenCords, mousePos.y - spaceBetweenCords);
        Vector2 tr =  new Vector2(mousePos.x + spaceBetweenCords, mousePos.y + spaceBetweenCords);

        Debug.DrawLine(bl, tl, color, duration);
        Debug.DrawLine(bl, br, color, duration);
        Debug.DrawLine(tl, tr, color, duration);
        Debug.DrawLine(tr, br, color, duration);
    }

    void squareSize()
    {
        spaceBetweenCords += Mouse.current.scroll.ReadValue().y;
    }
}
