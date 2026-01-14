using UnityEngine;
using UnityEngine.InputSystem;

public class PointAtCursor : MonoBehaviour
{
    void Update()
    {
        //get the position of the mouse cursor in the world
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //turn the vector into an angle
        float mouseAngle = Vector2.SignedAngle(Vector2.up, mousePos - (Vector2)transform.position);

        //use that angle to rotate the gameObject
        transform.rotation = Quaternion.AngleAxis(mouseAngle, transform.forward);

        //transform.rotation = Quaternion.AngleAxis(Vector2.SignedAngle(transform.position, (Vector2)transform.position - mousePos), transform.forward);
    }
}
