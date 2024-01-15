using UnityEngine;

public class Sword : MonoBehaviour
{
    public static bool canKill;

    public Transform cam;
    public Transform sword;
    public GameObject hitBox;

    public AudioClip slash;

    float hitWindow = 0.1f;
    float delay = 0.9f;
    float delayCopy;

    Animator animator;
    AudioSource source;

    void Start()
    {
        animator = sword.gameObject.GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        delayCopy = 0;
    }

    void Update()
    {
        transform.localEulerAngles = new Vector3(cam.transform.eulerAngles.x, 0, 0);
        
        delayCopy -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && delayCopy <= 0)
        {
            animator.Play("SwordSwing");

            delayCopy = delay;
            source.PlayOneShot(slash);
        }
        
        if(delayCopy > 0 && delayCopy <= delay - hitWindow && delayCopy >= delay - hitWindow * 2)
        {
            canKill = true;
        }
        else
        {
            canKill = false;
        }
    }
}