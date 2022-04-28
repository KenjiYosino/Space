using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAlien : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectGob;
    
    private void DestroAlien()
    {
        ScoreManager.score += 1;
        Destroy(gameObjectGob);
    }
}
