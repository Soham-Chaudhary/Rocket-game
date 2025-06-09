using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDK : MonoBehaviour
{
  [SerializeField]Vector3 startingPos;
  [SerializeField] Vector3 movementVector;
  [SerializeField] [Range(0,1)] float movementFactor;

  [SerializeField] float period = 2f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(period == 0){ return;}
      //transform.Rotate(1f,0,0);  
      float cycle = Time.time/period;
      const float tau = Mathf.PI*2;
      float rawSinWave = Mathf.Sin(cycle*tau);
      movementFactor = (rawSinWave + 1f)/2f;
      Vector3 offset = movementFactor*movementVector;
      transform.position=(startingPos + offset);

      
    }
}
