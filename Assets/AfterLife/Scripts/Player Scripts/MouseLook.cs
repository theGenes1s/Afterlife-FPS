using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private Transform playerRoot,
        lookRoot;

    [SerializeField]
    private bool invert;

    [SerializeField]
    private bool can_Unlock = true;

    [SerializeField]
    private float sensivity = 5f;

    [SerializeField]
    private int smooth_Steps = 10;

    [SerializeField]
    private float smooth_Weight = 0.4f;

    [SerializeField]
    private float roll_Angle = 10.0f;

    [SerializeField]
    private float roll_Speed = 3.0f;

    [SerializeField]
    private Vector2 default_Look_Limits = new Vector2(-70.0f, 80.0f);
    private Vector2 look_Angles;
    private Vector2 current_Mouse_Look;
    private Vector2 smooth_Move;
    private float current_Roll_Angle;
    private int last_Look_Frame;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //set mouse cursor state locked in start.
    }

    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked) // check is cursor is locked than look around in scene.
        {
            LookAround();
        }
    }

    /// <summary>
    /// look around in scene on basis of mouse movement.
    /// </summary>
    void LookAround()
    {
        current_Mouse_Look = new Vector2(
            Input.GetAxis(MouseAxis.MOUSE_Y),
            Input.GetAxis(MouseAxis.MOUSE_X)
        );
        look_Angles.x += current_Mouse_Look.x * sensivity * (invert ? 1f : -1f);
        look_Angles.y += current_Mouse_Look.y * sensivity;

        look_Angles.x = Mathf.Clamp(look_Angles.x, default_Look_Limits.x, default_Look_Limits.y); //using clamp to limit the angle of the camera

        lookRoot.localRotation = Quaternion.Euler(look_Angles.x, 0f, 0f);
        playerRoot.localRotation = Quaternion.Euler(0f, look_Angles.y, 0f);
    } //look around
}
