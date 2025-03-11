using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
using System.Collections.Generic;
using System.Linq;

public class Gun_UI : MonoBehaviour
{
    [SerializeField] private GunData gunData;
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text ammo;
    
    private List<char> symbolsList = new List<char>(){'#', '@', '!', '$', '%', '&', 'n', '?'};
    private List<char> symbolsList_1 = new List<char>(){'?', '$', '<', '[', ')', '-', 'c', '>'};

void Update()
    {
        name.text = gunData.name;
        if (gunData.reloading)
        {
            StartCoroutine(customReaload());
        }
        else
        {
            ammo.text = gunData.currentAmmo.ToString() + "/" + gunData.bonusAmmo;
        }
    }

    private IEnumerator customReaload()
    {
        if (gunData.currentAmmo != 32)
        {
            while (true)
            {
                int output = new Random().Next(0, symbolsList.Count);
                int output_1 = new Random().Next(0, symbolsList_1.Count);
                ammo.text = symbolsList.ElementAt(output).ToString() + "/" + symbolsList_1.ElementAt(output).ToString();
                yield return new WaitForSeconds(gunData.reloadTime);
                ammo.text = gunData.currentAmmo.ToString() + "/" + gunData.bonusAmmo;
                break;
            }
        }
        else
        {
            ammo.text = gunData.currentAmmo.ToString() + "/" + gunData.bonusAmmo;
        }
    }
}
