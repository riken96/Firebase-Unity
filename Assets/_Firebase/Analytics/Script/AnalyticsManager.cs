using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirebaseDemo.Analytics
{
    public class AnalyticsManager : MonoBehaviour
    {
        Firebase.FirebaseApp app;

        void Start()
        {
            Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
            {

                app = Firebase.FirebaseApp.DefaultInstance;

            });
        }


        private void Update()
        {
            
        }





    }
}
