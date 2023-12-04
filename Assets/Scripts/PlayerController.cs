using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 1f;
    [SerializeField] float jumpForce = 1f;
    [SerializeField] float lineLength = 1f;
    [SerializeField] float offset = 1f;

    [SerializeField] bool isJumping = false;
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed * Input.GetAxisRaw("Horizontal"), GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetAxisRaw("Horizontal") == 1)GetComponent<SpriteRenderer>().flipX = false;
        if (Input.GetAxisRaw("Horizontal") == -1)GetComponent<SpriteRenderer>().flipX = true;


        if (Input.GetAxisRaw("Horizontal") == 0)GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        
        if (Input.GetButtonDown("Fire1") && !isJumping)GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        Vector2 origin = new Vector2(transform.position.x, transform.position.y - offset);
        Vector2 target = new Vector2 (transform.position.x, transform.position.y - lineLength);
        Debug.DrawLine(origin, target, Color.black);

        RaycastHit2D raycast = Physics2D.Raycast(origin, Vector2.down, lineLength);

        if(raycast.collider == null) isJumping = true;
        else isJumping = false;
    }
}
