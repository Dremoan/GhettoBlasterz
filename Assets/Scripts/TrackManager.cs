using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour 
{
    public GameEvent beatEvent;
	public TrackObject[] allTracks;
	public AudioSource[] ambienceSources;
	public AudioSource[] blastSources;
	public ShootScript shootScript;
	public int countThreshold = 10;
	private float usedBpm = 0;
	private int bodyCount = 0;
	private int lastClipIndex = 0;

    private void Start()
    {
        ChangeTrack(0);
        StartCoroutine(Beat());
    }

    private void Update()
	{
		AddClips ();
        ManageBlastClips();
        if(Input.GetKeyDown(KeyCode.Z))
        {
            bodyCount++;
        }
	}

	public void ChangeTrack(int index)
	{
		ResetSources ();
		ambienceSources [lastClipIndex].mute = false;
		SetSources (index);
	}

	private void SetSources(int index)
	{
        usedBpm = allTracks[index].bpm;
		for (int i = 0; i < allTracks[index].ambienceTracks.Length; i++) 
		{
			ambienceSources[i].clip = allTracks [index].ambienceTracks [i];
            ambienceSources[i].Play();
		}
        for (int i = 0; i < allTracks[index].blastTracks.Length; i++)
        {
            blastSources[i].clip = allTracks[index].blastTracks[i];
            blastSources[i].Play();
        }
	}

	private void ResetSources()
	{
		foreach (AudioSource source in ambienceSources)
		{
			source.clip = null;
			source.mute = true;
		}
		foreach (AudioSource source in blastSources)
		{
			source.clip = null;
            source.mute = true;
		}
		lastClipIndex = 0;
	}

	private void AddClips()
	{
		if(bodyCount >= countThreshold)
		{
			lastClipIndex++;
            if(lastClipIndex >= ambienceSources.Length)
            {
                bodyCount = 0;
                return;
            }
			ambienceSources [lastClipIndex].mute = false;
            bodyCount = 0;
		}
	}

    private void ManageBlastClips()
    {
        if (!shootScript.Shoot())
        {
            blastSources[0].mute = true;
            blastSources[1].mute = true;
            blastSources[2].mute = true;
            return;
        }
        if(shootScript.GetCounter() - 1 == 0)
        {
            blastSources[0].mute = false;
            blastSources[1].mute = true;
            blastSources[2].mute = true;
        }
        else if (shootScript.GetCounter() - 1 == 1)
        {
            blastSources[0].mute = true;
            blastSources[1].mute = false;
            blastSources[2].mute = true;
        }
        else if (shootScript.GetCounter() - 1 == 2)
        {
            blastSources[0].mute = true;
            blastSources[1].mute = true;
            blastSources[2].mute = false;
        }
    }

    IEnumerator Beat()
    {
        yield return new WaitForSeconds(60 / usedBpm);
        Debug.Log("beat!");
        beatEvent.Raise();
        StartCoroutine(Beat());
    }

    public void AddBody()
    {
        bodyCount++;
    }

}
