using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kirurobo;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class iFrameChurchOutsideManager : MonoBehaviour
{
    public UniWindowController uniWindowController;
    private int _windowsX;
    private int _windowsY;
    private string answer1;
    private bool _isEight;
    private bool _isTwo;
    private bool _isThree;
    public GameObject block;
    public GameObject npc;
    public FinishLevel FinishLevel;
    void Start()
    {
        // uniWindowController.forceWindowed = true;
        // uniWindowController.shouldFitMonitor = true;
        uniWindowController.windowSize = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        uniWindowController.windowPosition = Vector2.zero;
        GameManager.Instance.MaximumLives = 0;
        GameManager.Instance.CurrentLives = 0;
    }

    public void PuzzleOneStart()
    {
        // uniWindowController.shouldFitMonitor = false;
        Debug.Log("PuzzleOneStart");
        // uniWindowController.forceWindowed = true;
        _windowsX = Screen.currentResolution.width / 4;
        _windowsY = Screen.currentResolution.height / 3;
        // uniWindowController.forceWindowed = true;
        // Debug.Log("windows x:" + _windowsX + " y:" + _windowsY);
        uniWindowController.windowSize = new Vector2(_windowsX, _windowsY);
        uniWindowController.windowPosition = Vector2.zero;
        // await Task.Delay(5000);
        // uniWindowController.shouldFitMonitor = true;
    }

    public void PuzzleOneEight()
    {
        Debug.Log("8");
        _isEight = true;
    }
    
    public void PuzzleOneTwo()
    {
        Debug.Log("2");
        _isTwo = true;
    }
    
    public void PuzzleOneThree()
    {
        Debug.Log("3");
        _isThree = true;
    }

    public void PuzzleOneFinished()
    {
        if (_isEight && _isTwo && _isThree)
        {
            FinishLevel.GoToNextLevel();
            Debug.Log("pass");
            //pass
            block.gameObject.SetActive(false);
            npc.gameObject.SetActive(false);
            LevelManager.Instance.Players[0].GetComponent<iFrameCharacterControl>().WalkFeedBack.PlayFeedbacks();
            return;
        }

        Debug.Log("no pass");
        _isEight = false;
        _isTwo = false;
        _isThree = false;
    }
}
