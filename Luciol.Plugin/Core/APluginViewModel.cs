﻿using ReactiveUI;

namespace Luciol.Plugin.Core
{
    public abstract class APluginViewModel : ReactiveObject
    {
        public virtual void Init(ADisplayPlugin plugin)
        { }
    }
}
