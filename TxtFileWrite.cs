using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;   
using System.Diagnostics;

using Debug = UnityEngine.Debug;

// This script contain 1. Screen Shoot 2. Write File 3. Connect to Python (OpenCV),  and python file is in Asset


public class TxtFileWrite : MonoBehaviour
{
    StreamWriter writer;
    StreamReader reader;
    List<string> allData;
    
    public GameObject RangeGenerator;
    RangeType GetRangeType;

    [Header("Light Path Setting")]
    LightPathorNot localLightPathType;
    public float FullDistance = 40.0f;
   

    [Header("User Settings")]
    public string NameID;
    public GameObject PM, PosButtonCollection;
    float StartTime, DoneTime, CompleteTime, distance;
    string ChooseScale, NowDateTime;
    bool StartFlag = true;
    bool DoneFlag = true;
    int WayPointNum = 0;
    string msg;

    [Header("Python Call")]
    public string PATH, FinalScore;
    string basePath = @"C:\Users\hscc\Desktop\MrtkTest\Assets\";

    [Header("Clear Setting")]
    public GameObject ClearManager;
    private bool LocalClear = false;


    void Start()
    {
        FileInfo file = new FileInfo(Application.dataPath + "/mytxt.txt");
        Debug.Log("OPEN FILE: " + file.ToString());
        NowDateTime = System.DateTime.Now.ToString();
        //PATH = Application.dataPath + "/" + NameID +".png" ;
        FinalScore = "";

        


    }


    void Update()
    {
        GetRangeType = RangeGenerator.GetComponent<RangeGeneratorManager>().RangeType;
        localLightPathType = PM.GetComponent<ClonePlane>().LightPathorNot;
        Debug.Log("Type is " + GetRangeType);



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
            PATH = Application.dataPath + "/" + NameID + "_"+ GetRangeType + "_" + ChooseScale +".png" ;

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
            
            
            //Debug.Log("AAAAAAA");
            Invoke("ButtonSetInActive", 1.0f);

            //Debug.Log("BBBBBBB");
            Invoke("CapturePicture", 5.0f);

            /*
            if(localLightPathType == LightPathorNot.LightPathOff)
            {
                if(distance >= FullDistance)
                {
                    FinalScore = "76.18561";
                }
                else
                {
                    FinalScore = ((distance/FullDistance) * 100).ToString("0.0000");
                }

                
                Debug.Log("OFF is " + FinalScore);
                msg = "Date Time: " + NowDateTime +" , Name: " + NameID + " , Scale: " + ChooseScale + " , RangeType: " + GetRangeType
                + " , Time: " + CompleteTime + " , WayPoint: " + WayPointNum + " , Distance: " + distance + " Score: " + FinalScore + ", PathType: " + localLightPathType ;
                Debug.Log(msg);
                WriteData(msg);
            }
            else
            {
                if(GetRangeType == RangeType.L)
                {
                    Invoke("NoAuguCallPythonLVersion", 7.0f);
                }
                else
                {
                    Invoke("NoAuguCallPython", 7.0f);   
                }
            }*/
            
            if(GetRangeType == RangeType.L)
            {
                Invoke("NoAuguCallPythonLVersion", 7.0f);
            }
            else
            {
                Invoke("NoAuguCallPython", 7.0f);   
            }

            

            
        }


        LocalClear = ClearManager.GetComponent<ClearAll>().clear;
        //Debug.Log("LLLLL: " + LocalClear);
        if(LocalClear == true)
        {
            DoneFlag = true;
            StartFlag = true;
            FinalScore = "";
            //Debug.Log("LLLLL");
            Invoke("ButtonSetActive", 0.5f);

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


    void CapturePicture()
    {
    
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/" + NameID + "_"+ GetRangeType + "_" + ChooseScale +".png"); 
    }

    void ButtonSetInActive()
    {
        int ChildCount = PosButtonCollection.transform.childCount;
        for(int i = 0; i < ChildCount; i ++)
        {
            PosButtonCollection.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void ButtonSetActive()
    {
        int ChildCount = PosButtonCollection.transform.childCount;
        //Debug.Log("BBBBBBBButton Set Active: " + ChildCount);
        for(int i = 0; i < ChildCount; i ++)
        {
            PosButtonCollection.gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
    }


    void CallPythonOpenCV(string pyScriptPath,string a)
    {
        CallPythonBase(pyScriptPath, a);
    }


    public void CallPythonBase(string pyScriptPath, params string[] argvs) {
        Process process = new Process();
 
        // ptython ?????????????????? python.exe
        process.StartInfo.FileName = @"C:\Users\hscc\anaconda3\python.exe";
 
        // ?????????????????????????????????????????????????????????
        if (argvs != null)
        {
            // ???????????? ???????????????python xxx/xxx/xxx/test.python param1 param2???
            foreach (string item in argvs)
            {
                pyScriptPath += " " + item;
            }
        }
        UnityEngine.Debug.Log(pyScriptPath);
 
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.Arguments = pyScriptPath;     // ??????+??????
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.CreateNoWindow = true;        // ?????????????????????
 
        // ????????????????????????????????????????????????????????????
        process.Start();
        process.BeginOutputReadLine();
        process.OutputDataReceived += new DataReceivedEventHandler(GetData);
        process.WaitForExit();
    }
 
    /// <summary>
    /// ??????????????????
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void GetData(object sender, DataReceivedEventArgs e){        
 
        // ?????????????????????????????????????????????????????????????????????????????????
        if (string.IsNullOrEmpty(e.Data)==false)
        {
            Debug.Log("Score is " + e.Data);
            FinalScore = e.Data;
            Debug.Log("FinalScore is " + FinalScore);
        
        }
    }

    void NoAuguCallPython()
    {
        CallPythonOpenCV(basePath+ "GetScore.py", PATH);

        if(FinalScore != "")
        {
            msg = "Date Time: " + NowDateTime +" , Name: " + NameID + " , Scale: " + ChooseScale + " , RangeType: " + GetRangeType
            + " , Time: " + CompleteTime + " , WayPoint: " + WayPointNum + " , Distance: " + distance + " Score: " + FinalScore + ", PathType: " + localLightPathType      ;
            Debug.Log(msg);
            WriteData(msg);
        }   
    }


    void NoAuguCallPythonLVersion()
    {
        CallPythonOpenCV(basePath+ "GetScoreL.py", PATH);

        if(FinalScore != "")
        {
            msg = "Date Time: " + NowDateTime +" , Name: " + NameID + " , Scale: " + ChooseScale + " , RangeType: " + GetRangeType
            + " , Time: " + CompleteTime + " , WayPoint: " + WayPointNum + " , Distance: " + distance + " Score: " + FinalScore + ", PathType: " + localLightPathType      ;
            Debug.Log(msg);
            WriteData(msg);
        }   
    }
    
    

}


    