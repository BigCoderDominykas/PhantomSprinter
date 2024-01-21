using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public static bool isMoving = false;
    public string deathScreen;
    public string winScreen;
    public float wallrunRotation;
    public Transform cam;

    float rot, target;
    Rigidbody rb;

    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();



    void Awake()
    {
        // Get the rigidbody on this.
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float targetMovingSpeed = speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // isMoving
        if (Mathf.Abs(targetVelocity.x) > 0.2f || Mathf.Abs(targetVelocity.y) > 0.2f)
            isMoving = true;
        else
            isMoving = false;

        // Apply movement.
        rb.velocity = transform.rotation * new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.y);

        // Fell off the map
        if(transform.position.y < -10)
        {
            SceneManager.LoadScene(deathScreen);
        }

        // Rotate camera on wallrun
        rot += (target - rot) * 0.2f;
        cam.localEulerAngles = new Vector3(0, 0, rot);     
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(deathScreen);
        }
        else if (collision.gameObject.CompareTag("Wallrun") && Math.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.constraints = RigidbodyConstraints.FreezeRotationX;
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;

            rot = 0;
            target = wallrunRotation * (Input.GetAxis("Horizontal") / Math.Abs(Input.GetAxis("Horizontal")));

            speed *= 2;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wallrun"))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX;
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;

            target = 0;

            speed /= 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Win"))
        {
            SceneManager.LoadScene(winScreen);
        }
    }
}
