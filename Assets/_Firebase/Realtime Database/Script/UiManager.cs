using UnityEngine;
using TMPro;

namespace FirebaseDemo.RealtimeDatabase
{
    public class UiManager : MonoBehaviour
    {
        public static UiManager instance;

        private void Awake()
        {
            instance = this;
        }

        [Header("SaveData / LoadData Inputfield")]
        public TMP_InputField emailId;
        public TMP_InputField names;
        public TMP_InputField number;
        public TMP_InputField city;
        public TMP_InputField password;
    }
}
