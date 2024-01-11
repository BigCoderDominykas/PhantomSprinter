using UnityEngine;

public class CameraBob : MonoBehaviour
{
    public float bobAmplitude;
    public float frequency;
    public GroundCheck groundCheck;
    public PlayerMovement player;

    float timer = 0;
    float defaultPosY = 1;

    void Start()
    {
        
    }

    void Update()
    {
        if(groundCheck.isGrounded)
        {
            if(player.isMoving)
            {
                timer += Time.deltaTime * frequency;
                transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobAmplitude, transform.localPosition.z);
            }
            else
            {
                timer = 0;
                transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * frequency), transform.localPosition.z);
            }
        }
    }
}
