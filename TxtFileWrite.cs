using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;   


public class TxtFileWrite : MonoBehaviour
{
    StreamWriter writer;
    StreamReader reader;
    List<string> allData;

    public string NameID;
    public GameObject PM;
    float StartTime, DoneTime, CompleteTime, distance;
    string ChooseScale, NowDateTime;
    bool StartFlag = true;
    bool DoneFlag = true;
    int WayPointNum = 0;
    string msg;

    void Start()
    {
        FileInfo file = new FileInfo(Application.dataPath + "/mytxt.txt");
        NowDateTime = System.DateTime.Now.ToString();

    }


    void Update()
    {
        if((SizeButtonCollection.SizeButtonState != SizeButtonType.NULLL) && (StartFlag == true)) 
        {
            StartFlag = false;
            StartTime = Time.time;
            //Debug.Log("SSSS Time is " + StartTime);
            if(SizeButtonCollection.SizeButtonState == SizeButtonType.SMALL)
            {
                ChooseScale = "SMALL";
            }
            else if(SizeButtonCollection.SizeButtonState == SizeButtonType.MEDIUM)
            {
                ChooseScale = "MEDIUM";
            }
            else if(SizeButtonCollection.SizeButtonState == SizeButtonType.LARGE)
            {
                ChooseScale = "LARGE";
            }

        }
        if((ButtonInteraction.PosState == PosButtonType.DONE) && (DoneFlag == true))
        {
            DoneFlag = false;
            DoneTime = Time.time;
            CompleteTime = DoneTime - StartTime;
            WayPointNum = PM.transform.childCount;

            for(int i = 0; i < WayPointNum - 1; i ++)
            {
                distance += Vector3.Distance(PM.gameObject.transform.GetChild(i).gameObject.transform.position, PM.gameObject.transform.GetChild(i+1).gameObject.transform.position) ;
                //Debug.Log("DD is : " + distance);
            }

            //Debug.Log("Finish Time is " + CompleteTime);
            msg = "Date Time: " + NowDateTime +" , Name: " + NameID + " , Scale: " + ChooseScale + " , Time: " + CompleteTime + " , WayPoint: " + WayPointNum + " , Distance: " + distance;
            Debug.Log(msg);
            WriteData(msg);
        }
    

    }
    
    void WriteData(string message)
    {
        FileInfo file = new FileInfo(Application.dataPath + "/mytxt.txt");
        if (!file.Exists)
        {
            writer = file.CreateText();
        }
        else
        {
            writer = file.AppendText();
        }
        writer.WriteLine(message);
        writer.Flush();
        writer.Dispose();
        writer.Close();
    }

    
    

}


    