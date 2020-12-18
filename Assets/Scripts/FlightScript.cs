using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightScript : MonoBehaviour
{
    // Dragon's Max/Min scale
    public float mScaleMax  = 2f;
    public float mScaleMin  = 0.5f;
 
    // Orbit max Speed
    public float mOrbitMaxSpeed = 30f;
 
    // Orbit speed
    private float mOrbitSpeed;
 
    // Anchor point for the Dragon to rotate around
    private Transform mOrbitAnchor;
 
    // Orbit direction
    private Vector3 mOrbitDirection;
 
    // Max Dragon Scale
    private Vector3 mDragonMaxScale;
     
    // Growing Speed
    public float mGrowingSpeed  = 10f;
    private bool mIsDragonScaled  = false;

    private AudioSource flapping;
    public bool stopFlapping;

    void Start () {
        flapping = GetComponent<AudioSource>();
        stopFlapping = false;
        DragonSettings();
    }
 
    // Set initial dragon settings
    private void DragonSettings(){
        // defining the anchor point as the main camera
        mOrbitAnchor = Camera.main.transform;
 
        // defining the orbit direction
        float x = Random.Range(-1f,1f);
        float y = Random.Range(-1f,1f);
        float z = Random.Range(-1f,1f);
        mOrbitDirection = new Vector3( x, y , z );
 
        // defining speed
        mOrbitSpeed = Random.Range( 10f, mOrbitMaxSpeed );
 
        // defining scale
        float scale = Random.Range(mScaleMin, mScaleMax);
        mDragonMaxScale = new Vector3( scale, scale, scale );
 
        // set dragon scale to 0, to grow it lates
        transform.localScale = Vector3.zero;

        // AudioSource.PlayClipAtPoint(flapping.clip, transform.position);
        flapping.Play();
        flapping.loop = true;
    }

    // Update is called once per frame
    void Update () {
        // makes the dragon orbit and rotate
        RotateDragon();

        if (stopFlapping == true) {
            flapping.loop = false;
            flapping.Stop();
        }
        // else {
        //     if (!flapping.isPlaying) {
        //         flapping.Play();
        //     }
        // }
        // if (stopFlapping == false || !flapping.isPlaying) {
        //     flapping.Play();
        //     // AudioSource.PlayClipAtPoint(flapping.clip, transform.position);
        //     // flapping.loop = false;
        //     // flapping.Stop();
        // }
        
        
        // scale dragon if needed
        if ( !mIsDragonScaled )
            ScaleObj();
    }
 
    // Makes the dragon rotate around a anchor point
    // and rotate around its own axis
    private void RotateDragon(){
        // rotate dragon around camera
        transform.RotateAround(
            mOrbitAnchor.position, mOrbitDirection, mOrbitSpeed * Time.deltaTime);
 
        // rotating around its axis
        transform.Rotate( mOrbitDirection * 30 * Time.deltaTime);
    }

    // Scale object from 0 to 1
    private void ScaleObj(){
        // growing obj
        if ( transform.localScale != mDragonMaxScale )
            transform.localScale = Vector3.Lerp( transform.localScale, mDragonMaxScale, Time.deltaTime * mGrowingSpeed );
        else
            mIsDragonScaled = true;
    }
}
