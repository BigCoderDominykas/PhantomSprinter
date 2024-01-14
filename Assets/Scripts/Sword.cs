using UnityEngine;

public class Sword : MonoBehaviour
{
    public Transform cam;
    public Transform sword;
    public GameObject hitBox;

    float hitWindow = 0.1f;
    float delay = 0.9f;
    float delayCopy;

    public static bool canKill;

    Animator animator;

    void Start()
    {
        animator = sword.gameObject.GetComponent<Animator>();
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
            print("Swing!");
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