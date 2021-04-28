using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNormalVector : MonoBehaviour
{
    public string Contain_String = "Plane";
    public GameObject Target;
    public LayerMask mask; //Mask Layer set to Spatial Mapping
    public float AreaDistance;
    private Vector3 dir ;
    


    // Start is called before the first frame update
    void Start()
    {
        Target = this.gameObject.transform.GetChild(7).gameObject;
        //dir = Target.transform.position - this.transform.position;
        Debug.Log("NAME : " + Target.transform.name);

    }

    // Update is called once per frame
    void Update()
    {
        dir = Target.transform.position - this.transform.position;
        Ray ray = new Ray(transform.position, dir);
        RaycastHit hit; 
        float distance = 100.0f;

        Vector3 CollisionPoint;
        Physics.Raycast(ray, out hit, distance, mask); 

        if ((hit.transform != null) &&(hit.transform.name.Contains(Contain_String)))
        {
            CollisionPoint = hit.point;
            AreaDistance = Vector3.Distance(CollisionPoint, transform.position);
            Debug.Log("Point is  : " + hit.point);
            Debug.Log("Drone is Blocked by : " + hit.transform.name);
            Debug.Log("Distance: " + AreaDistance);

        }
     
    }
}
