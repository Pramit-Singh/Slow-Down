using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{

    public float MoveSpeed;
    public bool _isTabPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        if (GameManager.instance.Ball == null)
        {
            gameObject.GetComponent<ObstacleMover>().enabled = false;
        }

        if (this.gameObject.transform.position.x < -50)
        {
            gameObject.SetActive(false);
        }


#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            _isTabPressed = true;
        }
        else
        {
            _isTabPressed = false;
        }

#elif UNITY_ANDROID
       if (Input.touchCount > 0)
        {
            _isTabPressed = true;  
        }
        else
        {
            _isTabPressed = false;
        }
#endif
     


     //   if (GameManager.instance._isPaused)
     //   {
     //       gameObject.transform.Translate(new Vector3(0, 0, 0));
     //   }
     //else 
     if (_isTabPressed)
        {
            gameObject.transform.Translate(new Vector3(-MoveSpeed / 2 * Time.deltaTime, 0, 0));
        }
        else
        {
           // gameObject.transform.Translate(new Vector3(-MoveSpeed * Time.deltaTime/2, 0, 0));
            gameObject.transform.Translate(new Vector3(-MoveSpeed * Time.deltaTime, 0, 0));
        }
    }
}

