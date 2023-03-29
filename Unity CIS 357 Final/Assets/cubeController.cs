using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeController : MonoBehaviour
{

    private Touch theTouch;
    private Rigidbody rb;
    private Vector3 pos;
    public GameObject lastBlock;
    public float upperBound;
    public float lowerBound;
    public float speed;
    public int score;
    private bool disable;
    private GameObject startingStack;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        disable = false;
        transform.localScale = new Vector3(10f, 0f, 10f);
        if (score % 2 == 0)
        {
            rb.velocity = new Vector3(-speed, 0, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
        startingStack = GameObject.FindGameObjectsWithTag("Respawn")[0];
    }

    // Update is called once per frame
    void Update()
    {


        // user tap
        if (!disable && Input.touchCount > 0) 
        {
            //make a new box
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Began)
            {
                disable = true;
                rb.velocity = new Vector3(0, 0, 0);
                score++;
                var newBlock = Instantiate(lastBlock, transform.position, transform.rotation);
                newBlock.transform.position = lastBlock.transform.position + new Vector3(0, 1, 0);
                GetComponent<MeshRenderer>().material.color = new Color(Random.value * 255, Random.value * 255, Random.value * 255);

                float x = Mathf.Abs(newBlock.transform.position.x - lastBlock.transform.position.x);
                float z = Mathf.Abs(newBlock.transform.position.z - lastBlock.transform.position.z);

                Debug.Log(x);
                Debug.Log(z);
                newBlock.transform.localScale = new Vector3(x/10f, 0f, z/10f);


                // newBlock.transform.localScale = new Vector3(10f, 0f, 10f);
                // Destroy(lastBlock);
                lastBlock = newBlock;
                //increase speed by 2% each block
                speed *= 1.02f;
            }
        }
        pos = this.transform.position;
        // Debug.Log(rb.velocity);
        if (pos.x > upperBound)
        {
            rb.velocity = new Vector3(-speed, 0, 0);
        }
        else if (pos.x < lowerBound)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (pos.z > upperBound)
        {
            rb.velocity = new Vector3(0, 0, -speed);
        }
        else if (pos.z < lowerBound)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }



        //move camera
        //var position = this.transform.position;
        //if (position.y < lowestPoint.y)
        //{
        //    lowestPoint = position;
        //}
        //mainCamera.transform.position = lowestPoint + cameraOffset;

    }


}
