using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController character_Controller;
    private Vector3 move_Direction;
    public float speed = 2.5f;
    private float gravity = 20f;
    public float jump_Force = 10.0f;
    private float vertical_Velocity;

    public bool is_Moving = false;

    void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        LockAnDUnlockCursor();
    }
    void MovePlayer()
    {
        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f,
         Input.GetAxis(Axis.VERTICAL));
        move_Direction = transform.TransformDirection(move_Direction);
        move_Direction *= speed * Time.deltaTime;
        ApplyGravity();
        character_Controller.Move(move_Direction);
        is_Moving = true;


    } //movement of player

    void ApplyGravity()
    {

        vertical_Velocity -= gravity * Time.deltaTime;
        PlayerJump(); //jump
        vertical_Velocity -= gravity * Time.deltaTime;
        move_Direction.y = vertical_Velocity * Time.deltaTime;
    } //gravity of player

    void PlayerJump()
    {
        if (character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            vertical_Velocity = jump_Force;
        }


    } //jump of player
    void LockAnDUnlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                //Debug.Log("Cursor is now unlocked");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                //Debug.Log("Cursor is locked");
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    } // Lock and Unlock Cursor
}

