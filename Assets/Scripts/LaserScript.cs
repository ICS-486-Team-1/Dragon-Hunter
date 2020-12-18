using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LaserScript : MonoBehaviour {
 	
    public float mFireRate  = .5f;
    public float mFireRange = 50f;
 
    public GameObject explosion;
    public GameObject shoot;
    public GameObject projectile;

    // keep track of score
    public GameObject scoreText;
    public int theScore;
    
    // time to wait for rocket to hit dragon
    private WaitForSeconds mRocketDuration =  new WaitForSeconds(5f);
 
    // time of the until the next fire
    private float mNextFire;

    // laser audio
    public AudioSource laserSound;

    // to control orientation of rocket
    private Quaternion currentRotation;

    public GameObject victoryScreen;

    public AudioSource click;

    // Start is called before the first frame update
    void Start () {
        laserSound = GetComponent<AudioSource>();

        // sets fixed orientation of rocket
        Vector3 newEulerAngles = new Vector3(90,0,0);
        currentRotation.eulerAngles = newEulerAngles;
        transform.rotation = currentRotation;
    }

	// Shot the Laser
    private void Fire(){
        // Get ARCamera Transform
        Transform cam = Camera.main.transform;
 
        // Define the time of the next fire
        mNextFire = Time.time + mFireRate;

        // Set the origin of the RayCast
        Vector3 rayOrigin = cam.position;

        // create rocket, shoot it and wait for death if it does not collide with dragon
        shoot = GameObject.Instantiate(projectile, cam.position - cam.forward, transform.rotation);
        shoot.tag = "Rocket";
        shoot.GetComponent<Rigidbody>().AddForce(cam.forward * 1000);
        LaserSoundTime(0.5f);
        StartCoroutine(DragonWaitAndDestroy());

        // START OF OLD CODE

        // Set the origin position of the Laser Line
        // It will always 10 units down from the ARCamera
        // We adopted this logic for simplicity
        // mLaserLine.SetPosition(0, transform.up * -10f );

	    // // Hold the Hit information
        // RaycastHit hit;
 
        // // Checks if the RayCast hit something
        // if ( Physics.Raycast( rayOrigin, cam.forward, out hit, mFireRange )){
 
        //     // Set the end of the Laser Line to the object hit
        //     // mLaserLine.enabled = true;
        //     // mLaserLine.SetPosition(1, hit.point );

        //     theScore += 1;

        //     LaserSoundTime(0.5f);
        //     Instantiate(explosion, hit.point, transform.rotation);
        //     ExplosionSoundTime(0.25f);
        //     Destroy(hit.transform.gameObject);
        //     GameObject.Destroy(gameObject);
        //     scoreText.GetComponent<Text>().text = "SCORE: " + theScore;
           

        // } else {
        //     // Set the enfo of the laser line to be forward the camera
        //     // using the Laser range
        //     // mLaserLine.enabled = true;
        //     LaserSoundTime(0.5f);
        //     GameObject.Destroy(gameObject);
        //     // mLaserLine.SetPosition(1, cam.forward * mFireRange );
        // }

        // END OF OLD CODE
	}

    // Update is called once per frame
    void Update () {
    }

    public void Shoot() {
        // if (Input.GetButton("Fire1") && Time.time > mNextFire) {
        // 	Fire();  
        // } 
        if (Time.time > mNextFire) {
        	Fire();  
        } 
    }

    // destroy projectile if it did not hit dragon within 5 sec
    private IEnumerator DragonWaitAndDestroy(){
        GameObject temp = shoot;
    	// Way for a specific time to destroy dragon
    	yield return mRocketDuration;
        if (temp != null) {
            Destroy(temp);
        }
    	
    }

    // play laser audio for certain time
    public void LaserSoundTime(float time) {
        laserSound.Play();
        Invoke("StopLaserAudio", time);
    }

    // stop laser audio 
    private void StopLaserAudio() {
        laserSound.Stop();
    }

    IEnumerator VsDelay() {
        yield return new WaitForSeconds(0.25f);
        victoryScreen.SetActive(true);
    }
    // keep track of score, method called in projectile script
    public void UpdateScore() {
        scoreText.GetComponent<Text>().text = "SCORE: " + theScore;
        if (theScore == 10) {
            StartCoroutine(VsDelay());
        }
    }

    // increases score every time dragon is hit by projectle
    public void IncreaseScore() {
        theScore += 1;
    }

    public void PlayClickAudio()
    {
        click.Play();
        Invoke("StopClickAudio", 0.25f);

    }

    public void StopClickAudio() {
        click.Stop();
    }
}