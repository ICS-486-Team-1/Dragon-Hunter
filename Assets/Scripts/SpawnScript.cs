using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use the Vuforia package
using Vuforia;

public class SpawnScript : MonoBehaviour
{

    // Dragon element to spawn
    public GameObject dragonObject;
     
    // Number of Dragons to be Spawned
    public int mTotalDragons = 10;
 
    // Time to spawn the Cubes
    public float mTimeToSpawn = 1f;
 
    // hold all cubes on stage
    private GameObject[] mDragons;
 
    // define if position was set
    private bool mPositionSet;

    void Start () {
        // dragonObject.tag = "Dragon";
        // Initializing spawning loop
        StartCoroutine( SpawnLoop() );
 
        // Initialize Cubes array according to
        // the desired quantity
        mDragons = new GameObject[ mTotalDragons ];
    }

    // We'll use a Coroutine to give a little
    // delay before setting the position
    private IEnumerator ChangePosition() {
 
        yield return new WaitForSeconds(0.2f);
        // Define the Spawn position only once
        if ( !mPositionSet ){
            // change the position only if Vuforia is active
            if ( VuforiaBehaviour.Instance.enabled )
                SetPosition();
        }
    }
    
    // Define the position of the object
    // according to ARCamera position
    private bool SetPosition()
    {
        // get the camera position
        Transform cam = Camera.main.transform;
 
        // set the position 10 units forward from the camera position
        transform.position = cam.forward * 10;
        return true;
    }

    // Loop Spawning dragon elements
    private IEnumerator SpawnLoop() 
    {
        // Defining the Spawning Position
        StartCoroutine( ChangePosition() );
 
        yield return new WaitForSeconds(0.2f);
 
        // Spawning the elements
        int i = 0;
        while ( i <= (mTotalDragons-1) ) {
 
            mDragons[i] = SpawnElement();
            i++;
            yield return new WaitForSeconds(Random.Range(mTimeToSpawn, mTimeToSpawn*3));
        }
    }
 
    // Spawn a dragon
    private GameObject SpawnElement() 
    {
        // spawn the element on a random position, inside a imaginary sphere
        GameObject dragon = Instantiate(dragonObject, (Random.insideUnitSphere*10)+ transform.position, transform.rotation * Quaternion.Euler(180,0,180)) as GameObject;
        // dragon.tag = "Dragon";
        // define a random scale for the cube
        float scale = Random.Range(0.5f, 2f);
        // change the cube scale
        dragon.transform.localScale = new Vector3( scale, scale, scale );
        return dragon;
    } 

}
