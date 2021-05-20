using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSizeButtonDistance : MonoBehaviour
{
    [Header("Distance Proces")]
    public string Contain_String = "Plane";
    public GameObject Target;
    public LayerMask mask; //Mask Layer set to Spatial Mapping
    public float AreaDistance;
    public bool DroneValid;
    public int TestNum;
    private Vector3 dir ;



    [Header("UI Text Process")]
    [SerializeField]
    private TextMesh SizeTextMesh;    

    // Start is called before the first frame update
    void Start()
    {
        SizeTextMesh.text ="";
        Target = this.gameObject.transform.GetChild(7).gameObject;
        //dir = Target.transform.position - this.transform.position;
        //Debug.Log("NAME : " + Target.transform.name);

        TestNum = 0;
        
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
            /*Debug.Log("Point is  : " + hit.point);
            Debug.Log("Drone is Blocked by : " + hit.transform.name);
            Debug.Log("Distance: " + AreaDistance);*/

            
            if(SizeButtonCollection.SizeButtonState == SizeButtonType.SMALL)
            {
                if(AreaDistance >= 0.6f)
                {
                    SizeTextMesh.text ="Please Move Closer to Wall!";
                    DroneValid = false;
                }
                else if(AreaDistance < 0.5f)
                {
                   SizeTextMesh.text ="Please Move Farther From Wall!";
                    DroneValid = false;
                }
                else
                {
                    SizeTextMesh.text ="";
                    DroneValid = true;
                }
            }
            else if(SizeButtonCollection.SizeButtonState == SizeButtonType.MEDIUM)
            {
                if(AreaDistance < 0.6f)
                {
                    SizeTextMesh.text ="Please Move Farther From Wall!";
                    DroneValid = false;
                }
                else if(AreaDistance >= 0.6f && AreaDistance < 0.8f)
                {
                    SizeTextMesh.text ="";
                    DroneValid = true;
                }
                else
                {
                    SizeTextMesh.text ="Please Move Closer to Wall!";
                    DroneValid = false;
                }
            }
            else if(SizeButtonCollection.SizeButtonState == SizeButtonType.LARGE)
            {
                if(AreaDistance < 0.8f)
                {
                    SizeTextMesh.text ="Please Move Farther From Wall!";
                    DroneValid = false;
                }
                else if(AreaDistance >= 1.0f)
                {
                    SizeTextMesh.text ="Please Move Closer to Wall!";
                    DroneValid = false;
                }
                else
                {
                    SizeTextMesh.text ="";
                    DroneValid = true;
                }
            }

        }
    }
}
