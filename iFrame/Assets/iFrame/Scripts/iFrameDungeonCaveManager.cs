using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iFrameDungeonCaveManager : MonoBehaviour
{
    private bool _hasFire = true;

    public GameObject cursorPuzzleGO;
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
    
    
}
