using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankDamageScript : MonoBehaviour
{
    public List<GameObject> decalsList = new List<GameObject>();
    private HashSet<int> activatedDecals = new HashSet<int>();
    private List<int> activeDecalsList = new List<int>();

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
        activeDecalsList.Add(randomValue);
        decalsList[randomValue].SetActive(true);
        Debug.Log("Decal Activated");
    }

    public void DecalDeActivation()
    {
        if (activeDecalsList.Count == 0)
        {
            Debug.Log("No active decals to deactivate.");
            return;
        }

        int randomIndex = Random.Range(0, activeDecalsList.Count);
        int decalToDeactivate = activeDecalsList[randomIndex];

        decalsList[decalToDeactivate].SetActive(false);
        activeDecalsList.RemoveAt(randomIndex);
        activatedDecals.Remove(decalToDeactivate);
        Debug.Log("Decal Deactivated: " + decalToDeactivate);
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
