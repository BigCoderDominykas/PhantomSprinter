﻿using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rb;
    public float jumpStrength = 2;
    public event System.Action Jumped;

    public AudioSource runningSource;
    public AudioSource source;
    public AudioClip jump;
    public AudioClip land;

    bool isAirborne;
    float landDelay;

    [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundCheck groundCheck;


    void Reset()
    {
        // Try to get groundCheck.
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Awake()
    {
        // Get rigidbody.
        rb = GetComponent<Rigidbody>();

        runningSource = System.Array.Find(GetComponentsInChildren<AudioSource>(), a => a.name == "RunningAudio");
        source = System.Array.Find(GetComponentsInChildren<AudioSource>(), a => a.name == "JumpLandAudio");
    }

    void LateUpdate()
    {
        if (isAirborne && groundCheck.isGrounded && landDelay >= 0.05f)
        {
            source.PlayOneShot(land);
            isAirborne = false;
            landDelay = 0;

            if (PlayerMovement.isMoving)
                runningSource.mute = false;
        }

        // Jump when the Jump button is pressed and we are on the ground.
        if (!groundCheck || groundCheck.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * 100 * jumpStrength);
                Jumped?.Invoke();

                runningSource.mute = true;
                source.PlayOneShot(jump);

                isAirborne = true;
            }
            else if (PlayerMovement.isMoving)
                runningSource.mute = false;
            else
                runningSource.mute = true;
        }
        else
        {
            landDelay += Time.deltaTime;

            if (PlayerMovement.isMoving)
                runningSource.mute = true;
        }
    }
}