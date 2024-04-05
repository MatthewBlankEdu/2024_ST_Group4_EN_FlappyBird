using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public Vector2 JumpForce;
    public float MaxVelocity;
    public Rigidbody2D Rigidbody2D;
    public Animator animator;
    public TextMeshProUGUI PointsText;
    public GameObject GameOverScreen;

    public int Points;
    public static bool GameOver;
    public static bool HasStarted;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        HasStarted = false;

        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
            return;

        if(Input.GetButtonDown("Jump"))
        {
            HasStarted = true;
            animator.SetTrigger("Flap");
            Rigidbody2D.gravityScale = 1;
            Rigidbody2D.velocity = Vector2.zero;
            Rigidbody2D.AddForce(JumpForce, ForceMode2D.Impulse);
        }

        if (Rigidbody2D.velocity.y > MaxVelocity)
            Rigidbody2D.velocity = new Vector2(0, MaxVelocity);

        PointsText.text = Points.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PointZone"))
        {
            Points++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOverScreen.SetActive(true);
        GameOver = true;
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene("FlappBird_Gameplay");
    }
}