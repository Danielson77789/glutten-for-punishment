using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private Transform playerTrans;
    public int moveSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        playerTrans = gameObject.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) {
            playerTrans.position += Vector3.left * moveSpeed * Time.deltaTime;
        } else if(Input.GetMouseButton(1)) {
            playerTrans.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        
    }
}
