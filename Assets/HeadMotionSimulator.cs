using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class HeadMotionSimulator : MonoBehaviour
{
    public string csvFilePath = "C:/Users/mohammad.elahi/Unity3D3/head_motion2.csv";
    private List<HeadMotionData> motionData;
    private float timeBetweenRows = 0.001f; // 1 millisecond

    private List<HeadMotionData> ReadCSVFile(string filePath)
    {
        List<HeadMotionData> data = new List<HeadMotionData>();
        if (File.Exists(filePath))
        {
            // Read the lines of the .csv file
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 1; i < lines.Length; i++) // Start from 1 to skip the header
            {
                string[] values = lines[i].Split(',');
                if (values.Length >= 8) // Ensure all columns are present
                {
                    HeadMotionData motion = new HeadMotionData();
                    // Parse and assign the values to the HeadMotionData object
                    motion.time = float.Parse(values[0]);
                    motion.x = float.Parse(values[1]);
                    motion.y = float.Parse(values[2]);
                    motion.z = float.Parse(values[3]);
                    motion.qx = float.Parse(values[4]);
                    motion.qy = float.Parse(values[5]);
                    motion.qz = float.Parse(values[6]);
                    motion.qw = float.Parse(values[7]);
                    data.Add(motion);
                }
                else
                {
                    Debug.LogError("Invalid data in the .csv file at line " + (i + 1));
                }
            }
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
        return data;
    }
}

public class HeadMotionData
{
    public float time;
    public float x;
    public float y;
    public float z;
    public float qx;
    public float qy;
    public float qz;
    public float qw;
}


