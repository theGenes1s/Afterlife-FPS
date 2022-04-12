using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    private AudioSource audioSource;
   [SerializeField]
    private AudioClip scream_Clip , die_Clip ;
 [SerializeField]
 private AudioClip [] attack_Clips;

 void Awake(){
        audioSource = GetComponent<AudioSource>();
 }

 public void Play_ScreamSound(){
     audioSource.clip = scream_Clip;
     audioSource.Play();}
     public void Play_AttackSound(){
         int randomIndex = Random.Range(0,attack_Clips.Length);
         audioSource.clip = attack_Clips[randomIndex];
         audioSource.Play();
     }
     public void Play_DeadSound(){
         audioSource.clip = die_Clip;
         audioSource.Play();
     }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
