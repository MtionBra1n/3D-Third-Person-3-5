using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerPositioningBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] positioningPoints;
    [SerializeField] private Transform[] frontPositioningPoints;
    [SerializeField] private Transform[] backPositioningPoints;
    [SerializeField] private Transform[] sitePositioningPoints;
    
    public Transform GetRandomPositioningPoint()
    {
        int index = Random.Range(0, positioningPoints.Length);
        return positioningPoints[index];
    }
    
    
    public Transform GetFrontalPositioningPoint()
    {
        int index = Random.Range(0, frontPositioningPoints.Length);
        return frontPositioningPoints[index];
    }
    
    
    public Transform GetBackPositioningPoint()
    {
        int index = Random.Range(0, backPositioningPoints.Length);
        return backPositioningPoints[index];
    }
    
    
    public Transform GetSitePositioningPoint()
    {
        int index = Random.Range(0, sitePositioningPoints.Length);
        return sitePositioningPoints[index];
    }
    
    // Front, Back, Site Methoden
}
