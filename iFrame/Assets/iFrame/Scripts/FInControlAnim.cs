using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

public class FInControlAnim : MonoBehaviour
{
    public AudioClip finClip;
    // public MMSoundManager SoundManager;
    public MMF_Player MmfPlayer;
    public void StartFinAnim()
    {
        MmfPlayer.PlayFeedbacks();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
