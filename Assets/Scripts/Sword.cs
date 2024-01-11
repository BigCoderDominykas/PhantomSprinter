using UnityEngine;

public class Sword : MonoBehaviour
{
    public Transform cam;
    public Transform sword;

    public float swordRotation = 105;
    public float swordAttackRotation = 50;

    public float timer;
    float timerCopy;
    float delayCopy;

    public bool canKill;

    bool isAttacking = false;

    void Start()
    {
        timerCopy = timer;
        delayCopy = 0;
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
            swordRotation += swordAttackRotation;
        }

        if(isAttacking)
        {
            delayCopy = timer;
            timerCopy -= Time.deltaTime;

            if (timerCopy <= 0)
            {
                swordRotation -= swordAttackRotation;
                timerCopy = timer;
                isAttacking = false;
            }
        }

        sword.localEulerAngles = new Vector3(sword.localEulerAngles.x, swordRotation, sword.localEulerAngles.z);
    }
}