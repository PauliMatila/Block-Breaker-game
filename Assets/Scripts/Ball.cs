using UnityEngine;

public class Ball : MonoBehaviour
{
    // config paramaters
    [SerializeField] Paddle paddle1;
    [SerializeField] float[] xPush;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [Range(1.0f, 100.0f)] public float ballSpeed = 12.0f;
    [SerializeField] float randomBallFactor;

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached component refrences
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(xPush[Random.Range(0, xPush.Length)], yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            AvoidGettingStuckLoops();
        }      
    }

    private void AvoidGettingStuckLoops()
    {
        float x = myRigidbody2D.velocity.x, y = myRigidbody2D.velocity.y;

        if (x >= -0.3f && x <= 0.3f)
        {
            x = Random.Range(-randomBallFactor, randomBallFactor);
        }

        if (y >= -0.3f && y <= 0.3f)
        {
            y = Random.Range(-randomBallFactor, randomBallFactor);
        }

        myRigidbody2D.velocity = new Vector2(x, y).normalized * ballSpeed;
    }

    public void StartNewBall()
    {
        hasStarted = false;
    }
}
