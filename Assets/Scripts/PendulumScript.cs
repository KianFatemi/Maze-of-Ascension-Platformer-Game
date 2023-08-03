using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PendulumScript : MonoBehaviour
{
    [SerializeField]
    float speed = 1.5f;
    [SerializeField]
    float limit = 75f;
    bool randomStart = true;
    float random = 0;
    [SerializeField]
    float pushForce = 100f;

    private void Awake()
    {
        if(randomStart)
        {
            random = Random.Range(0f, 1f);
        }
    }
    void Update()
    {
        float angle = limit * Mathf.Sin(Time.time + random * speed);
        transform.localRotation = Quaternion.Euler(0f, 90f, angle);
    }

    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Vector3 pushDirection = (collision.transform.position - transform.position).normalized;

            collision.gameObject.GetComponent<Rigidbody>().AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);

        }
    }
}
