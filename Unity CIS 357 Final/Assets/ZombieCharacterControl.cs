using UnityEngine;

public class ZombieCharacterControl : MonoBehaviour
{

    [SerializeField] private float m_moveSpeed = 1;
    public float health;

    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;


    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }

    private void Update()
    {
        if (health <= 0)
        {
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
