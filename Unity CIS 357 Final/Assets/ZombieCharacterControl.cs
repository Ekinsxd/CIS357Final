using UnityEngine;

public class ZombieCharacterControl : MonoBehaviour
{

    private int health;
    private int maxHealth;

    [SerializeField] private float m_moveSpeed = 1;
    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;

    private GameObject player;
    private GameController gc;


    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        player = GameObject.FindGameObjectWithTag("Player");
        maxHealth = Random.Range(1, 5);
        health = maxHealth;
    }
    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }

    private void Update()
    {
        if (gc.getPaused() == true)
        {
            m_moveSpeed = 0;
            return;// dont update if we are not started
        }

        if (health <= 0)
        {
            gc.AddPoints(100 * maxHealth);
            Destroy(gameObject);
        }

        transform.position += transform.forward * m_moveSpeed * Time.deltaTime;
        transform.LookAt(player.transform);

        m_animator.SetFloat("MoveSpeed", m_moveSpeed);

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            health -= 1;
            Destroy(other.gameObject);
        }
    }
}
