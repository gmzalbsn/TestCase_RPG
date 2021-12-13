using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicHero : MonoBehaviour
{
    
    public  string Name;
    public  HeroStats heroStats = new HeroStats { healthPoints = 100, attackPoints = 10 };
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    public void InitializeMeshComponent()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    public void SetMesh(Mesh newMesh)
    {
        meshFilter.mesh = newMesh;
    }
    public void SetMaterial(Material newMaterial)
    {
        meshRenderer.material = newMaterial;
    }

}
