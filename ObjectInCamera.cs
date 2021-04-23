using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInCamera : MonoBehaviour
{
    public string Contain_String = "Plane";
    public GameObject Obj1;
    public GameObject Obj2;

    // Start is called before the first frame update
    void Start()
    {//Contains
        //Obj1 = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Obj1.transform.position, Obj2.transform.position - Obj1.transform.position);
        RaycastHit hit; 
        float distance = 100.0f;
        Physics.Raycast(ray, out hit, distance); 

        if ((hit.transform != null) &&(hit.transform.name.Contains(Contain_String)))
        {
            Debug.Log("CAMERAAAAAAA   Blocked by : " + hit.transform.name);
            Debug.Log("NORMAL is " + hit.normal);
            //Debug.DrawRay(Obj1.transform.position, hit.normal, Color.white);
        }

        //Debug.DrawLine(Obj1.transform.position, Obj2.transform.position, Color.white);
    }
}
