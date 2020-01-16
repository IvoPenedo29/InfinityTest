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

    //Cria uma instância da classe para ser facilmente acessível por outras classes
    public static AdManager instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate<GameObject>(Resources.Load<GameObject>("Ad Manager")).GetComponent<AdManager>();

            return _instance;
        }
    }

    //Função de inicialização da classe
    public void InitAdManager()
    {
        return;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }    

    void Start()
    {
        //Inicializar a sdk usando o id de testes fornecido
        string appId = "ca-app-pub-3940256099942544~3347511713";
        MobileAds.Initialize(appId);

        //Fazer request dos tipos de anúncios que serão usasdos
        RequestBanner();
        RequestInterstitial();
    }

    void Update()
    {
        //Fazer a contagem decrescente do timer para poder mostrar o anúncio
        if (!adReady)
            _timer -= Time.deltaTime;

        //O anúncio já pode ser mostrado porque já passaram os 60 segundos
        if (_timer <= 0.0f)
        {
            adReady = true;
            _timer = 60.0f;
        }
    }

    private void RequestBanner()
    {
        //Sintaxe da sdk para fazer request de uma banner
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";

        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }

    private void RequestInterstitial()
    {
        //Sintaxe da sdk para fazer request de um anúncio intermitente
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";        

        this.interstitial = new InterstitialAd(adUnitId);

        this.interstitial.OnAdClosed += HandleOnAdClosed;

        AdRequest request = new AdRequest.Builder().Build();

        this.interstitial.LoadAd(request);
    }

    void HandleOnAdClosed(object sender, System.EventArgs args)
    {
        //Pedir novos anúncios cada vez que o anterior for fechado
        RequestInterstitial();        
    }

    public void ShowPopUp()
    {
        //Função para mostrar o anúncio
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }
}
