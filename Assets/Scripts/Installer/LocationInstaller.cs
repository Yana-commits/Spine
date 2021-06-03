using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    public Vector3 startPoint;

    public GameObject hippoPrefab;

    public override void InstallBindings()
    {
      PlayerController player =  Container
            .InstantiatePrefabForComponent<PlayerController>(hippoPrefab, startPoint, Quaternion.identity, null);

        Container.
            Bind<PlayerController>().FromInstance(player).AsSingle();

    }
}