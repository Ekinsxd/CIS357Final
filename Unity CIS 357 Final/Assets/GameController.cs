using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    int score = 0;
    TextMeshProUGUI label;
    protected float fireRate;
    protected bool paused = false;
    public MenuFunctions menuFunctions;
    
    // Start is called before the first frame update
    void Start()
    {
        label = GameObject.Find("ScoreLabel").GetComponent<TMPro.TextMeshProUGUI>();
        paused = false;
        AddPoints(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setLost() 
    {
        menuFunctions.LoadGameOver();
        setPaused(false);
    }

    public bool getPaused() 
    {
        return paused;
    }

    public void setPaused(bool isPaused) 
    {
        paused = isPaused;
    }

    public void AddPoints(int points){
        score += points;
        label.text = "Score: " + score;
    }


}
