using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class MenuFunctions: MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    public static bool isPaused = false;
    private GameController gc;

    // These ad units are configured to always serve test ads.
    #if UNITY_ANDROID
        private string _adUnitId = "ca-app-pub-3940256099942544/1033173712";
    #elif UNITY_IPHONE
        private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
    #else
        private string _adUnitId = "unused";
    #endif

    private InterstitialAd interstitialAd;

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        gc.setPaused(false);
        Time.timeScale = 0f;
        isPaused = true;
    
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        gc.setPaused(true);
        Time.timeScale = 1f;
        isPaused = false;

    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Screen");
        isPaused = false;

    }

    public void LoadGameOver()
    {
        this.LoadInterstitialAd();
        this.ShowAd();
        this.RegisterReloadHandler(interstitialAd);

        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        isPaused=false;
        SceneManager.LoadScene("game");
    }

    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest.Builder()
                .AddKeyword("unity-admob-sample")
                .Build();

        // send the request to load the ad.
        InterstitialAd.Load(_adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                interstitialAd = ad;
            });
    }

    public void ShowAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }

    private void RegisterReloadHandler(InterstitialAd ad)
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () => {
            Debug.Log("Interstitial Ad full screen content closed.");

            // Reload the ad so that we can show another as soon as possible.
            LoadInterstitialAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);

            // Reload the ad so that we can show another as soon as possible.
            LoadInterstitialAd();
        };
    }


}
