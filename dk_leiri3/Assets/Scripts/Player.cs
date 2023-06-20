using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D player;

    private float horizontalInput;
    private Vector2 movement;
    public float moveSpeed = 5f;

    public float jumpForce = 5f;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        movement.x = horizontalInput * moveSpeed;

        if(Input.GetKeyDown("space") && grounded){
            player.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate() {
        player.position += movement * Time.fixedDeltaTime;
    }

    void OnTriggerStay2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

}
