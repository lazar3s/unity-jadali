using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private BoxCollider2D boxcolider;
    private Vector3 movedelta;
    private RaycastHit2D rayhit;
    public float speed = 1.0f;
    
    private void Start()
    {
        boxcolider = GetComponent<BoxCollider2D>();
    }

    
        private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        

        // to reset movement 
        movedelta = new Vector3(x,y,0);

        // to swap sprite direction from left or right

        if (movedelta.x > 0)
            transform.localScale = Vector3.one;
        else if (movedelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        rayhit = Physics2D.BoxCast(transform.position, boxcolider.size, 0, new Vector2(0, movedelta.y), Mathf.Abs(movedelta.y * Time.deltaTime), LayerMask.GetMask("player", "blocking"));
        if (rayhit.collider == null)
        {
            // make player move
            transform.Translate(0, movedelta.y * Time.deltaTime * speed, 0);
        }
        rayhit = Physics2D.BoxCast(transform.position, boxcolider.size, 0, new Vector2(movedelta.x, 0), Mathf.Abs(movedelta.x * Time.deltaTime), LayerMask.GetMask("player", "blocking"));
        if (rayhit.collider == null)
        {
            transform.Translate(movedelta.x * Time.deltaTime * speed, 0, 0);
        }

    }
}
