using UnityEngine;
using Zenject;

public class PoolInstaller : MonoInstaller
{
    public GameObject poolPref;
    public override void InstallBindings()
    {
       
        SnowBallPool pool = Container
           .InstantiatePrefabForComponent<SnowBallPool>(poolPref, Vector3.zero, Quaternion.identity, null);

        Container.
           Bind<SnowBallPool>().FromInstance(pool).AsSingle();
    }
}