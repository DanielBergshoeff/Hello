using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float timePerShot = 1.0f;

    private bool laserOn;

    private float laserTimeOn = 0f;

    private TargetBehaviour target;

    public bool LaserOn {
        get {
            return laserOn;
        }
        set {
            if(value && !laserOn) {
                SoundManager.Instance.PlayLaserOnSound();
            }
            else if(!value && laserOn) {
                laserTimeOn = 0f;
                SoundManager.Instance.PlayLaserOffSound();
            }
            laserOn = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            transform.Rotate(new Vector3(0f, -1.0f, 0f));
        }
        else {
            transform.Rotate(new Vector3(0f, 1.0f, 0f));
        }

        RaycastHit hit;
        bool checkHit = false;
        if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, 10.0f)){
            if (hit.transform.CompareTag("Target")) {
                checkHit = true;
                target = hit.collider.GetComponent<TargetBehaviour>();
            }
        }
        LaserOn = checkHit;

        if (LaserOn) {
            laserTimeOn += Time.deltaTime;
            if(laserTimeOn >= timePerShot) {
                laserTimeOn = 0f;
                SoundManager.Instance.PlayLaserShot();
                target.Shot();
            }
        }

    }

    private void Shoot() {

    }
}
