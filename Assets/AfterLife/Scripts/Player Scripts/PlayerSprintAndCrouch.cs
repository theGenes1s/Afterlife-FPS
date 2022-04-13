using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintAndCrouch : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public float sprint_Speed = 5.5f;
    public float move_Speed = 2.5f;
    public float crouch_Speed = 1f;
    private Transform lookRoot;
    private float stand_Height = 2f;
    private float crouch_Height = 1.6f;
    private bool is_Crouching;

    private PlayerFootSteps player_FootSteps;
    private float sprint_Volume = 1f;
    private float crouch_Volume = 0.1f;
    private float walk_Volume_Min = 0.2f,
        walk_Volume_Max = 0.6f;
    private float walk_Step_Distance = 0.4f;
    private float sprint_Step_Distance = 0.3f;
    private float crouch_Step_Distance = 0.5f;

    private PlayerStats player_Stats;
    private float sprintValue = 100f;
    private float sprintThreshold = 10f;

    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();

        lookRoot = transform.GetChild(0);

        player_FootSteps = GetComponentInChildren<PlayerFootSteps>();
        player_Stats = GetComponent<PlayerStats>();
    }

    void Start()
    {
        player_FootSteps.volume_Min = walk_Volume_Min;
        player_FootSteps.volume_Max = walk_Volume_Max;
        player_FootSteps.step_Distance = walk_Step_Distance;
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint()
    {
        // if we have stamina left and we are pressing the sprint button
        if (sprintValue > 0f)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching && playerMovement.is_Moving)
            {
                playerMovement.speed = sprint_Speed;
                player_FootSteps.step_Distance = sprint_Step_Distance;
                player_FootSteps.volume_Min = sprint_Volume;
                player_FootSteps.volume_Max = sprint_Volume;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching)
        {
            playerMovement.speed = move_Speed;

            player_FootSteps.step_Distance = walk_Step_Distance;
            player_FootSteps.volume_Min = walk_Volume_Min;
            player_FootSteps.volume_Max = walk_Volume_Max;
        }
        if (Input.GetKey(KeyCode.LeftShift) && !is_Crouching)
        {
            sprintValue -= sprintThreshold * Time.deltaTime;
            if (sprintValue <= 0f)
            {
                sprintValue = 0f;
                // reset speed and sound
                playerMovement.speed = move_Speed;
                player_FootSteps.step_Distance = walk_Step_Distance;
                player_FootSteps.volume_Min = walk_Volume_Min;
                player_FootSteps.volume_Max = walk_Volume_Max;
            }
            player_Stats.Display_staminaStats(sprintValue);
        }
        else
        {
            if (sprintValue != 100f)
            {
                sprintValue += (sprintThreshold / 2f) * Time.deltaTime;
                player_Stats.Display_staminaStats(sprintValue);
                if (sprintValue > 100f)
                {
                    sprintValue = 100f;
                }
            }
        }
    } //Sprinting

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //  if crouching stand-up
            if (is_Crouching)
            {
                lookRoot.localPosition = new Vector3(0f, stand_Height, 0f);
                playerMovement.speed = move_Speed;

                player_FootSteps.step_Distance = walk_Step_Distance;
                player_FootSteps.volume_Min = walk_Volume_Min;
                player_FootSteps.volume_Max = walk_Volume_Max;

                is_Crouching = false;
            }
            //  if not crouching crouch
            else
            {
                lookRoot.localPosition = new Vector3(0f, crouch_Height, 0f);
                playerMovement.speed = crouch_Speed;

                player_FootSteps.step_Distance = crouch_Step_Distance;
                player_FootSteps.volume_Min = crouch_Volume;
                player_FootSteps.volume_Max = crouch_Volume;

                is_Crouching = true;
            }
        } //if we press C, we crouch
    } //Crouching
} //class
