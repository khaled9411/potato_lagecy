using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class checkpointManager : MonoBehaviour
{
    public List<Transform> checkpoints = new List<Transform>();

    public Transform curranCheckpoint;

    public Transform firstcheckPoint;

    GameObject[] collectables;
    int[] isactive;
    private void Start()
    {
        collectables = GameObject.FindGameObjectsWithTag("Water");
        isactive = new int[collectables.Length];
        for(int i =0; i<collectables.Length; i++)
        {
            if (collectables[i].activeSelf)
            {
                isactive[i] = 1;
            }
            else
            {
                isactive[i] = 0;
            }
        }
    }

    public void save(Transform newCheckPoint)
    {
        curranCheckpoint = newCheckPoint;
        for(int i = 0 ; i<isactive.Length; i++)
        {
            name = "collectable" + i.ToString();
            Debug.Log(collectables[i].activeSelf);
            if (collectables[i].activeSelf)
            {
                isactive[i] = 1;
            }
            else
            {
                isactive[i] = 0;
            }
            PlayerPrefs.SetInt(name, isactive[i]);
        }
    }
    public void load(Transform player)
    {
        if(curranCheckpoint)
            player.position = curranCheckpoint.position;
        else
            player.position = firstcheckPoint.position;
        for (int i = 0; i < isactive.Length; i++)
        {
            name = "collectable" + i.ToString();
            collectables[i].SetActive( PlayerPrefs.GetInt(name,1)==0? false:true);
            Debug.Log(PlayerPrefs.GetInt(name, 1) == 0? false : true);
        }

    }
}
