using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeGeneratorManager : MonoBehaviour
{

    [SerializeField] 
    private string Contain_String = "Surface";

    public GameObject Obj1;
    public GameObject Obj2;

    bool SquareFlag = true;

    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private Material LineMat1;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        //lineRenderer.material = LineMat1;
        lineRenderer.SetWidth(0.05f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.SetVertexCount(5);

        Ray ray = new Ray(Obj1.transform.position, Obj2.transform.position - Obj1.transform.position);
        RaycastHit hit; 
        float distance = 100.0f;
        Physics.Raycast(ray, out hit, distance); 

        if ((hit.transform != null) &&(hit.transform.name.Contains(Contain_String)))
        {
            Debug.Log("CAMERAAAAAAA   Blocked by : " + hit.transform.name);
            //Debug.Log("Point is " + hit.point);
            //Debug.Log("NORMAL is " + hit.normal);
            //Debug.DrawRay(Obj1.transform.position, hit.normal, Color.white);


            /* Start to Draw the Square*/
            if(SquareFlag == true)
            {
                
                lineRenderer.SetPosition(0, hit.point);
                lineRenderer.SetPosition(1, hit.point + new Vector3( 2.0f, 0, 0));
                lineRenderer.SetPosition(2, hit.point + new Vector3( 2.0f, 1.0f, 0));
                lineRenderer.SetPosition(3, hit.point + new Vector3( 0, 1.0f, 0));
                lineRenderer.SetPosition(4, hit.point);

                SquareFlag = false;
            }


        }






    }
}
