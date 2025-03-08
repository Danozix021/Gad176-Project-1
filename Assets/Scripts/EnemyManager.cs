using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemies> enemies = new List<Enemies>();

    public GameObject meleeEnemyPrefab;
    public GameObject rangedEnemyPrefab;

    public int maxEnemies = 6;

    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEnemyToList(Enemies enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemyFromList(Enemies enemy)
    {
        enemies.Remove(enemy);

        if (enemies.Count < maxEnemies)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint =spawnPoints[spawnIndex];

        int randomIndex = Random.Range(0, 2);
        GameObject enemyPrefab = (randomIndex == 0) ? meleeEnemyPrefab : rangedEnemyPrefab;

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }


}
