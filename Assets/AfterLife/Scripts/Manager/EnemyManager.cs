using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script handles the spawning og anemy prefarbs in the game.
/// </summary>
public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [SerializeField]
    private GameObject drake_Prefab,
        vamp_Prefab;

    public Transform[] vamp_SpawnPoints,
        drake_SpawnPoints;

    [SerializeField]
    private int vamp_Enemy_Count,
        drake_Enemy_Count;

    private int initial_Vamp_Count,
        initial_Drake_Count;

    public float wait_Before_Spawn_Enemies_Time = 10f;

    // Use this for initialization
    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        initial_Vamp_Count = vamp_Enemy_Count;
        initial_Drake_Count = drake_Enemy_Count;

        SpawnEnemies();

        StartCoroutine("CheckToSpawnEnemies");
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    /// <summary>
    /// //This function spawns the enemies in the game.
    /// </summary>
    void SpawnEnemies()
    {
        SpawnVamp();
        SpawnDrake();
    }

    /// <summary>
    /// Spawn's vamp enemy character on the basis of enemy count
    /// Instantiates the vamp enemy prefab on the basis of vamp spawn points.
    /// </summary>
    void SpawnVamp()
    {
        int index = 0;

        for (int i = 0; i < vamp_Enemy_Count; i++)
        {
            if (index >= vamp_SpawnPoints.Length)
            {
                index = 0;
            }

            Instantiate(vamp_Prefab, vamp_SpawnPoints[index].position, Quaternion.identity);

            index++;
        }

        vamp_Enemy_Count = 0;
    }

    /// <summary>
    /// Spawn's drake enemy character on the basis of enemy count
    /// Instantiates the vamp enemy prefab on the basis of vamp spawn points.
    /// </summary>
    ///
    void SpawnDrake()
    {
        int index = 0;

        for (int i = 0; i < drake_Enemy_Count; i++)
        {
            if (index >= drake_SpawnPoints.Length)
            {
                index = 0;
            }

            Instantiate(drake_Prefab, drake_SpawnPoints[index].position, Quaternion.identity);

            index++;
        }

        drake_Enemy_Count = 0;
    }

    IEnumerator CheckToSpawnEnemies()
    {
        yield return new WaitForSeconds(wait_Before_Spawn_Enemies_Time);

        SpawnVamp();

        SpawnDrake();

        StartCoroutine("CheckToSpawnEnemies");
    }

    public void EnemyDied(bool vamp)
    {
        if (vamp)
        {
            vamp_Enemy_Count++;

            if (vamp_Enemy_Count > initial_Vamp_Count)
            {
                vamp_Enemy_Count = initial_Vamp_Count;
            }
        }
        else
        {
            drake_Enemy_Count++;

            if (drake_Enemy_Count > initial_Drake_Count)
            {
                drake_Enemy_Count = initial_Drake_Count;
            }
        }
    }

    public void StopSpawning()
    {
        StopCoroutine("CheckToSpawnEnemies");
    }
} // class
