using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


namespace FirebaseDemo.Analytics
{
    public class ChangeLevel : MonoBehaviour,IPointerClickHandler
    {
       [SerializeField] public string _levelToLoad;

        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(_levelToLoad);
        }
    }
}
