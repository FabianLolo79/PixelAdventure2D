using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float runSpeed = 2.0f;
    public float JumpSpeed = 3.0f;

    Rigidbody2D _rbPlayer;

    //Variables para el salto mejorado

    public bool betterJump = false;

    public float fallMultiplier = 0.5f;

    public float lowJumpMultiplier = 1.0f;


    private void Awake()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
    }

    
    // FixedUpdate mejor para físicas
    void FixedUpdate()
    {
        //Movimiento del personaje
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            _rbPlayer.velocity = new Vector3(runSpeed, _rbPlayer.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            _rbPlayer.velocity = new Vector3(-runSpeed, _rbPlayer.velocity.y);
        }
        else
        {
            _rbPlayer.velocity = new Vector2(0, _rbPlayer.velocity.y);
        }

        if (Input.GetKey("space") && Checkground.isGrounded)
        {
            _rbPlayer.velocity = new Vector2(_rbPlayer.velocity.x, JumpSpeed);
        }

        if(betterJump)
        {
            if (_rbPlayer.velocity.y < 0)
            {
                _rbPlayer.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }

            if (_rbPlayer.velocity.y > 0 && !Input.GetKey("space"))
            {
                _rbPlayer.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }
}
