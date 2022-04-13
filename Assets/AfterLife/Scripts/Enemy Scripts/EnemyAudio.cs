using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip scream_Clip,
        die_Clip;

    [SerializeField]
    private AudioClip[] attack_Clips;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Below functions to play enemy reaction sounds when player attacks OR enemy dies.
    /// These code blocks are self explanatory.
    /// </summary>

    public void Play_ScreamSound()
    {
        audioSource.clip = scream_Clip;
        audioSource.Play();
    }

    public void Play_AttackSound()
    {
        int randomIndex = Random.Range(0, attack_Clips.Length);
        audioSource.clip = attack_Clips[randomIndex];
        audioSource.Play();
    }

    public void Play_DeadSound()
    {
        audioSource.clip = die_Clip;
        audioSource.Play();
    }
}
