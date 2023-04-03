using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    private Touch touch;
    private Rigidbody rb;
    public float speed;
    public float swipeSpeed;

    public int score;
    public float fireRate;
    private float fireCooldown;
    public GameObject bulletPrefab;
    protected GameController gc;
    protected bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        fireCooldown = 1 / fireRate;

    }

    // Update is called once per frame
    void Update()
    {
        if (gc.getStarted() == true) {
            rb.velocity = new Vector3(0, 0, 0);
            return;// dont update if we are not started
        }
        rb.velocity = new Vector3(0, 0, speed);
        handleUserInput();
        
        fireCooldown -= Time.deltaTime;
        if (fireCooldown < 0)
        {
            Shoot();
        }
    }

    void handleUserInput()
    {
        // user tap
        if (Input.touchCount > 0) 
        {
            touch = Input.GetTouch(0);
            Vector3 pos = new Vector3(touch.position.x, touch.position.y, 10);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(pos);
            Vector3 movePos = new Vector3(touchPosition.x, transform.position.y, transform.position.z);
            transform.position = movePos;
        }

    }

    void Shoot() 
    {
        var bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, .5f), Quaternion.identity);
        fireCooldown = 1 / fireRate;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Buff")
        {
            Debug.Log("increase");
            Destroy(other.gameObject);
            fireRate *= 1.05f;
            fireCooldown = 1 / fireRate;
            rb.velocity = new Vector3(0, 0, speed);
        }

        if (other.gameObject.tag == "Debuff")
        {
            Debug.Log("decrease");
            Destroy(other.gameObject);
            fireRate /= 1.3f;
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Block")
        {
            Debug.Log("Lose");
            //we lose, set animation to dead
            Destroy(gameObject);
        }

        if (!isDead && other.gameObject.tag == "Enemy")
        {
            Debug.Log("Lose");
            Destroy(other.gameObject);
            Time.timeScale = 0f;
            isDead = true;
            gc.setLost();
            //we lose, set animation to dead
        }
    }


}
