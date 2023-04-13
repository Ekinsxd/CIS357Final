using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killFieldScript : MonoBehaviour
{
    private GameObject Player;
    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z - 5);
        transform.position = pos;
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision");
        if (other.gameObject.tag == "Buff" ||
            other.gameObject.tag == "Debuff" ||
            other.gameObject.tag == "Enemy")
        {
            //get points if you run away from zombie
            gc.AddPoints(50);
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.tag == "Buff" ||
            other.gameObject.tag == "Debuff" ||
            other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
