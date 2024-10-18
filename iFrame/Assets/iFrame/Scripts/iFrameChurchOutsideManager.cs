using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kirurobo;
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
    void Start()
    {
        uniWindowController.forceWindowed = true;
        uniWindowController.shouldFitMonitor = true;
    }

    public async void PuzzleOneStart()
    {
        Debug.Log("PuzzleOneStart");
        uniWindowController.forceWindowed = true;
        _windowsX = Screen.currentResolution.width / 4;
        _windowsY = Screen.currentResolution.height / 3;
        // uniWindowController.forceWindowed = true;
        // Debug.Log("windows x:" + _windowsX + " y:" + _windowsY);
        uniWindowController.windowSize = new Vector2(_windowsX, _windowsY);
        // uniWindowController.windowPosition = Vector2.zero;
        await Task.Delay(5000);
        uniWindowController.shouldFitMonitor = true;
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
            Debug.Log("pass");
            //pass
            return;
        }

        Debug.Log("no pass");
        _isEight = false;
        _isTwo = false;
        _isThree = false;
    }
}
