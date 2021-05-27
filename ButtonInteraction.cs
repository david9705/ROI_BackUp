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
    CANCEL,
    DONE
};

public class ButtonInteraction : Button
{

    
    [SerializeField]
    public static PosButtonType PosState = PosButtonType.CANCEL;
    

    public GameObjEvent OnMyButtonClicked;

    /*  Pass the Button out*/
    public ButtonStateEnum NowButtonState;
 
    [Header("Clear Setting")]
    public GameObject ClearManager;
    private bool LocalClear = false;
    


    void Start()
    {
        //Debug.Log("thisAAA" + this.name);
        //OnButtonClicked += OnMyButtonClicked.Invoke;
        OnButtonClicked += (go) => Debugger(go);
        //Pos = false;  /*Debug.Log(go.name + " got clicked");*/
        
    }
    
    void Update()
    {
        //Debug.Log(/*this.name + */" button STATE is " + PosState);
        NowButtonState = ButtonState;

        LocalClear = ClearManager.GetComponent<ClearAll>().clear;
        //Debug.Log("LLLLL: " + LocalClear);
        if(LocalClear == true)
        {
            PosState = PosButtonType.CANCEL;
        }
    }
    
    public void Debugger(GameObject go)
    {
        //Debug.Log("AAAA");
        Debug.Log("Button State : "+ ButtonState);

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
            Debug.Log("CCCCCCCC");
        }
        else if(this.name == "DoneButton")
        {
            PosState = PosButtonType.DONE;
            Debug.Log("DDDONE");
        }

        print("State is " + PosState);


        //Debug.Log(go.name);
        //Pos = false;
       
    }


    

}
