using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.EventSystems;

/**
 * Used in collection missions
 */
public class Selection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Material hoverMaterial;
    private Material[] originalMaterials;
    private Renderer[] childRenderers;

    void Start()
    {
        childRenderers = GetComponentsInChildren<Renderer>();
        originalMaterials = new Material[childRenderers.Length];
        for (int i = 0; i < childRenderers.Length; i++)
        {
            originalMaterials[i] = childRenderers[i].material;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (Renderer rend in childRenderers)
        {
            rend.material = hoverMaterial;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        for (int i = 0; i < childRenderers.Length; i++)
        {
            childRenderers[i].material = originalMaterials[i];
        }
    }


}