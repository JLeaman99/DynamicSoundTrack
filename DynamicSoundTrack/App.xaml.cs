﻿using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Threading;

namespace DynamicSoundTrack
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MusicHandler handler = new MusicHandler();
       
    }

}
