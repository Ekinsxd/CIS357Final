using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    int score = 0;
    TextMeshProUGUI label;
    protected float fireRate;
    
    // Start is called before the first frame update
    void Start()
    {
        label = GameObject.Find("ScoreLabel").GetComponent<TMPro.TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int points){
        score += points;
        label.text = "Score: " + score;
    }


}
