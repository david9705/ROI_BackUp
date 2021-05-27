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

    public float offset = 5.0f;



    [Header("Create LineRenderer")]
    public LineRenderer lineRenderer;

    /* Get NOW Child number*/
    public int ChildCount;

    public Material LineMat1;
    public Material LineMat2;

    public LayerMask mask; //Mask Layer set to Spatial Mapping


    public List<GameObject> WayPoint = new List<GameObject>();
    GameObject tmp, Obj1, Obj2;  // Just to save the Instantiate GameObject

    //public bool LineCollision = false;
    //public int LineCollisionNum;

    [Header("About Light")]
    public GameObject LightManager;   // assign as Instantiate Light Father
    public GameObject CloneRedLight_0, CloneRedLight_1, CloneRedLight_2, CloneRedLight_3, CloneRedLight_4, CloneRedLight_5, CloneRedLight_6,  CloneRedLight_7, CloneRedLight_8, CloneRedLight_9, CloneRedLight_10, CloneRedLight_11, CloneRedLight_12, CloneRedLight_13, CloneRedLight_14, CloneRedLight_15, CloneRedLight_16, CloneRedLight_17, CloneRedLight_18;  // Instantiate the Red Light
    GameObject L0, L1, L2, L3, L4, L5, L6, L7, L8, L9, L10, L11, L12, L13, L14, L15, L16, L17, L18; // Just for tmp;


    
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

            if(SizeButtonCollection.SizeButtonState == SizeButtonType.MEDIUM) offset = 6.0f;
            else if(SizeButtonCollection.SizeButtonState == SizeButtonType.LARGE) offset = 8.0f;
            else if(SizeButtonCollection.SizeButtonState == SizeButtonType.SMALL) offset = 5.0f;
            
            Vector3 FinalPos = tmpCursor.transform.position - new Vector3(0f, 0f, 0.1f) * offset ;
            Instantiate(PlaneObject, FinalPos, transform.rotation, this.transform);   //Genarate the drone
            
            ChildCount = this.transform.childCount;

            /*Use to process the three Red Light*/
            
            if(ChildCount > 1)
            {
                Vector3 pos1, pos2;  //the position of two way point(drone)
                Vector3 p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18;  //Red light initial position
                pos1 = this.gameObject.transform.GetChild(ChildCount-2).transform.position;  
                pos2 = this.gameObject.transform.GetChild(ChildCount-1).transform.position;

                p0  = (pos1 * 1  + pos2 * 19) / 20;
                p1  = (pos1 * 2  + pos2 * 18) / 20;
                p2  = (pos1 * 3  + pos2 * 17) / 20;
                p3  = (pos1 * 4  + pos2 * 16) / 20;
                p4  = (pos1 * 5  + pos2 * 15) / 20;
                p5  = (pos1 * 6  + pos2 * 14) / 20;
                p6  = (pos1 * 7  + pos2 * 13) / 20;
                p7  = (pos1 * 8  + pos2 * 12) / 20;
                p8  = (pos1 * 9  + pos2 * 11) / 20;
                p9  = (pos1 * 10 + pos2 * 10) / 20;
                p10 = (pos1 * 11 + pos2 * 9 ) / 20;
                p11 = (pos1 * 12 + pos2 * 8 ) / 20;
                p12 = (pos1 * 13 + pos2 * 7 ) / 20;
                p13 = (pos1 * 14 + pos2 * 6 ) / 20;
                p14 = (pos1 * 15 + pos2 * 5 ) / 20;

                p15 = (pos1 * 16 + pos2 * 4 ) / 20;
                p16 = (pos1 * 17 + pos2 * 3 ) / 20;
                p17 = (pos1 * 18 + pos2 * 2 ) / 20;
                p18 = (pos1 * 19 + pos2 * 1 ) / 20;
                

                L0 = Instantiate(CloneRedLight_0, p0, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L0.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L0.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L0.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L1 = Instantiate(CloneRedLight_1, p1, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L1.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L1.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L1.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L2 = Instantiate(CloneRedLight_2, p2, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L2.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L2.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L2.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L3 = Instantiate(CloneRedLight_3, p3, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L3.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L3.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L3.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L4 = Instantiate(CloneRedLight_4, p4, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L4.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L4.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L4.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L5 = Instantiate(CloneRedLight_5, p5, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L5.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L5.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L5.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L6 = Instantiate(CloneRedLight_6, p6, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L6.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L6.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L6.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L7 = Instantiate(CloneRedLight_7, p7, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L7.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L7.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L7.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L8 = Instantiate(CloneRedLight_8, p8, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L8.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L8.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L8.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L9 = Instantiate(CloneRedLight_9, p9, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L9.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L9.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L9.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L10 = Instantiate(CloneRedLight_10, p10, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L10.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L10.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L10.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L11 = Instantiate(CloneRedLight_11, p11, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L11.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L11.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L11.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L12 = Instantiate(CloneRedLight_12, p12, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L12.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L12.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L12.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L13 = Instantiate(CloneRedLight_13, p13, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L13.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L13.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L13.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L14 = Instantiate(CloneRedLight_14, p14, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L14.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L14.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L14.GetComponent<RedLightPos>().Current_Num = ChildCount-2;


                /////////////////////////////////////////
                L15 = Instantiate(CloneRedLight_15, p15, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L15.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L15.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L15.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L16 = Instantiate(CloneRedLight_16, p16, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L16.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L16.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L16.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L17 = Instantiate(CloneRedLight_17, p17, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L17.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L17.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L17.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

                L18 = Instantiate(CloneRedLight_18, p18, this.gameObject.transform.GetChild(ChildCount-2).transform.rotation, LightManager.transform);
                L18.GetComponent<RedLightPos>().Obj1 = this.gameObject.transform.GetChild(ChildCount-2).gameObject;
                L18.GetComponent<RedLightPos>().Obj2 = this.gameObject.transform.GetChild(ChildCount-1).gameObject;
                L18.GetComponent<RedLightPos>().Current_Num = ChildCount-2;

               
    
                
            }

            //WayPoint.Add(tmp);
            //Debug.Log("InstantiateInstantiateInstantiateInstantiateInstantiateInstantiate");       
        }


        /* Line Process*/
        ChildCount = this.transform.childCount;
        lineRenderer.SetVertexCount(ChildCount);


        if(ChildCount > 1)
        {
            for(int i = 0; i < ChildCount; i ++)
            {
                tmp = this.gameObject.transform.GetChild(i).gameObject;
                lineRenderer.SetPosition(i, tmp.transform.position);
            }


            /*Obstacle Detect*/
            for(int i = 0; i < ChildCount - 1; i ++)
            {
                Obj1 = this.gameObject.transform.GetChild(i).gameObject;
                Obj2 = this.gameObject.transform.GetChild(i+1).gameObject;
                Ray ray = new Ray(Obj1.transform.position, Obj2.transform.position - Obj1.transform.position);
                RaycastHit hit; 

                Debug.Log( i + " -> " + (i+1) + " distance : " + Vector3.Distance(Obj1.transform.position, Obj2.transform.position));
                float distance = Vector3.Distance(Obj1.transform.position, Obj2.transform.position) - 0.1f;

                Physics.Raycast(ray, out hit, distance, mask); 

               //When collision is NOT NULL, there is obstacles
                if (hit.transform != null)
                {
                    lineRenderer.material = LineMat2; // if collision the line become red
                    //Debug.Log("BBBBBBBBB");

                    //LineCollision = false;   // Let Other Script Know Collision State
                    //LineCollisionNum = i + 1;

                    Debug.Log("Blocked by : " + hit.transform.name);
                }
                //If is NULL -> No Obstacles
                else if(hit.transform == null)
                {
                    lineRenderer.material = LineMat1; 
                    //LineCollision = true;
                    //LineCollisionNum = -1;
                    //Debug.Log("NNNNNNNNN");
                }

                 //Debug.Log("Line color : " + lineRenderer.material);

            }




        }
    
        //if(ChildCount == 2) lineRenderer.SetPosition(2, new Vector3(0,0,1));

        
    }

    /*
    public int CompareGameObjectName(GameObject x, GameObject y)  
    {  
        return x.name.CompareTo(y.name) ;  
    }  */

}
