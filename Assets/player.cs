using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Debug.Log(x);
        Debug.Log(y);
         
        //reset move delta 
        moveDelta = new Vector3(x,y,0);

        //swap sprite direction depending on momentum
        if(moveDelta.x > 0)
         transform.localScale = Vector3.one;

        else if(moveDelta.x < 0)
         transform.localScale = new Vector3(-1,1,1);    
        

        //checks the y axis for space to move up
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0,moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Mobs", "Blocking"));
        if(hit.collider == null)
        {
        //movement
        transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        //checks the y axis for space to move to the side
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Mobs", "Blocking"));
        if(hit.collider == null)
        {    
        //movement
        transform.Translate(moveDelta.x * Time.deltaTime,0,0);
        }

    }
}
