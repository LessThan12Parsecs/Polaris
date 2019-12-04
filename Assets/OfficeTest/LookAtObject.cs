using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {
        // CouchObject = GameObject.FindGameObjectWithTag("CouchObject");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetObject.transform.position);
        transform.Rotate(new Vector3(0f,1.0f,0f), -90);
    }

    public void ChangeTargetObject(GameObject obj){
        targetObject = obj;
    }
}
