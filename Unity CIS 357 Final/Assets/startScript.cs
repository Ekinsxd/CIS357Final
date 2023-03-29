using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScript : MonoBehaviour
{
    private bool disable;
    private Touch theTouch;
    public GameObject firstBlock;

    // Start is called before the first frame update
    void Start()
    {
        disable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!disable && Input.touchCount > 0) 
        {
            //make a new box
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Began)
            {
                Instantiate(firstBlock, transform.position, transform.rotation);
                disable = true;
            }
        }
    }
}
