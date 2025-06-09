using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float mainThrust = 1f;
    [SerializeField] float rotateThrust = 1f;
    [SerializeField] AudioClip mainEngineSound;
    [SerializeField] ParticleSystem thrustEffect;
    [SerializeField] ParticleSystem rotationEffect;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProceesInput();
    }




    void ProceesInput()
    {
    
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(0,0,2*mainThrust*Time.deltaTime);
            thrustEffect.Play();
            
            
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngineSound);
            }
        }
        else
        {
            audioSource.Stop();
        }


        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(-rotateThrust);
        }

        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(rotateThrust);
        }
    }

    void ApplyRotation(float rotateThrust)
    {
        rb.freezeRotation = true;
        transform.Rotate(1*rotateThrust*Time.deltaTime,0,0);
        rb.freezeRotation = false;
        rotationEffect.Play();
    }

}
