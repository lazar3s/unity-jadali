using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float directionSmooth = 0.1f;
    public Rigidbody2D rb;
    public Camera cam;
    public CircleCollider2D collider2D;
    
    private Vector2 movement;
    private Vector2 mousePos;
    private Vector2 effectiveDirection = Vector2.zero;
    void Update()
    {
        // input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        // Movement
        if (movement.x == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x * 5f, rb.velocity.y);
        }
        effectiveDirection = Vector2.Lerp(effectiveDirection, movement, directionSmooth);
        rb.MovePosition(rb.position + effectiveDirection * playerSpeed * Time.fixedDeltaTime);
        // Rotation
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
