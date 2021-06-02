using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PrefabInstaller", menuName = "Installers/PrefabInstaller")]
public class PrefabInstaller : ScriptableObjectInstaller<PrefabInstaller>
{
    [SerializeField]
    private GameObject snowball;

    public override void InstallBindings()
    {
        Container.BindInstance(snowball);
    }
}