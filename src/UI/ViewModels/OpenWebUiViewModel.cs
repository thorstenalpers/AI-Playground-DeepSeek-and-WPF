﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace AiPlayground.UI.ViewModels;

public class OpenWebUiViewModel : ObservableObject
{
    private const string _source = "http://open-webui.localhost";

    public string Source
    {
        get { return _source; }
    }
}
