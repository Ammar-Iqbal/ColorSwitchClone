using UnityEngine;

public class Ball : MonoBehaviour
{
    public float jumpForce = 10f;
    public Color[] colors;
    private int currentColorIndex = 0;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public ParticleSystem gameOverParticles;
    public ParticleSystem starCollidingParticles;
    public SpriteRenderer sprite;
    public Rigidbody2D rigidBody;
    public GameObject ground;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetRandomColor();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance.currentState == GameManager.GameState.Playing)
            {
                Jump();
                // First Time Ground will hold the Ball. As in Real Game. Then Ground Will be turned Off 
                if (ground.activeInHierarchy)
                {
                    ground.SetActive(false);
                }
            }
            else if(GameManager.Instance.currentState == GameManager.GameState.GameOver)
            {
                GameManager.Instance.GameRestart();
                
            }
        }
        CheckIfBelowScreen();
    }

    private void CheckIfBelowScreen()
    {
        Vector2 screenPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPosition.y < 0 && GameManager.Instance.currentState == GameManager.GameState.Playing)
        {
            GameManager.Instance.GameOver();
            OnCollidingObstacle();
            AudioManager.Instance.PlayGameOverSound();
             
             
        }
    }
    private void Jump()
    {
        AudioManager.Instance.PlayJumpSound();
        rb.velocity = Vector2.up * jumpForce;
    }

    public void SetRandomColor()
    {
        int newColorIndex;
        do
        {
            newColorIndex = Random.Range(0, colors.Length);
        } while (newColorIndex == currentColorIndex);

        currentColorIndex = newColorIndex;
        spriteRenderer.color = colors[currentColorIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //On Collision With Obstacle
        if (collision.CompareTag("Obstacle"))
        {
            Obstacle obstacle = collision.GetComponent<Obstacle>();
            if (obstacle && obstacle.color != colors[currentColorIndex])
            {

                OnCollidingObstacle();
                GameManager.Instance.GameOver();
                AudioManager.Instance.PlayGameOverSound();
                
            }
            
        }
        //On Collision With Star
        else if (collision.CompareTag("Star"))
        {
            GameManager.Instance.Stars++;
            AudioManager.Instance.PlayStarCollectSound();
            OnCollidingStar(collision.gameObject);
        }

        //On Collision With Color Switcher
        else if (collision.CompareTag("ColorSwitcher"))
        {
            AudioManager.Instance.PlayColorSwitchSound();
            SetRandomColor();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollidingObstacle()
    {
        Instantiate(gameOverParticles, this.transform);
        sprite.enabled = false;
        rigidBody.simulated = false;
    }
    private void OnCollidingStar(GameObject obj)
    {
        Vector3 position = obj.transform.position;
        Instantiate(starCollidingParticles, position,Quaternion.identity);
        Destroy(obj);
    }
}