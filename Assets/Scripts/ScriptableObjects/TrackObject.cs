using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TrackObject : ScriptableObject 
{
	public float bpm;
	public AudioClip[] ambienceTracks;
	public AudioClip[] blastTracks = new AudioClip[3];

}
