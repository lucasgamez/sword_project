using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float speed = 20.0f;
    public float mapborderX = 70;
    public float mapborderZ = 70;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        this.speed = Random.Range(5.0f, 15.0f);
        isDead = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //If entity is dead, it does not move
        if(!isDead)
        {
            //Moving basics
            float horizontalSpeed = Input.GetAxis("Horizontal");
            float verticalSpeed = Input.GetAxis("Vertical");


            float goalX = player.transform.position.x - transform.position.x;
            float goalZ = player.transform.position.z - transform.position.z;

            if (Mathf.Abs(goalX) < Mathf.Abs(goalZ))
            {
                goalX /= Mathf.Abs(goalZ);
                goalZ /= Mathf.Abs(goalZ);
            }
            else
            {
                goalZ /= Mathf.Abs(goalX);
                goalX /= Mathf.Abs(goalX);
            }



            ImmitatePlayer(goalX, goalZ);
        }

    }

    void ImmitatePlayer(float horizontalSpeed, float verticalSpeed) 
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalSpeed, Space.World);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalSpeed, Space.World);

        //Avoid OUt of Bound
        transform.position = new Vector3(Mathf.Min(Mathf.Max(-mapborderX, transform.position.x), mapborderX), transform.position.y, Mathf.Min(Mathf.Max(-mapborderZ, transform.position.z), mapborderZ));

        //Rotation of character
        if (horizontalSpeed != 0 || verticalSpeed != 0)
        {
            transform.rotation = Quaternion.Euler(0, Mathf.Atan2(horizontalSpeed, verticalSpeed) * 180 / Mathf.PI, 0);
        }
    }
}
