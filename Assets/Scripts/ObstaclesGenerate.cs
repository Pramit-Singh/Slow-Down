using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerate : MonoBehaviour
{
    public static ObstaclesGenerate instance;


    public List<GameObject> ObstacleObjects;
    List<int> falseObjectList;
    public GameObject[] Obs;
    
    public static int x;
    public int StartPos;
    public int lastPos;

    int g;
    // Start is called before the first frame update
    void OnEnable()
    {
        instance = this;
        ObstacleObjects = new List<GameObject>();
        falseObjectList = new List<int>();
       // int x = 20;


        for (int i = 0; i < Obs.Length; i++)
        {
           // GameObject obj = (GameObject)Instantiate(Obs[i]);
            GameObject obj = (GameObject)Instantiate(Obs[Random.Range(0, Obs.Length)]);
            //GameObject obj = (GameObject)Instantiate(Obs[i]);
            //x = x + StartPos;
            //if (i == Obs.Length - 1)
            //{
            //lastPos = x;
            //}
           // obj.transform.position = new Vector3(x, 0, 0);
            obj.SetActive(false);
            ObstacleObjects.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPooledObject()
    {
        falseObjectList.Clear();
        
        for (int i = 0; i < ObstacleObjects.Count; i++)
        {

            if (!ObstacleObjects[i].activeInHierarchy)
            {
                falseObjectList.Add(i);
                g = falseObjectList[Random.Range(0,falseObjectList.Count)];
               // return ObstacleObjects[g];
            }
        }
        for (int i = 0; i < ObstacleObjects.Count; i++)
        {

            if (!ObstacleObjects[i].activeInHierarchy)
            {
                return ObstacleObjects[g];
            }
        }
        return null;
    }
}
