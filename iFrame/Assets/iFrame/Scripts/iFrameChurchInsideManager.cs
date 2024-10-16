using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Kirurobo;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using SFB;
using UnityEngine;

public class iFrameChurchInsideManager : MonoBehaviour
{
    public GameObject meGO;
    public GameObject forestGO;
    public GameObject demonGO;
    public GameObject dragonGO;
    public GameObject skeleGo;
    public GameObject churchMasterGO;
    public GameObject blockGO;

    public GameObject rectMeGO;
    public Sprite meSprite;
    public GameObject finAnim;

    public UniWindowController uniWindowController;
    // Start is called before the first frame update
    private string nextNPCName = String.Empty;
    private bool _isTalked;
    void Start()
    {
        // StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false));
        // StandaloneFileBrowser.OpenFolderPanel("Select Folder", Path.Combine(Application.streamingAssetsPath, "TheTruth"), true);
        uniWindowController.shouldFitMonitor = true;
        MMSoundManager.Instance.SetVolumeSfx(0.2f);
        GameManager.Instance.MaximumLives = 0;
        GameManager.Instance.CurrentLives = 0;
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
            if (nextNPCName == "skele")
            {
                churchMasterGO.SetActive(false);
                skeleGo.SetActive(true);
            }
            
            if (nextNPCName == "dragon")
            {
                skeleGo.SetActive(false);
                dragonGO.SetActive(true);
            }

            if (nextNPCName == "demon")
            {
                dragonGO.SetActive(false);
                demonGO.SetActive(true);
            }
            
            if (nextNPCName == "forest")
            {
                demonGO.SetActive(false);
                forestGO.SetActive(true);
            }
            
            if (nextNPCName == "me")
            {
                forestGO.SetActive(false);
                meGO.SetActive(true);
            }
        }

    }

    public void OnChurchMasterFinished()
    {
        _isTalked = true;
        nextNPCName = "skele";
    }
    
    public void OnSkeleFinished()
    {
        _isTalked = true;
        nextNPCName = "dragon";
    }
    public void OnDragonFinished()
    {
        _isTalked = true;
        nextNPCName = "demon";
    }
    
    public void OnDemonFinished()
    {
        _isTalked = true;
        nextNPCName = "forest";
    }
    
    public void OnForestFinished()
    {
        _isTalked = true;
        nextNPCName = "me";
    }

    public void IamYOu()
    {
        rectMeGO = LevelManager.Instance.Players[0].GetComponent<RectMeGetter>().mySpriteGO;
        rectMeGO.GetComponent<Animator>().enabled = false;
        rectMeGO.GetComponent<SpriteRenderer>().sprite = meSprite;
        rectMeGO.GetComponent<SpriteRenderer>().flipX = true;
        rectMeGO.GetComponent<Transform>().localScale = new Vector3(3,3,0.3f);
    }

    public void OnMeFinished()
    {
        finAnim.gameObject.SetActive(true);
    }

    public void ShowTheTruth()
    {
        System.Diagnostics.Process.Start(Path.Combine(Application.streamingAssetsPath, "TheTruth"));
        uniWindowController.isTransparent = true;
        uniWindowController.alphaValue = 0.9f;
    }

}
