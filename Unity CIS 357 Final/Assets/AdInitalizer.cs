using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdInitalizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
        });


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
