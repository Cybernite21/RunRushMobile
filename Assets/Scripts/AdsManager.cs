using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    string androidGameId = "3948815";
    string iosGameId = "3948814";

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Advertisement.Initialize(androidGameId);
        }
        else if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Advertisement.Initialize(iosGameId);
        }

        Debug.Log(Advertisement.isInitialized);

        Advertisement.Banner.Load("Banner");
        Advertisement.Banner.Show("Banner");
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
