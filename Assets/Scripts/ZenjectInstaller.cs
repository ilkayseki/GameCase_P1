using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    [SerializeField] private GameObject cellPrefab;
    public override void InstallBindings()
    {
        Container.Bind<GridManager>().FromComponentInHierarchy().AsSingle();
        Container.BindFactory<Cell, Cell.Factory>().FromComponentInNewPrefab(cellPrefab); // Cell prefab'ını bağlayın
    }


}
