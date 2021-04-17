using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.Buttons;



public class ClonePlane : MonoBehaviour
{
    

    [Header("About Plane Settings")]
    /*  Instantiate the plane*/
    public GameObject PlaneObject;
    /*  Cursor Position*/
    //public GameObject TargetPosition;

    /*  Curosor State and CursorPosition */
    public CursorStateEnum NowCursorState;
    public GameObject tmpCursor;


    /*  Get the three button type avoid Select miss*/
    public GameObject PlaceButton, DeleteButton, CancelButton;
    public ButtonStateEnum PlaceBtnState, DeleteBtnState, CancelBtnState;



    [Header("Create LineRenderer")]
    public LineRenderer lineRenderer;

    /* Get NOW Child number*/
    public int ChildCount;

    public Material LineMat1;
    public Material LineMat2;


    public List<GameObject> WayPoint = new List<GameObject>();
    GameObject tmp;  // Just to save the Instantiate GameObject

    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = LineMat1;
        lineRenderer.SetWidth(0.01f, 0.01f);

    }

    // Update is called once per frame
    void Update()
    {
        NowCursorState = tmpCursor.GetComponent<AnimatedCursor>().tmpCursorState;

        PlaceBtnState = PlaceButton.GetComponent<ButtonInteraction>().NowButtonState;
        DeleteBtnState = DeleteButton.GetComponent<ButtonInteraction>().NowButtonState;
        CancelBtnState = CancelButton.GetComponent<ButtonInteraction>().NowButtonState;

        
        lineRenderer = GetComponent<LineRenderer>();

        //Debug.Log("Cursor Position: " + tmpCursor.transform.position);

        //Vector3 CursorPosition = tmpCursor.GetComponent<Transform>().position;

        if((ButtonInteraction.PosState == PosButtonType.PLACE) && (NowCursorState == CursorStateEnum.Release)
            && (PlaceBtnState != ButtonStateEnum.Targeted)  && (PlaceBtnState != ButtonStateEnum.Pressed)
            && (DeleteBtnState != ButtonStateEnum.Observation) && (CancelBtnState != ButtonStateEnum.Observation))
        {
            
            Instantiate(PlaneObject, tmpCursor.transform.position, transform.rotation, this.transform);
            
            //WayPoint.Add(tmp);
            Debug.Log("InstantiateInstantiateInstantiateInstantiateInstantiateInstantiate");       
        }


        ChildCount = this.transform.childCount;
        lineRenderer.SetVertexCount(ChildCount);


        if(ChildCount > 1)
        {
            for(int i = 0; i < ChildCount; i ++)
            {
                tmp = this.gameObject.transform.GetChild(i).gameObject;
                lineRenderer.SetPosition(i, tmp.transform.position);
            }
        }
    
        //if(ChildCount == 2) lineRenderer.SetPosition(2, new Vector3(0,0,1));

        
    }

    /*
    public int CompareGameObjectName(GameObject x, GameObject y)  
    {  
        return x.name.CompareTo(y.name) ;  
    }  */



    void DrawLine(Vector3 P1, Vector3 P2, LineRenderer ConnectLine, Material LineMat)
    {

    }
}
