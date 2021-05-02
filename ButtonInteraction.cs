using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Buttons;
using UnityEngine.Events;

[System.Serializable]
public class GameObjEvent : UnityEvent<GameObject> {}  //use to override the class type and the <> type must be  GameObject type 
  
public enum PosButtonType
{
    PLACE,
    DELETE,
    CANCEL
};

public class ButtonInteraction : Button
{

    
    [SerializeField]
    public static PosButtonType PosState = PosButtonType.CANCEL;
    

    public GameObjEvent OnMyButtonClicked;
    //public bool Pos = true ;
    
    


    void Start()
    {
        //Debug.Log("thisAAA" + this.name);
        //OnButtonClicked += OnMyButtonClicked.Invoke;
        OnButtonClicked += (go) => Debugger(go);
        //Pos = false;  /*Debug.Log(go.name + " got clicked");*/
        
    }
    /*
    void Update()
    {
        
    }*/
    
    public void Debugger(GameObject go)
    {
        //Debug.Log("AAAA");

        if(this.name == "PlaceButton")
        {
            PosState = PosButtonType.PLACE;
            //Debug.Log("PPPP");
        }
        else if(this.name == "DeleteButton")
        {
            PosState = PosButtonType.DELETE;
            //Debug.Log("DDDDDD");
        }
        else if(this.name == "CancelButton")
        {
            PosState = PosButtonType.CANCEL;
            //Debug.Log("CCCCCCCC");
        }

        print("State is " + PosState);


        //Debug.Log(go.name);
        //Pos = false;
       
    }


    

}
