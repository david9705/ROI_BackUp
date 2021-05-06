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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PMChildCount = this.transform.childCount;
        //LineValid = this.GetComponent<ClonePlane>().LineCollision;
        //CollisionNum = this.GetComponent<ClonePlane>().LineCollisionNum;
        Debug.Log("Line ID: " + LineValid + " NUM: " + CollisionNum);

        for(int i = 0; i < PMChildCount; i ++)
        {
            bool val = this.gameObject.transform.GetChild(i).gameObject.GetComponent<DroneSizeButtonDistance>().DroneValid;
            if((val == false) && (i > 0) /*||( (i > 0) && CollisionNum != -1 (LineValid == false))*/ )
            {
                LightSetNOTActive(i);
                //if(CollisionNum >= 0) LightSetNOTActive(CollisionNum);
                Debug.Log("FFFFFF");
            }
            else if((val == true) && (i > 0 ) /*&& (LineValid == true)*/) 
            {
                LightSetActive(i);
                Debug.Log("OOOOOO");
            }

           

            Debug.Log("i: " + i + "  CurrentNotValidNum: " +this.gameObject.transform.GetChild(i).gameObject.GetComponent<DroneSizeButtonDistance>().DroneValid);


        }

    }

    void LightSetNOTActive(int DroneNum)
    {
        for(int i = (DroneNum - 1) * 15; i < DroneNum * 15; i ++)
        {
            LightManager.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void LightSetActive(int DroneNum)
    {
        for(int i = (DroneNum - 1) * 15; i < DroneNum * 15; i ++)
        {
            LightManager.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
