using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManagerComponent : MonoBehaviour 
{
	
	public static DropManagerComponent globalDropManager;
	public Projectile[] lowBlastPool;
	public Projectile[] mediumBlastPool;
	public Projectile[] highBlastPool;
    public EnemyProjectile[] JazzProjectilePool;
    public EnemyProjectile[] RapProjectilePool;
    public EnemyProjectile[] ElecProjectilePool;
    public Enemy_Moving_Component[] JazzPool;
    public Enemy_Moving_Component[] RapPool;
    public Enemy_Moving_Component[] ElecPool;
    public GameEvent enemydied;



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
        removedDrop.projectileBody.velocity = Vector3.zero;
		removedDrop.gameObject.SetActive (false);
		removedDrop.dispo = true;
	}

    public static void SpawnJazzEnemyProjectile(Vector3 position, float rot_Y)
    {
        for (int i = 0; i < globalDropManager.JazzProjectilePool.Length; i++)
        {
            if (globalDropManager.JazzProjectilePool[i].dispo)
            {
                globalDropManager.JazzProjectilePool[i].transform.position = position;
                globalDropManager.JazzProjectilePool[i].transform.rotation = Quaternion.Euler(0, rot_Y, 0);
                globalDropManager.JazzProjectilePool[i].gameObject.SetActive(true);
                globalDropManager.JazzProjectilePool[i].dispo = false;
                return;
            }
        }
    }

    public static void SpawnRapEnemyProjectile(Vector3 position, float rot_Y)
    {
        for (int i = 0; i < globalDropManager.RapProjectilePool.Length; i++)
        {
            if (globalDropManager.RapProjectilePool[i].dispo)
            {
                globalDropManager.RapProjectilePool[i].transform.position = position;
                globalDropManager.RapProjectilePool[i].transform.rotation = Quaternion.Euler(0, rot_Y, 0);
                globalDropManager.RapProjectilePool[i].gameObject.SetActive(true);
                globalDropManager.RapProjectilePool[i].dispo = false;
                return;
            }
        }
    }

    public static void SpawnElecEnemyProjectile(Vector3 position, float rot_Y)
    {
        for (int i = 0; i < globalDropManager.ElecProjectilePool.Length; i++)
        {
            if (globalDropManager.ElecProjectilePool[i].dispo)
            {
                globalDropManager.ElecProjectilePool[i].transform.position = position;
                globalDropManager.ElecProjectilePool[i].transform.rotation = Quaternion.Euler(0, rot_Y, 0);
                globalDropManager.ElecProjectilePool[i].gameObject.SetActive(true);
                globalDropManager.ElecProjectilePool[i].dispo = false;
                return;
            }
        }
    }

    public static void SpawnJazz(Vector3 position)
    {
        for (int i = 0; i < globalDropManager.JazzPool.Length; i++)
        {
            if (globalDropManager.JazzPool[i].dispo)
            {
                globalDropManager.JazzPool[i].transform.position = position;
                globalDropManager.JazzPool[i].gameObject.SetActive(true);
                globalDropManager.JazzPool[i].dispo = false;
                return;
            }
        }
    }

    public static void SpawnRap(Vector3 position)
    {
        for (int i = 0; i < globalDropManager.RapPool.Length; i++)
        {
            if (globalDropManager.RapPool[i].dispo)
            {
                globalDropManager.RapPool[i].transform.position = position;
                globalDropManager.RapPool[i].gameObject.SetActive(true);
                globalDropManager.RapPool[i].dispo = false;
                return;
            }
        }
    }

    public static void SpawnElec(Vector3 position)
    {
        for (int i = 0; i < globalDropManager.ElecPool.Length; i++)
        {
            if (globalDropManager.ElecPool[i].dispo)
            {
                globalDropManager.ElecPool[i].transform.position = position;
                globalDropManager.ElecPool[i].gameObject.SetActive(true);
                globalDropManager.ElecPool[i].dispo = false;
                return;
            }
        }
    }

    public static void RemoveEnemy(Enemy_Moving_Component removedEnemy)
    {
        removedEnemy.gameObject.SetActive(false);
        removedEnemy.dispo = true;
        globalDropManager.enemydied.Raise();
    }
}
