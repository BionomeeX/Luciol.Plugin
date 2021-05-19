﻿using InterFace.Plugin.Event;
using System;

namespace InterFace.Plugin
{
    public interface IMainTriangle
    {
        public event EventHandler<ClickEventArgs> OnClick;
        public event EventHandler<DataLoadEventArgs> OnDataLoad;
        public event EventHandler<AnnotationAddEventArgs> OnAnnotationAdd;
    }
}
