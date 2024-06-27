using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankDamageScript : MonoBehaviour
{
    public List<GameObject> decalsList = new List<GameObject>();
    private HashSet<int> activatedDecals = new HashSet<int>();

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("EnemyProjectile"))
        {
            if (activatedDecals.Count >= decalsList.Count)
            {
                Debug.Log("All of the decals have beed activated!");
                return;
            }

            int randomValue;
            do
            {
                randomValue = Random.Range(0, decalsList.Count);
            } while (activatedDecals.Contains(randomValue));
            
            DecalActication(randomValue);
        }
    }

    public void DecalActication(int randomValue)
    {
        activatedDecals.Add(randomValue);
        decalsList[randomValue].SetActive(true);
        Debug.Log("Decal Activated");
    }

    private void Start()
    {
        foreach(GameObject obj in decalsList)
        {
            obj.SetActive(false);
        }
      
        /*
        for (int i = 0; i < decalsList.Count; i++)
        {
            decalsList[i].SetActive(false);
        }
        */
    }

}
