using System;
using System.Collections;
using System.Collections.Generic;
using Kirurobo;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class iFrameGameManager : MonoBehaviour, 
    MMEventListener<MMCharacterEvent>, 
    MMEventListener<CorgiEngineEvent>,
    MMEventListener<MMStateChangeEvent<CharacterStates.MovementStates>>,
    MMEventListener<MMStateChangeEvent<CharacterStates.CharacterConditions>>,
    MMEventListener<PickableItemEvent>
{

    public UniWindowController uniWindowController;
    public MMSoundManager mmSoundManager;
    public Camera cam;
    private Vector3 _lastPosition;
    
    private void OnEnable()
    {
        this.MMEventStartListening<MMCharacterEvent>();
        this.MMEventStartListening<CorgiEngineEvent>();
        this.MMEventStartListening<MMStateChangeEvent<CharacterStates.MovementStates>>();
        this.MMEventStartListening<MMStateChangeEvent<CharacterStates.CharacterConditions>>();
        this.MMEventStartListening<PickableItemEvent>();
        uniWindowController.windowSize = new Vector2(500, 300);
        uniWindowController.windowPosition = Vector2.zero;
        _lastPosition = cam.transform.position;
    }

    private void OnDisable()
    {
        this.MMEventStopListening<MMCharacterEvent>();
        this.MMEventStopListening<CorgiEngineEvent>();
        this.MMEventStopListening<MMStateChangeEvent<CharacterStates.MovementStates>>();
        this.MMEventStopListening<MMStateChangeEvent<CharacterStates.CharacterConditions>>();
        this.MMEventStopListening<PickableItemEvent>();
    }

    private void Update()
    {
        // return;
        Debug.Log("ScreenSize w:" + Screen.width + " h:" + Screen.height + "current x:" + uniWindowController.windowPosition.x +  "current y:" + uniWindowController.windowPosition.y + " Client size x:" + uniWindowController.clientSize.x);
        // return;
        if (uniWindowController.windowPosition.x > Screen.width)
        {
            var initPos = new Vector2(0,uniWindowController.windowPosition.y);
            uniWindowController.windowPosition = initPos;
        }
        
        var delta = cam.transform.position - _lastPosition;
        _lastPosition = cam.transform.position;
        Debug.Log("delta:" + delta);
        uniWindowController.windowPosition += new Vector2(delta.x * 100, 0);
        // Debug.Log("ScreenSize w:" + Screen.width + " h:" + Screen.height + "current x:" + uniWindowController.windowPosition.x + " Client size x:" + uniWindowController.clientSize.x);
    }

    public void OnMMEvent(MMCharacterEvent characterEvent)
    {
        Debug.Log(characterEvent);
        if(characterEvent.TargetCharacter.CharacterType == Character.CharacterTypes.Player)
        {
            switch (characterEvent.EventType)
            {
                case MMCharacterEventTypes.Jump:
                    // MMAchievementManager.AddProgress ("JumpAround", 1);
                    break;
            }	
        }
    }

    public void OnMMEvent(CorgiEngineEvent eventType)
    {
        // throw new System.NotImplementedException();
    }

    public void OnMMEvent(MMStateChangeEvent<CharacterStates.MovementStates> eventType)
    {
        // throw new System.NotImplementedException();
    }

    public void OnMMEvent(MMStateChangeEvent<CharacterStates.CharacterConditions> eventType)
    {
        // throw new System.NotImplementedException();
    }

    public void OnMMEvent(PickableItemEvent eventType)
    {
        // throw new System.NotImplementedException();
    }
}
