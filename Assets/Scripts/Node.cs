using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Renderer rend;
    public GameObject myTurret;
    
    private Color originColor;

    public Color hoverColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        originColor = rend.material.GetColor("_BaseColor");
    }
    private void OnMouseEnter()
    {
        if(rend != null )
        {
            rend.material.SetColor("_BaseColor", hoverColor);
        }
    }
    private void OnMouseExit()
    {
        if (rend != null)
        {
            rend.material.SetColor("_BaseColor", originColor);
        }
    }

    private void OnMouseDown()
    {
        if (myTurret != null)
        {
            //TODO Show PopUp Connot build here

            return;
        }
        else
        {
            if(TurretBuilder.instance.currentTurret == null)
            {
                Debug.Log("No Turret to Build");
                return;
            }
            //TODO Create Turret to node
            myTurret = Instantiate(TurretBuilder.instance.currentTurret, transform);
            myTurret.transform.localPosition = Vector3.zero;
            myTurret.transform.localScale = new Vector3(1f, 10f, 1f);

            TurretBuilder.instance.currentTurret = null;
        }
    }
}
