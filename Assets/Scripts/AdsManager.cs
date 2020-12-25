﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    string androidGameId = "3948815";
    string iosGameId = "3948814";

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, UnityEngine.Advertisements.ShowResult showResult)
    {
        Time.timeScale = 1;
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    void Awake()
    {
       QualitySettings.SetQualityLevel(2);
    }

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(androidGameId);

        Debug.Log(Advertisement.isInitialized);
        Advertisement.Load("video");
        if(Advertisement.isInitialized && Advertisement.IsReady())
        {
            Time.timeScale = 0;
            Advertisement.Show();
        }

        StartCoroutine(waitForAd());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator waitForAd()
    {
        while(!Advertisement.IsReady("Banner") || !Advertisement.isInitialized)
        {
            if(!Advertisement.isInitialized)
            {
                Advertisement.Initialize(androidGameId, true);
            }
            yield return null;
        }

        Advertisement.Banner.Load("Banner");

        while(!Advertisement.Banner.isLoaded)
        {
            yield return null;
        }

        Advertisement.Banner.Show("Banner");
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        yield return new WaitForSeconds(2);
        StartCoroutine(waitForAd());
        yield return null;
    }
}
