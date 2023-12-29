using Firebase;
using Firebase.Extensions;
using Firebase.RemoteConfig;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace FirebaseDemo.RemoteConfig
{
    public class RemoteConfigManager : MonoBehaviour
    {
        public Material objMaterial;

        private void Awake()
        {
           

            CheckRemoteConfigValues();
        }

        public Task CheckRemoteConfigValues()
        {
            Debug.Log("Fetching data...");
            Task fetchTask = FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
            return fetchTask.ContinueWithOnMainThread(FetchComplete);
        }

        private void FetchComplete(Task fetchTask)
        {
            if (!fetchTask.IsCompleted)
            {
                Debug.LogError("Retrieval hasn't finished.");
                return;
            }

            var remoteConfig = FirebaseRemoteConfig.DefaultInstance;
            var info = remoteConfig.Info;
            if (info.LastFetchStatus != LastFetchStatus.Success)
            {
                Debug.LogError($"{nameof(FetchComplete)} was unsuccessful\n{nameof(info.LastFetchStatus)}: {info.LastFetchStatus}");
                return;
            }

            // Fetch successful. Parameter values must be activated to use.
            remoteConfig.ActivateAsync()
              .ContinueWithOnMainThread(
                task =>
                {
                    Debug.Log($"Remote data loaded and ready for use. Last fetch time {info.FetchTime}.");

                    //string configData = remoteConfig.GetValue("all_Game_data").StringValue;
                    bool IsColor = remoteConfig.GetValue("IsColor").BooleanValue;
                    if (IsColor)
                    {
                        objMaterial.color = Color.red;
                    }
                    else
                    {
                        objMaterial.color = Color.green;

                    }
                });
        }
    }
}

