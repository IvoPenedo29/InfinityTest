using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    private static AdManager _instance;

    private BannerView bannerView;
    private InterstitialAd interstitial;

    [HideInInspector]
    private float _timer = 0.0f;
    [HideInInspector]
    public bool adReady = true;

    public static AdManager instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate<GameObject>(Resources.Load<GameObject>("Ad Manager")).GetComponent<AdManager>();

            return _instance;
        }
    }

    public void InitAdManager()
    {
        return;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(!adReady)
            _timer -= Time.deltaTime;

        if (_timer <= 0.0f)
        {
            adReady = true;
            _timer = 60.0f;
        }
    }


    void Start()
    {
        string appId = "ca-app-pub-3940256099942544~3347511713";

        MobileAds.Initialize(appId);

        RequestBanner();
        RequestInterstitial();
    }

    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";

        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }

    private void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";        

        this.interstitial = new InterstitialAd(adUnitId);

        this.interstitial.OnAdClosed += HandleOnAdClosed;

        AdRequest request = new AdRequest.Builder().Build();

        this.interstitial.LoadAd(request);
    }

    void HandleOnAdClosed(object sender, System.EventArgs args)
    {
        RequestInterstitial();        
    }

    public void ShowPopUp()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }
}
