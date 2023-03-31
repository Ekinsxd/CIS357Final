using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    private Touch touch;
    private Rigidbody rb;
    public float speed;
    public int score;
    public float fireRate;
    private float fireCooldown;
    public GameObject bulletPrefab;
    protected GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, speed);
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        fireCooldown = 1/fireRate;

    }

    // Update is called once per frame
    void Update()
    {


        // user tap
        if (Input.touchCount > 0) 
        {
            touch = Input.GetTouch(0);
    
            Debug.Log(touch.position.x);
            Debug.Log(touch.position.y);
            Vector3 movePos = new Vector3((touch.position.x - 200) / 60, transform.position.y, transform.position.z);
            transform.position = movePos;
            Debug.Log("touch");
        }
        
        fireCooldown -= Time.deltaTime;

        if (fireCooldown < 0)
        {
            Shoot();
        }
        rb.velocity = new Vector3(0, 0, speed);


    }

    void Shoot() 
    {
        var bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, .5f), Quaternion.identity);
        fireCooldown = 1 / fireRate;

    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Buff")
        {
            Debug.Log("increase");
            Destroy(other.gameObject);
            fireRate *= 1.05f;
            rb.velocity = new Vector3(0, 0, speed);
        }

        if (other.gameObject.tag == "Debuff")
        {
            Debug.Log("decrease");
            Destroy(other.gameObject);
            fireRate /= 1.3f;
            rb.velocity = new Vector3(0, 0, speed);
        }

        transform.position += new Vector3(0,0,0.05f);

        if (other.gameObject.tag == "Block")
        {
            Debug.Log("Lose");
            //we lose, set animation to dead
            Destroy(gameObject);
        }
    }


}
