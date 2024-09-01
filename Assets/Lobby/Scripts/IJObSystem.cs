using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
public class IJobSystem : MonoBehaviour
{
    public static IJobSystem Instance;
    static string filepath;
    ExpensiveCalculations expensiveJob = new ExpensiveCalculations();
    public struct  ExpensiveCalculations : IJob
    {
        public void Execute()
        {
            Debug.LogWarning("Working on expensive calculation");
          //  PrintingManager.instance.PrintFiles(filepath);  
        }

    }
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnCallExpensiveCalculation(string path)
    {
        expensiveJob = new ExpensiveCalculations { };
        Debug.Log(" path inside job is " + path);
        filepath = path;
        JobHandle jHandle = expensiveJob.Schedule();

        if(jHandle.IsCompleted)
        {
            jHandle.Complete();
            Debug.Log("Job COmpleted. Printing");
        }


        //expensiveJob.Execute();
    
    }
}
