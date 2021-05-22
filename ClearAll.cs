using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAll : MonoBehaviour
{


    public bool clear = false;
    public GameObject PM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(clear)
        {
            foreach(Transform child in PM.transform)
            {
                Destroy(child.gameObject);
            }
        }
        
    }
}
