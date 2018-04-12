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
    public Enemy_Moving_Component[] JazzSniperPool;
    public Enemy_Moving_Component[] JazzShielderPool;
    public Enemy_Moving_Component[] JazzWarriorPool;
    public Enemy_Moving_Component[] RapSniperPool;
    public Enemy_Moving_Component[] RapShielderPool;
    public Enemy_Moving_Component[] RapWarriorPool;
    public Enemy_Moving_Component[] ElecSniperPool;
    public Enemy_Moving_Component[] ElecShielderPool;
    public Enemy_Moving_Component[] ElecWarriorPool;



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

    public static void SpawnJazzSniper(Vector3 position)
    {
        for (int i = 0; i < globalDropManager.JazzSniperPool.Length; i++)
        {
            if (globalDropManager.JazzSniperPool[i].dispo)
            {
                globalDropManager.JazzSniperPool[i].transform.position = position;
                globalDropManager.JazzSniperPool[i].gameObject.SetActive(true);
                globalDropManager.JazzSniperPool[i].dispo = false;
                return;
            }
        }
    }

    public static void SpawnJazzShielder(Vector3 position)
    {
        for (int i = 0; i < globalDropManager.JazzShielderPool.Length; i++)
        {
            if (globalDropManager.JazzShielderPool[i].dispo)
            {
                globalDropManager.JazzShielderPool[i].transform.position = position;
                globalDropManager.JazzShielderPool[i].gameObject.SetActive(true);
                globalDropManager.JazzShielderPool[i].dispo = false;
                return;
            }
        }
    }

    public static void SpawnJazzWarrior(Vector3 position)
    {
        for (int i = 0; i < globalDropManager.JazzWarriorPool.Length; i++)
        {
            if (globalDropManager.JazzWarriorPool[i].dispo)
            {
                globalDropManager.JazzWarriorPool[i].transform.position = position;
                globalDropManager.JazzWarriorPool[i].gameObject.SetActive(true);
                globalDropManager.JazzWarriorPool[i].dispo = false;
                return;
            }
        }
    }

    public static void SpawnRapSniper(Vector3 position)
    {
        for (int i = 0; i < globalDropManager.RapSniperPool.Length; i++)
        {
            if (globalDropManager.RapSniperPool[i].dispo)
            {
                globalDropManager.RapSniperPool[i].transform.position = position;
                globalDropManager.RapSniperPool[i].gameObject.SetActive(true);
                globalDropManager.RapSniperPool[i].dispo = false;
                return;
            }
        }
    }

    public static void SpawnRapShielder(Vector3 position)
    {
        for (int i = 0; i < globalDropManager.RapShielderPool.Length; i++)
        {
            if (globalDropManager.RapShielderPool[i].dispo)
            {
                globalDropManager.RapShielderPool[i].transform.position = position;
                globalDropManager.RapShielderPool[i].gameObject.SetActive(true);
                globalDropManager.RapShielderPool[i].dispo = false;
                return;
            }
        }
    }

    public static void SpawnRapWarrior(Vector3 position)
    {
        for (int i = 0; i < globalDropManager.RapWarriorPool.Length; i++)
        {
            if (globalDropManager.RapWarriorPool[i].dispo)
            {
                globalDropManager.RapWarriorPool[i].transform.position = position;
                globalDropManager.RapWarriorPool[i].gameObject.SetActive(true);
                globalDropManager.RapWarriorPool[i].dispo = false;
                return;
            }
        }
    }

    public static void SpawnElecSniper(Vector3 position)
    {
        for (int i = 0; i < globalDropManager.ElecSniperPool.Length; i++)
        {
            if (globalDropManager.ElecSniperPool[i].dispo)
            {
                globalDropManager.ElecSniperPool[i].transform.position = position;
                globalDropManager.ElecSniperPool[i].gameObject.SetActive(true);
                globalDropManager.ElecSniperPool[i].dispo = false;
                return;
            }
        }
    }

    public static void SpawnElecShielder(Vector3 position)
    {
        for (int i = 0; i < globalDropManager.ElecShielderPool.Length; i++)
        {
            if (globalDropManager.ElecShielderPool[i].dispo)
            {
                globalDropManager.ElecShielderPool[i].transform.position = position;
                globalDropManager.ElecShielderPool[i].gameObject.SetActive(true);
                globalDropManager.ElecShielderPool[i].dispo = false;
                return;
            }
        }
    }

    public static void SpawnElecWarrior(Vector3 position)
    {
        for (int i = 0; i < globalDropManager.ElecWarriorPool.Length; i++)
        {
            if (globalDropManager.ElecWarriorPool[i].dispo)
            {
                globalDropManager.ElecWarriorPool[i].transform.position = position;
                globalDropManager.ElecWarriorPool[i].gameObject.SetActive(true);
                globalDropManager.ElecWarriorPool[i].dispo = false;
                return;
            }
        }
    }

    public static void RemoveEnemy(Enemy_Moving_Component removedEnemy)
    {
        removedEnemy.gameObject.SetActive(false);
        removedEnemy.dispo = true;
    }
}
