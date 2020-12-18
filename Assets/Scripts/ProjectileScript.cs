using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileScript : MonoBehaviour
{

    public GameObject explosion;
    public AudioClip exSound;
    public LaserScript ls;
    private FlightScript fs;
    private bool alreadyCollided;

    // Start is called before the first frame update
    void Start()
    {
        // do nothing
    }

    // Update is called once per frame
    void Update()
    {
        ls.UpdateScore();
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Dragon" && gameObject.tag == "Rocket" && !alreadyCollided) {
            fs = col.gameObject.GetComponent<FlightScript>();
            fs.stopFlapping = true;
            
            alreadyCollided = true;

            GameObject.Destroy(col.gameObject, 0.15f);
            GameObject.Destroy(gameObject, 0.15f);

            AudioSource.PlayClipAtPoint(exSound, transform.position);
            Instantiate(explosion, transform.position, transform.rotation);

            ls.IncreaseScore();
        }
    }
}
