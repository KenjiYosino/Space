using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlus : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectArrow;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BullletPlusText.ArrowPlus += 50;
            Destroy(gameObjectArrow);
        }
    }
}
