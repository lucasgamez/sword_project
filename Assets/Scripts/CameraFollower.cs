using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject character;
    public float speed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 distV = character.transform.position - transform.position;
        //distV.z += -1.81f;
        distV.y = 0;// transform.position.y;
        transform.Translate(distV * Time.deltaTime * speed, Space.World);
        
    }
}
