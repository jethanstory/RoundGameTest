using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickeringLamps : MonoBehaviour
{

    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;

    public Transform fpsTarget;

    public Transform fpsTarget2;

    public Transform fpsTarget3;
    public bool isFlickering;
    public int FlickerMode;
    public float FlickerTime;

    public GameObject lightSource;

    public Light light;


    
    public float RandomIntensity;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if (fpsTargetDistance < enemyLookDistance) {
            isFlickering = true;
            StartCoroutine(FlickerLight());
        }

    }


    IEnumerator FlickerLight()
    {
        if (FlickerMode == 1)
        {
            //this.gameObject.GetComponent<Light>().enabled = false;
            lightSource.SetActive(false);
            FlickerTime = Random.Range(0f, 0.26f);
            RandomIntensity = Random.Range(0f, 3.1f);
            light.intensity = RandomIntensity;
            FlickerTime = Random.Range(0f, 0.05f);
            yield return new WaitForSeconds(FlickerTime);
            RandomIntensity = Random.Range(0f, 3.1f);
            light.intensity = RandomIntensity;
            lightSource.SetActive(true);
            //this.gameObject.GetComponent<Light>().enabled = true;
            isFlickering = false;
        }
    }
}
