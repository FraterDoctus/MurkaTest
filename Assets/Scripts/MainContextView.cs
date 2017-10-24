using strange.extensions.context.impl;

public class MainContextView : ContextView
{
    private void Start()
    {        
        var context = new MainContext(this);
        context.Start();
    }
}