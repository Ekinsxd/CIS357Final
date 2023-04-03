using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killFieldScript : MonoBehaviour
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z - 5);
        transform.position = pos;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Buff" ||
            other.gameObject.tag == "Debuff" ||
            other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Buff" ||
            other.gameObject.tag == "Debuff" ||
            other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
