using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    string androidGameId = "3948815";
    string iosGameId = "3948814";

    void Awake()
    {
       QualitySettings.SetQualityLevel(2);
    }

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(androidGameId);

        Debug.Log(Advertisement.isInitialized);

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
                Advertisement.Initialize(androidGameId);
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
