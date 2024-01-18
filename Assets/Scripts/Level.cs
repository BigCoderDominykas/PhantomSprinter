using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform target;

    Enemy[] enemies;

    private void Start()
    {
        GetEnemies();
        foreach (Enemy enemy in enemies)
        {
            enemy.target = enemy.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Player"))
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.target = target;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name.Contains("Player"))
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.target = enemy.startPosition;
            }
        }
    }

    private void Update()
    {
        if (enemies.Length == 1)
            GetEnemies();
        if (enemies.Length == 0)
        {
            // Fade in platform
        }
    }

    public void GetEnemies()
    {
        enemies = GetComponentsInChildren<Enemy>(false);
    }
}
