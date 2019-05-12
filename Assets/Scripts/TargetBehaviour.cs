using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public int Health = 3;
    public AudioClip destroyedClip;
    
    public float rotateSpeed = 0f;

    private AudioSource audioSource;
    private Collider myCollider;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        myCollider = GetComponent<Collider>();
    }

    private void Update() {
        if(rotateSpeed != 0f)
            transform.RotateAround(Vector3.zero, Vector3.up, 30f * Time.deltaTime);
    }

    public void Shot() {
        Health -= 1;
        if(Health <= 0) {
            Destroyed();
        }
    }

    public void Destroyed() {
        myCollider.enabled = false;

        audioSource.Stop();
        audioSource.PlayOneShot(destroyedClip);
        Invoke("SelfDestroy", destroyedClip.length);
    }

    public void SelfDestroy() {
        GameManager.Instance.TargetDestroyed();
        Destroy(gameObject);
    }
}
