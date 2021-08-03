using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _sizeView;
    [SerializeField] private Tower _tower;

    private void OnEnable()
    {
        _tower.OnViewSizeUpdate += OnSizeUpdated;
    }

    private void OnDisable()
    {
        _tower.OnViewSizeUpdate -= OnSizeUpdated;
    }

    private void OnSizeUpdated(int size)
    {
        _sizeView.text = size.ToString();
    }
}
