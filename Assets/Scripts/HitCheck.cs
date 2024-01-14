using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public int particleCount;
    public GameObject particle;
    public Sword sword;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy" && sword.canKill)
        {
            for (int i = 0; i < particleCount; i++)
            {
                //var offset = Random.insideUnitSphere;
                particle.transform.localScale = new Vector3(Random.Range(0.01f, 0.5f), Random.Range(0.01f, 0.5f), Random.Range(0.01f, 0.5f));
                var rotation = Random.rotation;
                Instantiate(particle, other.gameObject.transform.position, rotation);
            }
            Destroy(other.gameObject);
        }
    }
}