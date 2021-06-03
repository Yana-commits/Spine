using UnityEngine;
using Zenject;

public class SignalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<JustSignal>();
    }
}