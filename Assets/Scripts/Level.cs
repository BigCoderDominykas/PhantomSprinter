using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform target;
    public GameObject platform;
    public AudioClip clip;

    Enemy[] enemies;
    AudioSource source;

    private void Start()
    {
        GetEnemies();
        foreach (Enemy enemy in enemies)
        {
            enemy.target = enemy.transform;
        }
        source = GetComponent<AudioSource>();
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
            if (!platform.active)
            {
                platform.SetActive(true);
                source.PlayOneShot(clip);
            }
        }
    }

    public void GetEnemies()
    {
        enemies = GetComponentsInChildren<Enemy>(false);
    }
}
