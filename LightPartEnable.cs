using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPartEnable : MonoBehaviour
{

    [SerializeField]
    private bool LocalDroneValid = true;
    private int CurrentNotValidNum;
    public GameObject LightManager;

    int PMChildCount, CollisionNum;
    bool LineValid;

    LightPathorNot localLightPathType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PMChildCount = this.transform.childCount;
        localLightPathType = this.GetComponent<ClonePlane>().LightPathorNot;
        Debug.Log("LightPath Type: " + localLightPathType);
        //LineValid = this.GetComponent<ClonePlane>().LineCollision;
        //CollisionNum = this.GetComponent<ClonePlane>().LineCollisionNum;
        //Debug.Log("Line ID: " + LineValid + " NUM: " + CollisionNum);


        if(ButtonInteraction.PosState == PosButtonType.DONE)
        {
            ALLLightSetActive(PMChildCount);
        }



        if((localLightPathType == LightPathorNot.LightPathOff) && (ButtonInteraction.PosState != PosButtonType.DONE) && (PMChildCount > 1))
        {
            //Debug.Log("OOOFFFFFFFFFF");
            ALLLightSetNOTActive(PMChildCount) ;   
        }
        else if(localLightPathType == LightPathorNot.LightPathOn)
        {//Debug.Log("OoooooNNNN");
            for(int i = 0; i < PMChildCount; i ++)
            {
                bool val = this.gameObject.transform.GetChild(i).gameObject.GetComponent<DroneSizeButtonDistance>().DroneValid;
                if((val == false) && (i > 0) /*||( (i > 0) && CollisionNum != -1 (LineValid == false))*/ )
                {
                    LightSetNOTActive(i);
                    //if(CollisionNum >= 0) LightSetNOTActive(CollisionNum);
                    //Debug.Log("FFFFFF: " + i );
                }
                else if((val == true) && (i > 0 ) /*&& (LineValid == true)*/) 
                {
                    LightSetActive(i);
                    //Debug.Log("OOOOOO: " + i);
                }

            

                //Debug.Log("i: " + i + "  CurrentNotValidNum: " +this.gameObject.transform.GetChild(i).gameObject.GetComponent<DroneSizeButtonDistance>().DroneValid);


            }
        }
        
        //for(int i = 0; i < PMChildCount; i ++)
        //{
          //  bool val = this.gameObject.transform.GetChild(i).gameObject.GetComponent<DroneSizeButtonDistance>().DroneValid;
            //if((val == false) && (i > 0) /*||( (i > 0) && CollisionNum != -1 (LineValid == false))*/ )
            //{
              //  LightSetNOTActive(i);
                //if(CollisionNum >= 0) LightSetNOTActive(CollisionNum);
                //Debug.Log("FFFFFF: " + i );
            //}
            //else if((val == true) && (i > 0 ) /*&& (LineValid == true)*/) 
            //{
              //  LightSetActive(i);
                //Debug.Log("OOOOOO: " + i);
            //}

           

            //Debug.Log("i: " + i + "  CurrentNotValidNum: " +this.gameObject.transform.GetChild(i).gameObject.GetComponent<DroneSizeButtonDistance>().DroneValid);


        //}

    }

    void LightSetNOTActive(int DroneNum)
    {
        for(int i = (DroneNum - 1) * 19; i < DroneNum * 19; i ++)
        {
            LightManager.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void LightSetActive(int DroneNum)
    {
        for(int i = (DroneNum - 1) * 19; i < DroneNum * 19; i ++)
        {
            LightManager.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    void ALLLightSetNOTActive(int DroneNum)
    {
        for(int i = 0; i < (DroneNum - 1 ) * 19; i ++)
        {
            LightManager.transform.GetChild(i).gameObject.SetActive(false);
        }
    }


    void ALLLightSetActive(int DroneNum)
    {
        for(int i = 0; i < (DroneNum - 1 ) * 19; i ++)
        {
            LightManager.transform.GetChild(i).gameObject.SetActive(true);
        }
    }


}
