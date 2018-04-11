using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManagerComponent : MonoBehaviour 
{
	
	public static DropManagerComponent globalDropManager;
	public Projectile[] lowBlastPool;
	public Projectile[] mediumBlastPool;
	public Projectile[] highBlastPool;

	void Start () 
	{
		globalDropManager = this;
	}


	public static void SpawnDropLow(Vector3 position, float rot_Y)
	{
		for(int i = 0; i < globalDropManager.lowBlastPool.Length; i++)
		{
			if(globalDropManager.lowBlastPool[i].dispo)
			{
				globalDropManager.lowBlastPool[i].transform.position = position;
				globalDropManager.lowBlastPool [i].transform.rotation = Quaternion.Euler (0, rot_Y, 0);
				globalDropManager.lowBlastPool [i].gameObject.SetActive (true);
				globalDropManager.lowBlastPool [i].dispo = false;
				return;
			}
		}
	}
	public static void SpawnDropMedium(Vector3 position, float rot_Y)
	{
		for(int i = 0; i < globalDropManager.lowBlastPool.Length; i++)
		{
			if(globalDropManager.mediumBlastPool[i].dispo)
			{
				globalDropManager.mediumBlastPool[i].transform.position = position;
				globalDropManager.mediumBlastPool [i].transform.rotation = Quaternion.Euler (0, rot_Y, 0);
				globalDropManager.mediumBlastPool [i].gameObject.SetActive (true);
				globalDropManager.mediumBlastPool [i].dispo = false;
				return;
			}
		}
	}
	public static void SpawnDropHigh(Vector3 position, float rot_Y)
	{
		for(int i = 0; i < globalDropManager.lowBlastPool.Length; i++)
		{
			if(globalDropManager.highBlastPool[i].dispo)
			{
				globalDropManager.highBlastPool[i].transform.position = position;
				globalDropManager.highBlastPool [i].transform.rotation = Quaternion.Euler (0, rot_Y, 0);
				globalDropManager.highBlastPool [i].gameObject.SetActive (true);
				globalDropManager.highBlastPool [i].dispo = false;
				return;
			}
		}

	}

	public static void RemoveDrop(Projectile removedDrop)
	{
		removedDrop.gameObject.SetActive (false);
		removedDrop.dispo = true;
	}
}
