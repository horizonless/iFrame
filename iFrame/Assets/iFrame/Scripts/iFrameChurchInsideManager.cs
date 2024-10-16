using System.Collections;
using System.Collections.Generic;
using System.IO;
using SFB;
using UnityEngine;

public class iFrameChurchInsideManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false));
        // StandaloneFileBrowser.OpenFolderPanel("Select Folder", Path.Combine(Application.streamingAssetsPath, "TheTruth"), true);
        System.Diagnostics.Process.Start(Path.Combine(Application.streamingAssetsPath, "TheTruth"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
