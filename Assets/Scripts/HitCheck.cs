using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public Sword sword;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy" && sword.canKill)
        {
            Destroy(other);
        }
    }
}