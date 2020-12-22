using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    
    private float yMin = -2.76f, yMax = 2.76f;
    
    void FixedUpdate()
    {
        // float verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
        
        float yPos = Mathf.Clamp(takeInput() + transform.position.y, yMin, yMax);
        Vector3 move = new Vector3(transform.position.x, yPos, 0);
        transform.position = move;
    }

    public float takeInput()
    {
        string[] inputKeys;
        inputKeys = (gameObject.name == "LeftPlayer") ? new[]{"w", "s"} : new[]{"up", "down"};


        float v = 0f;

        if (Input.GetKey(inputKeys[0]))
        {
            v = 1f;
        }
        else if (Input.GetKey(inputKeys[1]))
        {
            v = -1f;
        }
        
        return v * Time.deltaTime * movementSpeed;
    }
}
