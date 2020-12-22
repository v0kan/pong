using UnityEngine;

public class BotMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ball;
    public float movementSpeed = 10f;

    private float yMin = -2.76f, yMax = 2.76f;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 ballPos = ball.transform.position;
        Vector3 botPos = transform.position;
        float offset = ballPos.y - botPos.y;
        
        float input = offset * Time.deltaTime * movementSpeed;
        float newYPos = Mathf.Clamp( botPos.y + input, yMin, yMax);
        transform.position = new Vector3(transform.position.x, newYPos, 0.0f);
    }
    
    
}
