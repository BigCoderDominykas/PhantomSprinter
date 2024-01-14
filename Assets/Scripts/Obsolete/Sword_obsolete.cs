using UnityEngine;

public class Sword_obsolete : MonoBehaviour
{
    public Transform cam;
    public Transform sword;
    public GameObject hitBox;

    public float swordRotation = 95;
    public float swordAttackRotation = 40;
    float targetRotation;

    public float timer;
    float timerCopy;
    float delayCopy;
    public float ease = 0.1f;
    public float coolDownEaseDelta;

    public bool canKill;

    bool isAttacking = false;

    //Animator animator;

    void Start()
    {
        targetRotation = swordRotation;
        timerCopy = timer;
        delayCopy = 0;

        //animator = sword.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        transform.localEulerAngles = new Vector3(cam.transform.eulerAngles.x, 0, 0);

        delayCopy -= Time.deltaTime;

        canKill = false;

        if (Input.GetMouseButtonDown(0) && delayCopy <= 0)
        {
            canKill = true;
            isAttacking = true;
            targetRotation += swordAttackRotation;
            ease += coolDownEaseDelta;

            //animator.Play("SwordSwing");
        }

        if (isAttacking)
        {
            delayCopy = timer;
            timerCopy -= Time.deltaTime;


            if (timerCopy <= 0)
            {
                targetRotation -= swordAttackRotation;
                ease -= coolDownEaseDelta;
                timerCopy = timer;
                isAttacking = false;
            }
        }

        swordRotation += (targetRotation - swordRotation) * ease;
        sword.localEulerAngles = new Vector3(sword.localEulerAngles.x, swordRotation, sword.localEulerAngles.z);
    }
}