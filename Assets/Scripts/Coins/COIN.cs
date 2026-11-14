using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class COIN : MonoBehaviour
{
    float minSpeed = 200f;
    float maxSpeed = 260f;

    float rotationSpeed;

    void Start()
    {
        rotationSpeed = Random.Range(minSpeed,maxSpeed);

    }
    private void Update()
    {
        transform.Rotate(0f ,0f, rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


        }
        CoinsManager coins=other.GetComponent<CoinsManager>();  

        if (coins != null )
        {
            coins.addCoin();
            Destroy(gameObject);
        }
    }
}
