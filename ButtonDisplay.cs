using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDisplay : MonoBehaviour
{

    [SerializeField]
    private TextMesh ButtonText;    

    public GameObject PlaceButton;

    // Start is called before the first frame update
    void Start()
    {
        ButtonText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(ButtonInteraction.PosState == PosButtonType.PLACE)
        {
            ButtonText.text = "Place";
        }
        else if(ButtonInteraction.PosState == PosButtonType.DELETE)
        {
            ButtonText.text = "Delete";
        }
        else if(ButtonInteraction.PosState == PosButtonType.CANCEL)
        {
            ButtonText.text = "Edit";
        }
        
    }
}
