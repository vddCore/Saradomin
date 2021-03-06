using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using PropertyChanged;
using Saradomin.Messaging;

namespace Saradomin.Views.Windows
{
    [DoNotNotify]
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        protected override void OnOpened(EventArgs e)
        {
            App.Messenger.Send(
                new MainViewLoadedMessage()
            );
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void TitleBar_MouseDown(object _, PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
                BeginMoveDrag(e);
        }
    }
}