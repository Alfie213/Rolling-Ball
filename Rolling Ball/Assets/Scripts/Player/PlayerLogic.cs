using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float sideSpeed;

    private GameManager gameManager;
    private Rigidbody rb;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        gameManager.ChangeScoreDistance(transform.position.x);
    }

    private void FixedUpdate()
    {
        rb.AddForce(speed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(0, 0, sideSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(0, 0, -sideSpeed * Time.deltaTime);
        }
        if (rb.position.y < -1)
        {
            gameManager.EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            gameManager.ChangeScoreCoins();
            Destroy(other.gameObject);
        }
    }
}
