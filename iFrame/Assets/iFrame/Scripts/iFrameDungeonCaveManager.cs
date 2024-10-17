using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class iFrameDungeonCaveManager : MonoBehaviour
{
    private bool _hasFire = true;
    public GameObject cursorPuzzleGO;

    public CharacterGroundNormalGravity NormalGravity;
    public CorgiController CorgiController;

    public GameObject block;

    public GameObject eggBG;
    // Start is called before the first frame update
    void Start()
    {
        MMSoundManager.Instance.SetVolumeSfx(0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSacrificeFire()
    {
        _hasFire = false;
    }
    
    public void OnFinishDemoConversation()
    {
        cursorPuzzleGO.SetActive(!_hasFire);
        block.gameObject.SetActive(false);
    }
    
    public void OnEnterExitRoom()
    {
        LevelManager.Instance.Players[0].GetComponent<CharacterGroundNormalGravity>().enabled = true;
        LevelManager.Instance.Players[0].GetComponent<CorgiController>().StickToSlopes = false;
        eggBG.SetActive(true);
        // NormalGravity.enabled = true;
        // CorgiController.StickToSlopes = false;
    }
}
