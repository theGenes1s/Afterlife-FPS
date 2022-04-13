using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private EnemyAnimator enemy_Anim;
    private NavMeshAgent navAgent;
    private EnemyController enemy_Controller;

    public float health = 100f;

    public bool is_Player,
        is_Drake,
        is_Vamp;

    private bool is_Dead;

    private EnemyAudio enemyAudio;

    private PlayerStats player_Stats;

    [SerializeField]
    private Button pause_Button;

    [SerializeField]
    private Button resume_Button;

    [SerializeField]
    private Text title_Text;

    [SerializeField]
    private Button quit_Button;

    void Awake()
    {
        if (is_Drake || is_Vamp)
        {
            enemy_Anim = GetComponent<EnemyAnimator>();
            enemy_Controller = GetComponent<EnemyController>();
            navAgent = GetComponent<NavMeshAgent>();

            // get enemy audio
            enemyAudio = GetComponentInChildren<EnemyAudio>();
        }

        if (is_Player)
        {
            //Assignments to the reference GameObjects.
            player_Stats = GetComponent<PlayerStats>();
            pause_Button = GameObject.Find("Pause Button").GetComponent<Button>();
            resume_Button = GameObject.Find("ResumeButton").GetComponent<Button>();
            title_Text = GameObject.Find("Title").GetComponent<Text>();
            quit_Button = GameObject.Find("Quit Button").GetComponent<Button>();
        }
    }

    void Update() { }

    public void ApplyDamage(float damage)
    {
        // if player dead return
        if (is_Dead)
            return;

        health -= damage;

        if (is_Player)
        {
            // show the stats of health and stamina
            player_Stats.Display_HealthStats(health);
        }

        if (is_Drake || is_Vamp)
        {
            if (enemy_Controller.Enemy_State == EnemyState.PATROL)
            {
                enemy_Controller.chase_Distance = 50f;
            }
        }

        if (health <= 0f)
        {
            PlayerDied();

            is_Dead = true;
        }
    } // apply damage

    void PlayerDied()
    {
        if (is_Vamp)
        {
            navAgent.velocity = Vector3.zero;
            navAgent.isStopped = true;
            enemy_Controller.enabled = false;

            enemy_Anim.Dead();

            StartCoroutine(DeadSound());
            // EnemyManager spawn more enemies
            EnemyManager.instance.EnemyDied(true);
        }

        if (is_Drake)
        {
            navAgent.velocity = Vector3.zero;
            navAgent.isStopped = true;
            enemy_Controller.enabled = false;

            enemy_Anim.Dead();

            StartCoroutine(DeadSound());
            // EnemyManager spawn more enemies
            EnemyManager.instance.EnemyDied(false);
        }

        if (is_Player)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyController>().enabled = false;
            }

            // call enemy manager to stop spawning enemis
            EnemyManager.instance.StopSpawning();

            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<WeaponController>().GetCurrentWeapon().gameObject.SetActive(false);
        }

        if (tag == Tags.PLAYER_TAG)
        {
            Invoke("RestartGame", 3f); //when player is dead game restarts after 3 seconds of wait time.
        }
        else
        {
            Invoke("TurnOffGameObject", 3f);
        }
    } // player died


    /// <summary>
    /// Some last minute changes to the game regarding UI
    /// Methods like restart, quit, pause, resume are part of this block 
    /// Which is self explanatory.
    /// </summary>
    /// 
    /// 
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pause_Button.gameObject.SetActive(false);
        resume_Button.gameObject.SetActive(true);
        title_Text.gameObject.SetActive(true);
        quit_Button.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        resume_Button.gameObject.SetActive(false);
        pause_Button.gameObject.SetActive(true);
        title_Text.gameObject.SetActive(false);
        quit_Button.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit(); //quit the game 
    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }

    IEnumerator DeadSound()
    {
        yield return new WaitForSeconds(0.3f);
        enemyAudio.Play_DeadSound();
    }
} // class
