using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovment : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    private Vector3 movedelta;
    private RaycastHit2D raycastHit;
    public float speed = 1.0f;
    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    
    private void fixedupdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");



    }
}
