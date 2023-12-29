using Firebase.Database;
using Firebase;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirebaseDemo.RealtimeDatabase
{
    public class GameManager : MonoBehaviour
    {
        public DataStore dataStore = new DataStore();
        public DatabaseReference reference;
        public string databasseURL = "https://realtime-database-demo-32a0f-default-rtdb.asia-southeast1.firebasedatabase.app/";
        public Uri databaseUri;

        private void Awake()
        {
            databaseUri = new Uri(databasseURL);
            FirebaseApp.DefaultInstance.Options.DatabaseUrl = databaseUri;
            reference = FirebaseDatabase.DefaultInstance.RootReference;
        }

        public void SaveData()
        {
            Debug.Log("SaveData)");
            dataStore = new DataStore(
                UiManager.instance.emailId.text,
                UiManager.instance.names.text,
                UiManager.instance.number.text,
                UiManager.instance.city.text,
                UiManager.instance.password.text);

            string Data = JsonUtility.ToJson(dataStore);
            reference.Child("Users").Child(UiManager.instance.names.text).SetRawJsonValueAsync(Data);
        }

        public void LoadData()
        {
            StartCoroutine(IELoadData());
        }

        public IEnumerator IELoadData()
        {
            var DBtask = reference.Child("Users").Child(UiManager.instance.emailId.text).GetValueAsync();

            yield return new WaitUntil(predicate: () => DBtask.IsCompleted);
            DataSnapshot snapshot = DBtask.Result;

            if (snapshot != null)
            {
                string s = snapshot.GetRawJsonValue();
                Debug.Log("User Data" + s);
                if (string.IsNullOrEmpty(s))
                {

                }
                else
                {
                    Debug.Log("Data Load From Json File");
                    dataStore = JsonConvert.DeserializeObject<DataStore>(s);
                    UiManager.instance.emailId.text = dataStore.emailId;
                    UiManager.instance.names.text = dataStore.name;
                    UiManager.instance.number.text = dataStore.number;
                    UiManager.instance.city.text = dataStore.city;
                    UiManager.instance.password.text = dataStore.password;
                }
            }
        }
    }


    [System.Serializable]
    public class DataStore
    {
        public string emailId;
        public string name;
        public string number;
        public string city;
        public string password;

        public DataStore(string _emailId, string _name, string _number, string _city, string _password)
        {
            emailId = _emailId;
            name = _name;
            number = _number;
            city = _city;
            password = _password;
        }

        public DataStore()
        {

        }
    }
}
