using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class BannerAd : MonoBehaviour
{
    public void Start()
    {
        this.LoadAd();
    }

    #if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-3940256099942544/6300978111";
    #else
    private string _adUnitId = "unused";
    #endif

    static BannerView _bannerView;

    public void CreateBannerView()
    {

        if (_bannerView != null){DestroyAd();}

        _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Bottom);
    }

    public void LoadAd()
    {
        if (_bannerView == null){CreateBannerView();}

        var adRequest = new AdRequest.Builder()
            .AddKeyword("unity-admob-sample")
            .Build();

        _bannerView.LoadAd(adRequest);
    }


    public static void DestroyAd()
    {
        if (_bannerView != null)
        {
            _bannerView.Destroy();
            _bannerView = null;
        }
    }
}
