using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.UI;

public class InterstitialADS : MonoBehaviour
{
    public int deathCount = 0;
    public int pauseCount = 0;
    public int currentPlanet = 1; // Текущая планета
    private float lastInteractionTime;

    private const string _androidAdUnitId = "ca-app-pub-3940256099942544/1033173712";
    private const string _iosAdUnitId = "ca-app-pub-3940256099942544/4411468910";

    private string _adUnitId;
    private InterstitialAd _interstitialAd;

    public Button pauseButton; // Drag and drop your pause button here

    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        _adUnitId = Application.platform == RuntimePlatform.Android ? _androidAdUnitId : _iosAdUnitId;

        LoadInterstitialAd();
        lastInteractionTime = Time.time;

        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(OnPauseButtonClicked); // Add listener for the pause button
        }
    }

    void Update()
    {
        // Проверка времени без взаимодействия.
        if (Time.time - lastInteractionTime >= 60)
        {
            ShowInterstitialAd();
            lastInteractionTime = Time.time; // Сброс таймера
        }

        // Проверка нажатий на экран (например, любое касание сбрасывает таймер).
        if (Input.anyKeyDown)
        {
            lastInteractionTime = Time.time;
        }
    }

    /// <summary>
    /// Loads the interstitial ad.
    /// </summary>
    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // Remove AdRequest creation
        // AdRequest adRequest = new AdRequest.Builder().Build();

        // Send the request to load the ad.
        InterstitialAd.Load(_adUnitId, null, // Use null here instead of adRequest
            (InterstitialAd ad, LoadAdError error) =>
            {
                // If error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("Interstitial ad failed to load with error: " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response: " + ad.GetResponseInfo());
                _interstitialAd = ad;

                // _interstitialAd.OnAdFullScreenContentClosed += HandleAdClosed; // Строка удалена
            });
    }

    /// <summary>
    /// Shows the interstitial ad.
    /// </summary>
    public void ShowInterstitialAd()
    {
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            _interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
            LoadInterstitialAd(); // Attempt to reload the ad
        }
    }

    /// <summary>
    /// Method for handling player deaths.
    /// </summary>
    public void OnPlayerDeath()
    {
        deathCount++;
        if (deathCount % 5 == 0)
        {
            ShowInterstitialAd();
        }
    }

    /// <summary>
    /// Method for handling pause button clicks.
    /// </summary>
    public void OnPauseButtonClicked()
    {
        pauseCount++;
        if (pauseCount % 2 == 0)
        {
            ShowInterstitialAd();
        }
    }

    /// <summary>
    /// Method for handling planet openings.
    /// </summary>
    public void OnPlanetOpened(int planetNumber)
    {
        if (planetNumber == 3)
        {
            ShowInterstitialAd();
        }
    }

    private void OnDestroy()
    {
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
        }
    }
}
