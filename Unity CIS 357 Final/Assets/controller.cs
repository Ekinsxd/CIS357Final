using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{

    private Touch theTouch;
    private float timeTouchEnded;
    private float displayTime = .5f;
    private Rigidbody rb;
    public GameObject mainCamera;
    public float speed = 100f;
    public float maxSpeed = 30f;
    public float minSpeed = 10f;
    private Vector3 lowestPoint;
    private Vector3 cameraOffset = new Vector3(0, 3, -5);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        var position = this.transform.position;
        lowestPoint = position;
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 downForce = new Vector3(0f, -10f, 0f);
        if (Input.touchCount > 0) {

            theTouch = Input.GetTouch(0);
            rb.AddForce(downForce);

        }

        var position = this.transform.position;
        if (position.y < lowestPoint.y)
        {
            lowestPoint = position;
        }
        mainCamera.transform.position = lowestPoint + cameraOffset;

    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        else if (rb.velocity.magnitude < 0.001)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

}
