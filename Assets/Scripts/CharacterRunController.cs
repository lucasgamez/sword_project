using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRunController : MonoBehaviour
{
    public float speed = 20;
    public float mapborderX = 70;
    public float mapborderZ = 70;
    public float manualDeadZone = 1f;
    public GameObject sword;
    public float max = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moving basics
        float horizontalSpeed = Input.GetAxis("Horizontal");
        float verticalSpeed = Input.GetAxis("Vertical");
        if (horizontalSpeed > max)
        {
            max = horizontalSpeed;

        }
        Debug.Log(max);

        if (Mathf.Abs(verticalSpeed)< manualDeadZone && Mathf.Abs(horizontalSpeed) < manualDeadZone)
        {
            horizontalSpeed = 0;
            verticalSpeed = 0;
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalSpeed, Space.World);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalSpeed, Space.World);

        //Avoid OUt of Bound
        transform.position = new Vector3(Mathf.Min(Mathf.Max(-mapborderX, transform.position.x), mapborderX), transform.position.y, Mathf.Min(Mathf.Max(-mapborderZ, transform.position.z), mapborderZ));

        //Rotation of character
        if (horizontalSpeed != 0 || verticalSpeed != 0)
        {
            transform.rotation = Quaternion.Euler(0, Mathf.Atan2(horizontalSpeed, verticalSpeed) * 180 / Mathf.PI, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            
            GameObject s = Instantiate(sword, transform.TransformPoint(new Vector3(-2.0f, 0.1f, 0f)), transform.rotation);
            s.transform.parent = gameObject.transform;
        }
        
    }
}
