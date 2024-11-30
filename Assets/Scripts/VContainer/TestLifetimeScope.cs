using VContainer;
using VContainer.Unity;
using Timer;
using UnityEngine;
using Player;
using Manager;
using Block;
using Score;
public class TestLifetimeScope : LifetimeScope
{
    [SerializeField]
    GameObject InputProvider;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<Timer.Timer>(Lifetime.Singleton);
        builder.Register<InGameManager>(Lifetime.Singleton);

        IInputProvider _input = InputProvider.GetComponent<IInputProvider>();
        builder.RegisterComponent(_input);
    }
}
