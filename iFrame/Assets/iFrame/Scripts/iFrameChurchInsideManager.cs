using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using MoreMountains.Tools;
using SFB;
using UnityEngine;

public class iFrameChurchInsideManager : MonoBehaviour
{
    public Collider2D topCollider;
    public GameObject dragonGO;
    public GameObject churchMasterGO;
    public GameObject blockGO;
    // Start is called before the first frame update
    private string nextNPCName = String.Empty;
    private bool _isTalked;
    void Start()
    {
        // StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false));
        // StandaloneFileBrowser.OpenFolderPanel("Select Folder", Path.Combine(Application.streamingAssetsPath, "TheTruth"), true);
        MMSoundManager.Instance.SetVolumeSfx(0.2f);
        System.Diagnostics.Process.Start(Path.Combine(Application.streamingAssetsPath, "TheTruth"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnConvFinished()
    {
        Debug.Log("conv finished");
        
    }

    public void OnPassTop()
    {
        Debug.Log("pass top");
        if (_isTalked)
        {
            _isTalked = false;
            if (nextNPCName == String.Empty)
            {
                churchMasterGO.SetActive(false);
                dragonGO.SetActive(true);
            }

            if (nextNPCName == "dragon")
            {
                dragonGO.SetActive(true);
            }
        }

    }

    public void OnChurchMasterFinished()
    {
        _isTalked = true;
        nextNPCName = "dragon";
    }
    
    public void OnDragonFinished()
    {
        _isTalked = true;
        nextNPCName = "";
    }
}
