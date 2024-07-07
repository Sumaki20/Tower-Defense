using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBuilder : MonoBehaviour
{
    public static TurretBuilder instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public GameObject basicTurret;
    public GameObject basicTurret2;
    public GameObject currentTurret;

    private void Start()
    {
        
    }

    public void OnBasicSelect()
    {
        currentTurret = basicTurret;
    }

    public void OnBasicSelect2()
    {
        currentTurret = basicTurret2;
    }
}
