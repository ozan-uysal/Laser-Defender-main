using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed =10f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 5f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public Transform GetStartingWaypoint() 
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints() 
    {
        List <Transform> waypoints = new List <Transform>();

        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
            
        }
        return waypoints;
    }

    public float GetMoveSpeed()
    { 
        return moveSpeed;
    }
    public int GetEnemyCount()
    { 
        return enemyPrefabs.Count;
    }

    public GameObject getEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
    public float GetRandomSpawntime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance, timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }

}
