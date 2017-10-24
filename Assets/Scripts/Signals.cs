using FigureRecognizing;
using strange.extensions.signal.impl;

public class AppStartSignal : Signal { }
public class StartGameSignal : Signal { }
public class UserDrawedPolygonSignal : Signal<Polygon> { }