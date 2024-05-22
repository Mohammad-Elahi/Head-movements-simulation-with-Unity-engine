# Head Motion Simulator in Unity

This project uses the Unity engine to simulate head movements. A cube is created in Unity and attached with a C# script that reads a CSV file named `head_motion.csv`. This file includes time and x, y, z positions and qx, qy, qz, qw orientations.

## license
This project is licensed under the MIT License - see the LICENSE.md file for details.

## Prerequisites

- Unity Editor version 2022.3.19f1. If you want to download the repository and run it in your Unity, you should adjust your Unity editor version to 2022.3.19f1. Alternatively, you can use the instructions and C# code with your own Unity editor version.

## Setup

1. Clone the repository.
2. Open the project in Unity Editor.
3. Replace the `csvFilePath` in the `HeadMotionSimulator.cs` script in the Assets with the path of your `head_motion.csv` file.

## Code Overview

The main script `HeadMotionSimulator.cs` reads the `head_motion.csv` file and simulates the head movements based on the data. The `HeadMotionData` class is used to store the data for each row in the CSV file.

```csharp
using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class HeadMotionSimulator : MonoBehaviour
{
    public string csvFilePath = "your_head_motion.csv_path";
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
```
Note: Replace the `your_head_motion.csv_path` with the path of your `head_motion.csv` file.
