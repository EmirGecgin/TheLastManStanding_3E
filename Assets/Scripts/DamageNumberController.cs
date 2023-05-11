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
    private List<DamageNumber> _numberPool = new List<DamageNumber>();


    public void SpawnDamage(float damageAmount, Vector3 location)
    {
        int rounded = Mathf.RoundToInt(damageAmount);
        //DamageNumber newDamage = Instantiate(numberToSpawn, location, Quaternion.identity, numberCanvas);
        DamageNumber newDamage = GetFromPool();
        newDamage.Setup(rounded);
        newDamage.gameObject.SetActive(true);
        newDamage.transform.position = location;
    }

    public DamageNumber GetFromPool()
    {
        DamageNumber numberToOutput = null;
        if (_numberPool.Count == 0)
        {
            numberToOutput = Instantiate(numberToSpawn, numberCanvas);
        }
        else
        {
            numberToOutput = _numberPool[0];
            _numberPool.RemoveAt(0);
        }

        return numberToOutput;
    }

    public void PlacePool(DamageNumber numberToPlace)
    {
        numberToPlace.gameObject.SetActive(false);
        _numberPool.Add(numberToPlace);
    }
    
}
