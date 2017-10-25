using FigureRecognizing;
using strange.extensions.signal.impl;

public class AppStartSignal : Signal { }
public class StartGameSignal : Signal { }
public class UserDrawedPolygonSignal : Signal<Polygon> { }
public class IncreaseScoreSignal : Signal { }
public class GameOverSignal : Signal { }
public class RetrySignal : Signal { }
public class UpdateTimeSignal : Signal<float> { }
public class StartDrawSignal : Signal { }