using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemies
{
    // Start is called before the first frame update
    new void Start()
    {
        enemyHealth = 8;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }
}
