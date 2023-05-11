using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private float lifetime;
    [SerializeField] private float lifetimeCounter;
    [SerializeField] private float floatSpeed;
    
    
    
    void Update()
    {
        LifetimeCondition();
        NumbersMoveCont();
    }

    public void Setup(int damageDisplay)
    {
        lifetimeCounter = lifetime;
        damageText.text = damageDisplay.ToString();
    }

    public void LifetimeCondition()
    {
        if (lifetimeCounter > 0)
        {
            lifetimeCounter -= Time.deltaTime;
            if (lifetimeCounter <= 0)
            {
                //Destroy(gameObject);
                DamageNumberController.Instance.PlacePool(this);
            }
        }
    }

    public void NumbersMoveCont()
    {
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;
    }
}
