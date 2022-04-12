using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{

    private AudioSource footSteps_Sound;

    [SerializeField]
    private AudioClip[] footSteps_Clips;
    private CharacterController character_Controller;
    [HideInInspector]
    public float volume_Min, volume_Max;
    public float accumulated_Distance;
    [HideInInspector]
    public float step_Distance;


    // Start is called before the first frame update
    void Awake()
    {
        footSteps_Sound = GetComponent<AudioSource>();
        character_Controller = GetComponentInParent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckToPlayFootStepsSound();
    }
    void CheckToPlayFootStepsSound()
    {
        if (!character_Controller.isGrounded)
            return;
        if (character_Controller.velocity.sqrMagnitude > 0)
        {
            /// <summary>
            /// accumulated distance is a value how far player can go
            /// like walk,sprint and crouch 
            /// until a footstep sound will be played
            /// </summary>

            accumulated_Distance += Time.deltaTime;
            if (accumulated_Distance > step_Distance)
            {
                footSteps_Sound.volume = Random.Range(volume_Min, volume_Max);
                footSteps_Sound.clip = footSteps_Clips[Random.Range(0, footSteps_Clips.Length)];
                footSteps_Sound.Play();
                accumulated_Distance = 0f;
            }
        }
        else
        {
            accumulated_Distance = 0f;
        }
    }   //check foot steps sound
}//class 
