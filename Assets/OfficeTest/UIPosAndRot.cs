using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPosAndRot : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI xPos;
    [SerializeField] TextMeshProUGUI yPos;
    [SerializeField] TextMeshProUGUI zPos;
    [SerializeField] TextMeshProUGUI xRot;
    [SerializeField] TextMeshProUGUI yRot;
    [SerializeField] TextMeshProUGUI zRot;

    // Update is called once per frame
    void Update()
    {
        xPos.text = transform.localPosition.x.ToString();
        yPos.text = transform.localPosition.y.ToString();
        zPos.text = transform.localPosition.z.ToString();
        xRot.text = transform.localRotation.eulerAngles.x.ToString();
        yRot.text = transform.localRotation.eulerAngles.y.ToString();
        zRot.text = transform.localRotation.eulerAngles.z.ToString();
    }
}
