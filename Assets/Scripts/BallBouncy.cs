using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]
public class BallBouncy : MonoBehaviour
{
    private bool firstTimeVelocitySave = false;
    private Vector3 savedVelocity;
    public float rotate;
    // public float BounceRate = 1f;
    // int lastPos=200;
    
    void Start()
    {

    }
    void Update()
    {
        gameObject.transform.Rotate(0, 0, rotate);

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            GameManager.instance.destroyParticleSystem.transform.position = gameObject.transform.position;
            GameManager.instance.destroyParticleSystem.SetActive(true);
            GameManager.instance.GameOver();
            Destroy(gameObject);
            Handheld.Vibrate();
            
                    PlayerPrefs.SetInt("StarNumbers", ScoreManager.starCount);
                foreach (Text t in ScoreManager.instance.starText)
                {
                    ScoreManager.starCount = PlayerPrefs.GetInt("StarNumbers");
                    t.text = ScoreManager.starCount.ToString();
                }
            
        }
        if (!firstTimeVelocitySave)
        {
            savedVelocity = gameObject.GetComponent<Rigidbody>().velocity;
            firstTimeVelocitySave = true;
        }
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, savedVelocity.y, 0);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Star")
        {
            Handheld.Vibrate();

            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
            ScoreManager.starCount += 1;
           // print(ScoreManager.starCount);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "GeneratePath")
        {
            GameObject Path = ObjectPooling.instance.GetPooledObject();
            if (Path != null)
            {
                Path.transform.position = new Vector3(48, 0, 0);
                Path.SetActive(true);
            }
        }
        if (other.tag == "ObstacleGenerate")
        {

            GameObject Obs = ObstaclesGenerate.instance.GetPooledObject();
            if (Obs != null)
            {
                Obs.transform.position = new Vector3(50, 0, 0);
                Obs.SetActive(true);
            }
        }

        if (other.tag == "Score")
        {
            ScoreManager.instance.ScoreUpdate();
        }
    }
}

