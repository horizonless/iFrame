using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kirurobo;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using Unity.VisualScripting;
using UnityEngine;

public class iFrameMountainUpwardManager : MonoBehaviour,
MMEventListener<MMCharacterEvent>,
MMEventListener<CorgiEngineEvent>
{
    
    public UniWindowController uniWindowController;
    public MMSoundManager mmSoundManager;
    public Camera cam;
    public GameObject NPC;
    public GameObject signPost;
    private int _windowsX;
    private int _windowsY;
    private Vector3 _lastPosition;

    private bool _finishTalk = false;

    private bool _hasDash = false;
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
        // Screen.fullScreen = true;
        uniWindowController.shouldFitMonitor = true;
        MMSoundManager.Instance.SetVolumeSfx(0.5f);
        GameManager.Instance.MaximumLives = 0;
        GameManager.Instance.CurrentLives = 0;
        // uniWindowController.isZoomed = true;
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
            Debug.Log("tyep" + characterEvent.EventType);
            switch (characterEvent.EventType)
            {
                case MMCharacterEventTypes.Ladder:
                    if (uniWindowController.alphaValue < 0.5f) return;
                    uniWindowController.alphaValue -= 0.1f;
                    // if (IFrameMonsterChasingManager == null) return;
                    // IFrameMonsterChasingManager.OnPlayerDied();
                    break;
            }	
        }
    }

    public async void OnDragonFinishCov()
    {
        signPost.gameObject.SetActive(_hasDash);
        _finishTalk = true;
        _lastPosition = cam.transform.position;
        uniWindowController.isTransparent = true;
        uniWindowController.isTopmost = true;
        _windowsX = Screen.currentResolution.width / 4;
        _windowsY = Screen.currentResolution.height / 3;
        // uniWindowController.forceWindowed = true;
        Debug.Log("windows x:" + _windowsX + " y:" + _windowsY);
        uniWindowController.windowSize = new Vector2(_windowsX, _windowsY);
        uniWindowController.windowPosition = Vector2.zero;
        LevelManager.Instance.Players[0].GetComponent<CharacterDash>().enabled = _hasDash;
        uniWindowController.alphaValue = 0.9f;
        // await Task.Delay(1000);
        // NPC.gameObject.SetActive(false);
    }

    public void GetDash()
    {
        Debug.Log("get dash");
        _hasDash = true;
    }

    public void OnMMEvent(CorgiEngineEvent eventType)
    {
        Debug.Log("engine" + eventType);
        switch (eventType.EventType)
        {
            case CorgiEngineEventTypes.Respawn:
                if (uniWindowController.alphaValue <  0.5f) return;
                uniWindowController.alphaValue -= 0.1f;
                break;
            case CorgiEngineEventTypes.LevelStart:
                break;
        }
    }
}
