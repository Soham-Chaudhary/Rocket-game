using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    AudioSource audioSource;
    [SerializeField] float delaySec = 1f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip finish;

    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] ParticleSystem landingEffect;
    

    bool isTransitioning = false;
    bool collisonDisabled = false;

    void Update() 
    {
        DevSets();    
    }
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }



void DevSets()
{
     if(Input.GetKeyDown(KeyCode.L))
        {
            LoadSceneSquence();
        }

    if(Input.GetKeyDown(KeyCode.C))
    {
        collisonDisabled = !collisonDisabled;
    }
}

    void OnCollisionEnter(Collision other)  
    {
       
        if(isTransitioning || collisonDisabled){ return; }
        
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Happy");
                break;

            case "Danger":
                ReloadSceneSquence();
                
                break;

            case "Finish":
                LoadSceneSquence();
                
                
                break;

            default:
                ReloadSceneSquence();                                                                                       
                break;
        }
    }

    void LoadSceneSquence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        Invoke("LoadScene",delaySec);
        landingEffect.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(finish);
    }

    void ReloadSceneSquence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene",delaySec);
        audioSource.Stop();
        crashEffect.Play();
        audioSource.PlayOneShot(crash);
    }

    

    void LoadScene()
    {
       
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }


    void ReloadScene ()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
