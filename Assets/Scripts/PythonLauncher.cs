using UnityEngine;
using System.Diagnostics;

public class PythonLauncher : MonoBehaviour
{
    private Process pythonProcess;

    void Start()
    {
        string path = Application.streamingAssetsPath + "/main.exe";
        pythonProcess = new Process();
        pythonProcess.StartInfo.FileName = path;
        pythonProcess.StartInfo.UseShellExecute = false;
        pythonProcess.StartInfo.CreateNoWindow = true;
        pythonProcess.Start();
    }

    void OnApplicationQuit()
    {
        if (pythonProcess != null && !pythonProcess.HasExited)
        {
            pythonProcess.Kill();
        }
    }
}