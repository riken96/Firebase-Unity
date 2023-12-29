using Firebase.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirebaseDemo.Notification
{
    public class NotificatinManager : MonoBehaviour
    {
        public void Start()
        {
            Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
            Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
            FirebaseMessaging.SubscribeAsync("topic_name");
        }

        public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token)
        {
            Debug.Log("Received Registration Token: " + token.Token);
        }

        public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
        {
            Debug.Log("Received a new message from: " + e.Message.From);
        }

    }
}
