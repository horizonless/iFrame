using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class iFrameDungeonCaveManager : MonoBehaviour
{
    private bool _hasFire = true;
    public GameObject cursorPuzzleGO;

    public CharacterGroundNormalGravity NormalGravity;
    public CorgiController CorgiController;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    
    public void OnEnterExitRoom()
    {
        LevelManager.Instance.Players[0].GetComponent<CharacterGroundNormalGravity>().enabled = true;
        LevelManager.Instance.Players[0].GetComponent<CorgiController>().StickToSlopes = false;
        // NormalGravity.enabled = true;
        // CorgiController.StickToSlopes = false;
    }
}
