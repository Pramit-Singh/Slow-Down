using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveStar : MonoBehaviour
{

    public GameObject[] star;

    void OnEnable()
    {

        //foreach (GameObject g in star)
        //{
        //    g.SetActive(true);
        //}
        for (int i = 0; i< 2; i++)
        {
        star[Random.Range(0, star.Length - 1)].SetActive(true);
        }
    }

    void OnDisable()
    {
        foreach (GameObject g in star)
        {
            g.SetActive(false);
        }
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
