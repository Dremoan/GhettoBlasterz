using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour 
{
	public TrackObject[] allTracks;
	public AudioSource[] ambienceSources;
	public AudioSource[] blastSources;
	public ShootScript shootScript;
	public int countThreshold = 10;
	public float usedBpm = 0;
	private int bodyCount = 0;
	private int lastClipIndex = 0;

	private void Update()
	{
		AddClips ();
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
		}
		lastClipIndex = 0;
	}

	private void AddClips()
	{
		if(bodyCount >= countThreshold)
		{
			lastClipIndex++;
			ambienceSources [lastClipIndex].mute = false;
		}
	}

}
