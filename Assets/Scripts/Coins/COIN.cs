using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class COIN : MonoBehaviour
{
    
    void Start()
    {
        
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
