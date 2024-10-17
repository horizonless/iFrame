using System;
using System.Collections;
using System.Collections.Generic;
using Kirurobo;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using Unity.VisualScripting;
using UnityEngine;

public class iFrameMountainUpwardManager : MonoBehaviour,
MMEventListener<MMCharacterEvent>
{
    
    public UniWindowController uniWindowController;
    public MMSoundManager mmSoundManager;
    public Camera cam;
    private int _windowsX;
    private int _windowsY;
    private Vector3 _lastPosition;

    private bool _finishTalk = false;
    // Start is called before the first frame update
    private void OnEnable()
    {
        this.MMEventStartListening<MMCharacterEvent>();
    }

    private void OnDisable()
    {
        this.MMEventStopListening<MMCharacterEvent>();
    }

    void Start()
    {
        uniWindowController.shouldFitMonitor = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_finishTalk) return;
        // Debug.Log("ScreenSize w:" + Screen.currentResolution.width + " h:" + Screen.currentResolution.height + "current x:" + uniWindowController.windowPosition.x +  "current y:" + uniWindowController.windowPosition.y + " Client size x:" + uniWindowController.clientSize.x);
        if (uniWindowController.windowPosition.x < 0)
        {
            var initPos = new Vector2(0,uniWindowController.windowPosition.y);
            uniWindowController.windowPosition = initPos;
        }
        
        if ((uniWindowController.windowPosition.x + _windowsX)  > Screen.currentResolution.width )
        {
            var initPos = new Vector2(Screen.currentResolution.width - _windowsX,uniWindowController.windowPosition.y);
            uniWindowController.windowPosition = initPos;
        }
        
        if (uniWindowController.windowPosition.y < 0)
        {
            var initPos = new Vector2(uniWindowController.windowPosition.x, 0);
            uniWindowController.windowPosition = initPos;
        }
        
        if ((uniWindowController.windowPosition.y + _windowsY)  > Screen.currentResolution.height )
        {
            var initPos = new Vector2(uniWindowController.windowPosition.x, 0);
            uniWindowController.windowPosition = initPos;
        }
        
        var delta = cam.transform.position - _lastPosition;
        _lastPosition = cam.transform.position;
        // Debug.Log("delta:" + delta);
        uniWindowController.windowPosition += new Vector2(delta.x * 100, delta.y * 50);
        // Debug.Log("ScreenSize w:" + Screen.width + " h:" + Screen.height + "current x:" + uniWindowController.windowPosition.x + " Client size x:" + uniWindowController.clientSize.x);
    }

    public void OnMMEvent(MMCharacterEvent characterEvent)
    {
        if(characterEvent.TargetCharacter.CharacterType == Character.CharacterTypes.Player)
        {
            switch (characterEvent.EventType)
            {
                case MMCharacterEventTypes.Ladder:
                    // if (IFrameMonsterChasingManager == null) return;
                    // IFrameMonsterChasingManager.OnPlayerDied();
                    break;
            }	
        }
    }

    public void OnDragonFinishCov()
    {
        _finishTalk = true;
        _lastPosition = cam.transform.position;
        _windowsX = Screen.currentResolution.width / 4;
        _windowsY = Screen.currentResolution.height / 3;
        uniWindowController.isTopmost = true;
        // uniWindowController.forceWindowed = true;
        uniWindowController.isTransparent = true;
        Debug.Log("windows x:" + _windowsX + " y:" + _windowsY);
        uniWindowController.windowSize = new Vector2(_windowsX, _windowsY);
        uniWindowController.windowPosition = Vector2.zero;
        LevelManager.Instance.Players[0].GetComponent<CharacterDash>().enabled = true;
        uniWindowController.alphaValue = 0.7f;
    }

}
