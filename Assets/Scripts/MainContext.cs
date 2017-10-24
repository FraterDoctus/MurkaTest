using Commands;
using Figure;
using Figure.Drawer;
using Figure.Visualizer;
using UI;
using UnityEngine;
using Utils;

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
        injectionBinder.Bind<IPolygonVisualizer>().To<LineRendererPolygonVisualizer>().ToSingleton();
        injectionBinder.Bind<IDrawer>().To<MouseDrawer>().ToSingleton();
        injectionBinder.Bind<UpdateDispatcher>().ToSingleton();
        
        commandBinder.Bind<AppStartSignal>().To<AppStartCommand>().Once();
        commandBinder.Bind<StartGameSignal>().To<StartGameCommand>().Once();
        commandBinder.Bind<UserDrawedPolygonSignal>().To<UserDrawedPolygonCommand>();
    }
}