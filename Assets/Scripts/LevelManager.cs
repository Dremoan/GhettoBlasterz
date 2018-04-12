using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [Header("Events")]
    public GameEvent enterJazz;
    public GameEvent finishJazz;
    public GameEvent finishRap;
    public GameEvent finishElectro;

    [Header("Paramètres des salles")]
    public int jazzBodyNumber = 30;
    public int rapBodyNumber = 30;
    public int electroBodyNumber = 30;

    [Header("Spawners")]
    public Transform[] jazzSpawners;
    public Transform[] rapSpawners;
    public Transform[] elecSpawners;

    private int currentRoomIndex;
    private int usedBodyNumber;
    private int currentBodyNumber;
    private bool inFight = false;

    // Use this for initialization
    void Start () {
        enterJazz.Raise();
        SetJazzSettings();
        inFight = true;
	}

    private void Update()
    {
        UpdateRoomSetting();
    }

    public void UpdateRoomSetting()
    {
        if(currentBodyNumber >= usedBodyNumber)
        {
            if(currentRoomIndex == 1)
            {
                finishJazz.Raise();
                inFight = false;
                currentBodyNumber = 0;
            }else if(currentRoomIndex == 2)
            {
                finishRap.Raise();
                inFight = false;
                currentBodyNumber = 0;
            }
            else if(currentRoomIndex == 3)
            {
                finishElectro.Raise();
                inFight = false;
                currentBodyNumber = 0;
            }
        }
    }

    public void SetJazzSettings()
    {
        currentRoomIndex = 1;
        usedBodyNumber = jazzBodyNumber;
        currentBodyNumber = 0;
        inFight = true;
    }

    public void SetRapSettings()
    {
        currentRoomIndex = 2;
        usedBodyNumber = rapBodyNumber;
        currentBodyNumber = 0;
        inFight = true;
    }

    public void SetElecSettings()
    {
        currentRoomIndex = 3;
        usedBodyNumber = electroBodyNumber;
        currentBodyNumber = 0;
        inFight = true;
    }

    public void Addbody()
    {
        currentBodyNumber += 1;
        Debug.Log("killed");
    }

    public void SpawnEnemy()
    {
        if (!inFight)
            return;
        if(currentRoomIndex == 1)
        {
            int c = Random.Range(0, jazzSpawners.Length);
            DropManagerComponent.SpawnJazz(jazzSpawners[c].position);
        }else if(currentRoomIndex == 2)
        {
            int c = Random.Range(0, rapSpawners.Length);
            DropManagerComponent.SpawnJazz(rapSpawners[c].position);
        }
        else if(currentRoomIndex == 3)
        {
            int c = Random.Range(0, rapSpawners.Length);
            DropManagerComponent.SpawnJazz(rapSpawners[c].position);
        }
    }
}
