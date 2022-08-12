using UnityEngine;
using System;

public class House : MonoBehaviour
{
    [SerializeField] string[] tagName;

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag(tagName[0]))
        {
            PopupManager.Show("DEFEAT", Time.time.ToString() );
        }
        else if (other.CompareTag(tagName[1]))
        {
            PopupManager.Show("victory", Time.time.ToString() );
        }

        Time.timeScale = 0;
    }
    
}
