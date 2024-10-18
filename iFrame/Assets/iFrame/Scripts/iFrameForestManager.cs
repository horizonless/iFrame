using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class iFrameForestManager : MonoBehaviour
{
    public MMSoundManager ForestSoundManager;
    public AudioSource BGMAudioSource;
    public AudioClip oldForestClip;
    public GameObject block;
    public GameObject NPC;
    public GameObject startAnim;
    void Start()
    {
	    Debug.Log("play anim");
        MMSoundManager.Instance.SetVolumeSfx(0.5f);
        startAnim.gameObject.SetActive(true);
        GameManager.Instance.MaximumLives = 0;
        GameManager.Instance.CurrentLives = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFinishCov()
    {
	    block.gameObject.SetActive(false);
	    // NPC.gameObject.SetActive(false);
    }

    public void OnEnterOldForest()
    {
        // ForestSoundManager.FadeTrack(BGMAudioSource, 0.3f, 1f, 0f);
		MMSoundManagerPlayOptions options = MMSoundManagerPlayOptions.Default;
		options.ID = 1;
		options.Loop = true;
		options.Location = Vector3.zero;
		options.MmSoundManagerTrack = MMSoundManager.MMSoundManagerTracks.Music;
		options.Fade = true;
		options.FadeDuration = 1f;
	    MMSoundManagerSoundPlayEvent.Trigger(oldForestClip, options);
        // ForestSoundManager.p
        // ForestSoundManager.FadeSound(BGMAudioSource, 0.3f, 1f, 0f);
        // ForestSoundManager.PlaySound(oldForestClip);
    }
}
