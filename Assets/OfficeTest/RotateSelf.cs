using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour
{

    [SerializeField]
    Vector3 direction = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direction, Space.Self);
    }
}
