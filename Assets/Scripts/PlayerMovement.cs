using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private Transform playerTrans;
    private BoxCollider2D boxColl;
    private SpriteRenderer playerRender;

    private Animator _animator;
    public int moveSpeed = 8;
    public float jumpVelocity = 20f;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        playerTrans = gameObject.GetComponent<Transform>();
        boxColl = gameObject.GetComponent<BoxCollider2D>();
        playerRender = gameObject.GetComponent<SpriteRenderer>();
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)) {
            playerRender.flipX = true;
            //playerTrans.position += Vector3.left * moveSpeed * Time.deltaTime;
            playerBody.velocity = new Vector2(-1 * moveSpeed, playerBody.velocity.y);
        } else if(Input.GetKey(KeyCode.D)) {
            playerRender.flipX = false;
            //playerTrans.position += Vector3.right * moveSpeed * Time.deltaTime;
            playerBody.velocity = Vector2.right * moveSpeed;
        } 
        
        if(IsGrounded() && Input.GetKeyDown(KeyCode.W)) {

            playerBody.velocity = Vector2.up * jumpVelocity;
        }
        
    }

    private bool IsGrounded() {
        RaycastHit2D rayCast = Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0f, Vector2.down * .1f);
        
        return rayCast.collider != null;
    }
}
