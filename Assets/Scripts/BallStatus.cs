using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallStatus : MonoBehaviour
{
    string ballName;
    private void OnEnable()
    {
        ballName = gameObject.name;
       // PlayerPrefs.DeleteKey(ballName);
      
        if (PlayerPrefs.HasKey(ballName) && PlayerPrefs.GetInt(ballName) == 1)
        {
            gameObject.GetComponent<Image>().sprite = null;
            gameObject.transform.GetChild(0).transform.gameObject.SetActive(true);
        }
    }
    void Update()
    {
        if (!PlayerPrefs.HasKey(ballName) && gameObject.GetComponent<Image>().sprite == null)
        {
            PlayerPrefs.SetInt(ballName, 1);
        }
        
      
    }
}
