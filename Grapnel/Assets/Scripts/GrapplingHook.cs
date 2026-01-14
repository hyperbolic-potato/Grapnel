using UnityEngine;
using UnityEngine.InputSystem;

public class GrapplingHook : MonoBehaviour
{
    LineRenderer lr;
    Rigidbody2D rb;

    public LayerMask grappleableObjects;
    public float maxGrappleDistance, grappleStrength;
    private float grappleLength;
    bool isGrappled;
    Vector2 grapplePoint, grappleVector;
    

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        rb = transform.parent.parent.gameObject.GetComponent<Rigidbody2D>();
        isGrappled = false;
    }

    private void Update()
    {
        
        if (isGrappled)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, grapplePoint);

            //get the vector from the character to the point it is grappling to
            grappleVector = grapplePoint - (Vector2)transform.position;

            GrappleLengthCorrection();
        }

        lr.enabled = isGrappled;

    }

    public void Grapple(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
            if (!isGrappled)
            {
                
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, maxGrappleDistance, grappleableObjects);

                if (hit)
                {
                    grapplePoint = hit.point;


                    grappleLength = (grapplePoint - (Vector2)transform.position).magnitude;

                    isGrappled = true;
                }
            }
            else
            {
                isGrappled = false;
            }
        }
        

        
    }

    public void GrappleLengthCorrection() // will keep the grapple from getting longer than it was when it was fired by applying forces to the character
    {
        if (grappleVector.magnitude > grappleLength)
        {
            Vector2 error = grappleVector - grappleVector.normalized * grappleLength;
            rb.AddForce(error * grappleStrength);
        }
    }
}
