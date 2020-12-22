using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public float speed = 8.0f;
    private Vector2 inDirection;

    public AudioSource clip;
    void Start()
    {
            float randomizedX = RandomRangeExcept(-10, 10, 0);
            float randomizedY = RandomRangeExcept(-5, 5, 0);

            inDirection = new Vector2(randomizedX, randomizedY).normalized;

            clip = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    public void Update()
    {
        transform.Translate(inDirection * Time.deltaTime * speed, Space.World);

        if (Mathf.Abs(transform.position.x) >= 9.2f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 contactPoint = collision.GetContact(0).point;
        Vector2 ballLocation = transform.position;
        Vector2 inNormal = (ballLocation - contactPoint).normalized;
        
        GameObject collidedObject = collision.collider.gameObject;
        
        // Changes the bounce angle depending on contact point with platform.
        if (collidedObject.CompareTag("GameController"))
        {
            float yOffset = collidedObject.transform.position.y - contactPoint.y;
            Debug.Log(yOffset);
            inDirection.y -= inDirection.y + yOffset ;
        }
        
        inDirection = Vector2.Reflect(inDirection, inNormal).normalized;
        clip.Play();
    }
    
    private float RandomRangeExcept(int min, int max, int except)
    {
        int result;
        do
        {
            result = Random.Range(min, max);
        } while (result == except);
        return result;
    }
}
