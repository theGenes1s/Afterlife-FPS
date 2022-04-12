using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSound : MonoBehaviour
{
    
    [SerializeField]
    private AudioSource axeSound;

    [SerializeField]
    private AudioClip [] axeClips;

    void PlayAxeSound(){
        axeSound.clip = axeClips[Random.Range(0, axeClips.Length)];
        axeSound.Play();
    }
    // Start is called before the first frame update
    
} //end of class
