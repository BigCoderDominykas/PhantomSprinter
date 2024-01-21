using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float duration = 3;

    void Start()
    {
        Color color = this.GetComponent<Renderer>().material.color;
        color = new Color(color.r, color.g, color.b, 0);
        this.GetComponent<Renderer>().material.color = color;
    }

    void Update()
    {
        Color color = this.GetComponent<Renderer>().material.color;

        if (color.a < 1)
        {
            float fadeAmount = color.a + (Time.deltaTime / duration);

            color = new Color(color.r, color.g, color.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = color;
        }
    }
}
