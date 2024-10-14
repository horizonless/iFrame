using System;
using System.Collections;
using System.Collections.Generic;
using Kirurobo;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class iFrameGameManager : MMPersistentSingleton<MMSoundManager>, 
    MMEventListener<MMCharacterEvent>, 
    MMEventListener<CorgiEngineEvent>,
    MMEventListener<MMStateChangeEvent<CharacterStates.MovementStates>>,
    MMEventListener<MMStateChangeEvent<CharacterStates.CharacterConditions>>,
    MMEventListener<PickableItemEvent>
{

    public UniWindowController uniWindowController;
    public MMSoundManager mmSoundManager;
    
    private void OnEnable()
    {
        this.MMEventStartListening<MMCharacterEvent>();
        this.MMEventStartListening<CorgiEngineEvent>();
        this.MMEventStartListening<MMStateChangeEvent<CharacterStates.MovementStates>>();
        this.MMEventStartListening<MMStateChangeEvent<CharacterStates.CharacterConditions>>();
        this.MMEventStartListening<PickableItemEvent>();
        // uniWindowController.windowSize = new Vector2(500, 500);
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
        Debug.Log(InputManager.Instance.PrimaryMovement);
        float x = InputManager.Instance.PrimaryMovement.x;
        // uniWindowController.windowPosition += new Vector2(x, 0);
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
