using UnityEngine;

public class HitBox : MonoBehaviour
{
    public int particleCount;
    public GameObject particle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && Sword.canKill)
        {
            for (int i = 0; i < particleCount; i++)
            {
                particle.transform.localScale = new Vector3(Random.Range(0.01f, 0.5f), Random.Range(0.01f, 0.5f), Random.Range(0.01f, 0.5f));
                var rotation = Random.rotation;
                Instantiate(particle, other.gameObject.transform.position, rotation);
            }
            Destroy(other.gameObject);
        }
    }
}