using Firebase.Analytics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirebaseDemo.Analytics
{
    public class LevelLoginManager : MonoBehaviour
    {
        private void Start()
        {
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelStart);
        }

        private void OnDestroy()
        {
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelEnd);

        }
    }
}
