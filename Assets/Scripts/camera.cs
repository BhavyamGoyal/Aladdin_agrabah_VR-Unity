using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal")*30*Time.deltaTime;
        float v = Input.GetAxis("Vertical") * 30* Time.deltaTime;
        gameObject.transform.Rotate(new Vector3(v, h, 0));
    }
}
