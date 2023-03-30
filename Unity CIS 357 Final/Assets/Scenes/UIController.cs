using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For Button actions.
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //get buttons
    public Button startButton;
    
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        startButton = root.Q<Button>("startButton");
        startButton.clicked += StartButtonPressed;
        
    }

    void StartButtonPressed()
    {
        SceneManager.LoadScene("game");
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
