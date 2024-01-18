using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Transform startPosition;

    Rigidbody rb;

    void Start()
    {
        startPosition = transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var finalPosition = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rb.MovePosition(finalPosition);
    }
}
