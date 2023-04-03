using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    int score = 0;
    TextMeshProUGUI label;
    protected float fireRate;
    protected bool started = false;
    public MenuFunctions menuFunctions;
    
    // Start is called before the first frame update
    void Start()
    {
        label = GameObject.Find("ScoreLabel").GetComponent<TMPro.TextMeshProUGUI>();
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setLost() 
    {
        menuFunctions.LoadGameOver();
        setStarted(false);
    }

    public bool getStarted() 
    {
        return started;
    }

    public void setStarted(bool didStart) 
    {
        started = didStart;
    }

    public void AddPoints(int points){
        score += points;
        label.text = "Score: " + score;
    }


}
