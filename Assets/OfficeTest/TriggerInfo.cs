using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInfo : MonoBehaviour
{
    private bool stay = true;
    private float stayCount = 0.0f;
    public GameObject Label;
    
    private void OnTriggerEntrer(Collider other) {
        Label.SetActive(true);
    }
    private void OnTriggerExit(Collider other) {
        Label.SetActive(false);
    }
}
