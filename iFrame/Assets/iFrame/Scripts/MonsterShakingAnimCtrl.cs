using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Feedbacks;
using MoreMountains.FeedbacksForThirdParty;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterShakingAnimCtrl : MonoBehaviour
{
	public AudioClip MonsterShowClip;
	public BoxCollider2D AnimTrigger;
	public Animator AnimatorMonster;
	public MMCinemachineCameraShaker Shaker;
	public FinishLevel FinishLevel;
	public GameObject ThePlayer;
    public void PlayMosterShowMusic()
    {
		MMSoundManagerPlayOptions options = MMSoundManagerPlayOptions.Default;
		options.ID = 1;
		options.Loop = false;
		options.Location = Vector3.zero;
		options.MmSoundManagerTrack = MMSoundManager.MMSoundManagerTracks.Music;
	    MMSoundManagerSoundPlayEvent.Trigger(MonsterShowClip, options);
        
    }

    public void MonsterTrigger()
    {
	    Debug.Log("Anim trigger");

	    LevelManager.Instance.Players[0].GetComponent<iFrameCharacterControl>().WalkFeedBack.StopFeedbacks();
	    AnimatorMonster.SetBool("LevelFinished", true);
	    // AnimatorMonster.Play("MonsterShake");
    }

    public void MonsterShakeCamera()
    {
	    Shaker.TestShake();
	    // MMCameraShakeEvent.Trigger(5f, 1f, 1f, 0f, 0f, 0f, false, new MMChannelData(ChannelMode, Channel, MMChannelDefinition));
    }

    public void ToChasingLevel()
    {
	    FinishLevel.TriggerButtonAction(LevelManager.Instance.Players[0].gameObject);
	    // SceneManager.LoadScene("iFrame_MonsterChasing");
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
