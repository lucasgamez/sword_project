using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private bool isDead;
    public float ejectForce = 100;
    public float forceRanfom = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isDead)
            if (other.CompareTag("Player"))
            {
                Debug.Log("Hit!");
                Destroy(gameObject);

            }
            else if (other.CompareTag("Weapon"))
            {
                GetComponent<EnemyController>().isDead = true;
                isDead = true;
                Vector3 playerVector = transform.position - GetComponent<EnemyController>().player.transform.position;
                Debug.Log(playerVector);
                Vector3 forceDirection = new Vector3(playerVector.x * Random.Range(ejectForce * (1 - forceRanfom), ejectForce * (1 + forceRanfom)), Random.Range(2.5f, 3.5f), playerVector.z * Random.Range(ejectForce * (1 - forceRanfom), ejectForce * (1 + forceRanfom)));
                GetComponent<Rigidbody>().AddForce(forceDirection, ForceMode.Impulse);
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-1,1) * ejectForce, Random.Range(-1, 1) * ejectForce, Random.Range(-1, 1) * ejectForce),ForceMode.Impulse);
                //GetComponent<Rigidbody>().AddTorque(new Vector3(500, 0, 0), ForceMode.Impulse);
                Debug.Log(forceDirection);
                Invoke("Die", 2);
            }
        {

        }

    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
