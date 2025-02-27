using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemies> enemies = new List<Enemies>();

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
    }

    public void SpawnEnemy()
    {

    }


}
