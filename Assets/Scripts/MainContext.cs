using Commands;
using Figure;
using Figure.Drawer;
using Figure.FiguresComparer;
using Figure.Visualizer;
using MouseParticle;
using Timer;
using UI;
using UnityEngine;
using Utils;
using Utils.Executor;

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
        injectionBinder.Bind<IFigureComparer>().To<RadialFigureComparer>().ToSingleton();
        injectionBinder.Bind<ScoreController>().ToSingleton();
        injectionBinder.Bind<ITimer>().To<UpdateTimer>().ToSingleton();
        injectionBinder.Bind<IMouseParticle>().To<ResourcesMouseParticle>().ToSingleton();
        injectionBinder.Bind<IExecutor>().To<CoroutineExecutor>().ToSingleton();
        
        commandBinder.Bind<AppStartSignal>().To<AppStartCommand>().Once();
        commandBinder.Bind<StartGameSignal>().To<StartGameCommand>();
        commandBinder.Bind<UserDrawedPolygonSignal>().To<UserDrawedPolygonCommand>();
        commandBinder.Bind<IncreaseScoreSignal>().To<IncreaseScoreCommand>();
        commandBinder.Bind<GameOverSignal>().To<GameOverCommand>();
        commandBinder.Bind<RetrySignal>().To<RetryCommand>();
        commandBinder.Bind<UpdateTimeSignal>().To<UpdateTimeCommand>();
        commandBinder.Bind<StartDrawSignal>().To<StartDrawCommand>();
    }
}