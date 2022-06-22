using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class admobscript : MonoBehaviour
{
    public static admobscript instance;
    string App_ID = "ca-app-pub-4260147869013025~5507293267";
    string Banner_ID = "ca-app-pub-4260147869013025/4122237015";
    string Video_ID = "ca-app-pub-4260147869013025/3168247994";

    private BannerView banner;
    private InterstitialAd video;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });

        RequestBanner();
        RequestInterstitial();
    }

    public void RequestBanner()
    {
        banner = new BannerView(Banner_ID, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = AdRequestBuild();
        banner.LoadAd(request);
    }

    public void DestroyBannerAd()
    {
        if (banner != null)
            banner.Destroy();
    }

    AdRequest AdRequestBuild()
    {
        return new AdRequest.Builder().Build();
    }

    public void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        video = new InterstitialAd(Video_ID);
        AdRequest request = AdRequestBuild();
        video.LoadAd(request);
    }

    public void ShowInterstitialAD()
    {
        if (this.video.IsLoaded())
        {
            this.video.Show();
        }
    }

    public void DestroyInterstitialAd()
    {
        video.Destroy();
    }


    void OnDestroy()
    {
        DestroyBannerAd();
        DestroyInterstitialAd();
    }

}
