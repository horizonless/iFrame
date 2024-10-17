using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kirurobo;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class iFrameMonsterChasingManager : MonoBehaviour,
    MMEventListener<CorgiEngineEvent>,
    MMEventListener<MMCharacterEvent>
{
    public UniWindowController uniWindowController;
    private int _windowsX;
    private int _windowsY;
    public Transform cam;
    private Vector3 _lastPosition;
    private Vector3 _initPos;
    private Vector3 _LastPlayerTras;

    private float _maxYDelta = 0.2f;
    public int currentWindowXSpeed = 1;

    public int frames = 0;

    private bool _shouldMove = true;

    private int eazy = 3;

    private bool notEazy;
    // Start is called before the first frame update
    private void OnEnable()
    {
        // this.MMEventStartListening<MMCharacterEvent>();
        // this.MMEventStartListening<CorgiEngineEvent>();
    }

    private void OnDisable()
    {
        // this.MMEventStopListening<MMCharacterEvent>();
        // this.MMEventStopListening<CorgiEngineEvent>();
    }

    void Start()
    {
        _LastPlayerTras = LevelManager.Instance.Players[0].transform.position;
        _lastPosition = cam.transform.position;
        _windowsX = Screen.currentResolution.width / 3;
        _windowsY = Screen.currentResolution.height / 2;
        uniWindowController.isTopmost = true;
        uniWindowController.isTransparent = false;
        Debug.Log("windows x:" + _windowsX + " y:" + _windowsY);
        uniWindowController.windowSize = new Vector2(_windowsX + 100, _windowsY + 50);
        _initPos = new Vector2(0, Screen.currentResolution.height / 2 - (_windowsY / 2) );
        uniWindowController.windowPosition = _initPos;
        // uniWindowController.alphaValue = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // return;
        if (notEazy)
        {
            if (frames < eazy) {
                frames ++;
                return;
            }
            frames = 0;
        }


        if (uniWindowController.windowPosition.x < 0)
        {
            // var initPos = new Vector2(0,uniWindowController.windowPosition.y);
            uniWindowController.windowPosition = _initPos;
        }
        
        if ((uniWindowController.windowPosition.x + _windowsX)  > Screen.currentResolution.width )
        {
            // var initPos = new Vector2(Screen.currentResolution.width - _windowsX,uniWindowController.windowPosition.y);
            uniWindowController.windowPosition = _initPos;
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
        var currentPlayerPos = LevelManager.Instance.Players[0].transform.position;
        var playerDelta = currentPlayerPos - _LastPlayerTras;
        _LastPlayerTras = currentPlayerPos;
        // Debug.Log("delta:" + delta);
        if (playerDelta.y > _maxYDelta) playerDelta.y = _maxYDelta;
        if (playerDelta.y < -_maxYDelta) playerDelta.y = -_maxYDelta;
        if (delta.x > 1.5f) delta.x = 1.5f;
        if (delta.x < -1.5f) delta.x = -1.5f;

        // Debug.Log("player delta:" + playerDelta);
        // uniWindowController.windowPosition += new Vector2(currentWindowXSpeed, playerDelta.y * 10);
        // if (delta.x < 1) delta.x = 1;
        if (!_shouldMove) return;
        uniWindowController.windowPosition += new Vector2(currentWindowXSpeed, playerDelta.y * 10);
        // Debug.Log("ScreenSize w:" + Screen.width + " h:" + Screen.height + "current x:" + uniWindowController.windowPosition.x + " Client size x:" + uniWindowController.clientSize.x);
    }

    public void OnMMEvent(CorgiEngineEvent eventType)
    {
            // Debug.Log("EngineEvent:" + eventType.EventType.ToString());
			switch (eventType.EventType)
			{
				case CorgiEngineEventTypes.PlayerDeath:
					this.gameObject.SetActive(false);
					break;
				case CorgiEngineEventTypes.LevelStart:
					this.gameObject.SetActive(false);
                    Debug.Log("respawn");
					break;
			}
    }

    public void OnMMEvent(MMCharacterEvent eventType)
    {
        // Debug.Log("CharacterEvent:" + eventType.EventType.ToString());
        // Debug.Log("respawn");
        // throw new System.NotImplementedException();
    }

    public async void OnPlayerDied()
    {
        _shouldMove = false;

    }
    public async void OnPlayerRespawn()
    {
        _shouldMove = true;
        uniWindowController.windowPosition = _initPos;
    }

    public void OnNewCheckPoint()
    {
        
    }
    public void SetToMid()
    {
        notEazy = true;
    }
    
    public void SetToHard()
    {
        currentWindowXSpeed = 2;
    }
}
