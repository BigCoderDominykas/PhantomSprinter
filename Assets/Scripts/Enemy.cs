using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public int particleCount;
    //public GameObject particle;

    public float speed;
    public Transform player;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var finalPosition = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        rb.MovePosition(finalPosition);
    }

    private void OnDestroy()
    {
        /*for(int i = 0; i < particleCount; i++)
        {
            //var offset = Random.insideUnitSphere;
            particle.transform.localScale = new Vector3(Random.Range(0.01f, 0.5f), Random.Range(0.01f, 0.5f), Random.Range(0.01f, 0.5f));
            var rotation = Random.rotation;
            Instantiate(particle, transform.position, rotation);
        }*/
    }
}
