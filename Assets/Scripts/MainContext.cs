using Commands;
using Figure;
using UI;
using UnityEngine;

public class MainContext : SignalContext
{
    public MainContext(MonoBehaviour contexView) : base(contexView)
    {
    }

    protected override void mapBindings()
    {
        base.mapBindings();

        injectionBinder.Bind<IUiController>().To<CanvasUiController>().ToSingleton();
        injectionBinder.Bind<IFiguresManager>().To<ResourcesFiguresManager>().ToSingleton();
        injectionBinder.Bind<GameController>().ToSingleton();
        
        commandBinder.Bind<AppStartSignal>().To<AppStartCommand>().Once();
        commandBinder.Bind<StartGameSignal>().To<StartGameCommand>().Once();
    }
}