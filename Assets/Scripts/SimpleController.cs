using UnityEngine;

public enum GameState
{
    PlacingBall,
    DroppingBall,
    GameOver
}

[RequireComponent(typeof(Rigidbody))]
public class SimpleController : MonoBehaviour
{
    public float speed = 1f;
    public GameState gameState = GameState.PlacingBall;

    private Rigidbody rb;
    private Vector3 initialPosition;

    private float leftBounds = 1.7f;
    private float rightBounds = -1.75f;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        //SW TAB TAB varname enter
        switch (gameState)
        {
            case GameState.PlacingBall:
                PlacingBallUpdate();
                break;

            case GameState.DroppingBall:
                break;

            case GameState.GameOver:
                GameOverUpdate();
                break;

            default:
                break;
        }

        if (gameState == GameState.GameOver)
        {
        }
    }

    private void GameOverUpdate()
    {
        if (Input.anyKeyDown)
        {
            gameState = GameState.PlacingBall;
            transform.position = initialPosition;
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }

    private void PlacingBallUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 pos = transform.position;
            pos.x += speed * Time.deltaTime;

            if (pos.x > leftBounds)
            {
                pos.x = leftBounds;
            }

            transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 pos = transform.position;
            pos.x -= speed * Time.deltaTime;

            if (pos.x < rightBounds)
            {
                pos.x = rightBounds;
            }

            transform.position = pos;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            gameState = GameState.DroppingBall;
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        gameState = GameState.GameOver;
        AudioSource audio = other.GetComponent<AudioSource>();
        audio.Play();
    }
}