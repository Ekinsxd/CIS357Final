using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldGenerator : MonoBehaviour
{
    public GameObject leftRoad;
    public GameObject rightRoad;
    public GameObject buff;
    public GameObject debuff;
    public GameObject Enemy;
    private GameObject Player;
    Vector3 offset = new Vector3(0, 0, 30);


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        // generate Roads if Player alive 
        // and x distance from latest road
        // Debug.Log(leftRoad.transform.position.z + " " + )
        if (leftRoad.transform.position.z < Player.transform.position.z + 5)
        {
            leftRoad.transform.position = new Vector3(leftRoad.transform.position.x, leftRoad.transform.position.y, leftRoad.transform.position.z + 10);
            rightRoad.transform.position = new Vector3(rightRoad.transform.position.x, rightRoad.transform.position.y, rightRoad.transform.position.z + 10);

            for (int i = 0; i < 5; i++)
            {
                // generate enemy
                if (Random.Range(0, 100) <= 15)
                {
                    Instantiate(Enemy, new Vector3(Random.Range(-2, 2), 0, Player.transform.position.z + 25 + i * 2), Quaternion.identity);
                }
                // generate powerup
                else if (Random.Range(0, 4) == 0)
                {
                    Instantiate(buff, new Vector3(Random.Range(-3, 3), 0, Player.transform.position.z + 30 + i * 2), Quaternion.identity);
                    Instantiate(buff, new Vector3(Random.Range(-3, 3), 0, Player.transform.position.z + 30 + i * 2), Quaternion.identity);
                }
                else if (Random.Range(0, 2) == 0) {
                    Instantiate(debuff, new Vector3(Random.Range(-3, 3), 0, Player.transform.position.z + 30 + i * 2), Quaternion.identity);
                }

            }

        }


    }
}
