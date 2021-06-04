using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    public Vector3 startPoint;

    public GameObject hippoPrefab;

    public override void InstallBindings()
    {
        PlayerInstal();
    }

    private void PlayerInstal()
    {
        PlayerController player = Container
               .InstantiatePrefabForComponent<PlayerController>(hippoPrefab, startPoint, Quaternion.identity, null);

        Container.
            Bind<PlayerController>().FromInstance(player).AsSingle();
    }
}