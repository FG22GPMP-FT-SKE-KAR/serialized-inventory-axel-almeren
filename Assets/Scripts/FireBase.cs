using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Analytics;

public class FireBase : MonoBehaviour
{
    private void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            {
                FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
            } 
        });
    }
}
