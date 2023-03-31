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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, speed);
        fireCooldown = 1/fireRate;

    }

    // Update is called once per frame
    void Update()
    {


        // user tap
        if (Input.touchCount > 0) 
        {
            //make a new box
            touch = Input.GetTouch(0);
            // if (theTouch.phase == TouchPhase.Began)
            // {
            //     //move left and right
            // }
            // Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            
            Debug.Log(touch.position.x);
            Debug.Log(touch.position.y);
            Vector3 movePos = new Vector3((touch.position.x - 250) / 80, transform.position.y, transform.position.z);
            transform.position = movePos;
            Debug.Log("touch");
        }
        
        fireCooldown -= Time.deltaTime;

        if (fireCooldown < 0)
        {
            //fire
            var bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 0, 1), Quaternion.identity);
            fireCooldown = 1 / fireRate;
        }


    }


}
