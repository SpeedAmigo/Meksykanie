using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class explosiveAmmoUI : MonoBehaviour
{
    public TMP_Text count;
    public PlayerProperties playerProperties;

    private void Start()
    {
        count = GetComponent<TMP_Text>();
    }

    public void Update()
    {
        count.SetText(playerProperties.explosivesCount.ToString());
    }
}
