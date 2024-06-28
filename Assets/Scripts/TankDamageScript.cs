using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankDamageScript : MonoBehaviour
{
    public List<GameObject> decalsList = new List<GameObject>();
    public List<int> activeDecalsList = new List<int>();
    private HashSet<int> activatedDecals = new HashSet<int>();
    [SerializeField] private SlayMeterUI slayMeterUI;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("EnemyProjectile"))
        {
            if (activatedDecals.Count >= decalsList.Count)
            {
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
        //Debug.Log("Decal Activated");

        int active = activeDecalsList.Count;
        slayMeterUI.SlayMeterSlider(active);
    }

    public void DecalDeActivation()
    {
        if (activeDecalsList.Count == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, activeDecalsList.Count);
        int decalToDeactivate = activeDecalsList[randomIndex];

        decalsList[decalToDeactivate].SetActive(false);
        activeDecalsList.RemoveAt(randomIndex);
        activatedDecals.Remove(decalToDeactivate);

        int active = activeDecalsList.Count;
        slayMeterUI.SlayMeterSlider(active);
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

    private void Update()
    {
        int active = activeDecalsList.Count;
    }

}
