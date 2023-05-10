using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController Instance;
    void Awake()
    {
        Instance = this;
    }

    public DamageNumber numberToSpawn;
    [SerializeField] private Transform numberCanvas;
    

    public void SpawnDamage(float damageAmount, Vector3 location)
    {
        int rounded = Mathf.RoundToInt(damageAmount);
        DamageNumber newDamage = Instantiate(numberToSpawn, location, Quaternion.identity, numberCanvas);
        newDamage.Setup(rounded);
        newDamage.gameObject.SetActive(true);


    }
}
