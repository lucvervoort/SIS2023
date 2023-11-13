﻿#if IOS || MACCATALYST
using Foundation;
using System.Diagnostics;
using UIKit;

namespace UraniumUI.Material.Handlers;
public partial class ButtonViewHandler
{
    protected override void ConnectHandler(Microsoft.Maui.Platform.ContentView platformView)
    {
        base.ConnectHandler(platformView);
        platformView.AddGestureRecognizer(new UIContinousGestureRecognizer(Tapped));
        if (OperatingSystem.IsIOSVersionAtLeast(13))
        {
            platformView.AddGestureRecognizer(new UIHoverGestureRecognizer(OnHover));
        }
        platformView.AddGestureRecognizer(new UILongPressGestureRecognizer(OnLongPress));
    }

    private void OnLongPress(UILongPressGestureRecognizer recognizer)
    {
        ExecuteCommandIfCan(StatefulView.LongPressCommand);
        StatefulView.InvokeLongPressed();
    }

    private void OnHover(UIHoverGestureRecognizer recognizer)
    {
        switch (recognizer.State)
        {
            case UIGestureRecognizerState.Began:

                VisualStateManager.GoToState(StatefulView, VisualStateManager.CommonStates.PointerOver);
                ExecuteCommandIfCan(StatefulView.HoverCommand);
                StatefulView.InvokeHovered();
                break;
            case UIGestureRecognizerState.Ended:
            case UIGestureRecognizerState.Cancelled:
            case UIGestureRecognizerState.Failed:
                VisualStateManager.GoToState(StatefulView, VisualStateManager.CommonStates.Normal);
                ExecuteCommandIfCan(StatefulView.HoverExitCommand);
                StatefulView.InvokeHoverExited();
                break;
        }
    }

    private void Tapped(UIGestureRecognizer recognizer)
    {
        switch (recognizer.State)
        {
            case UIGestureRecognizerState.Began:
                VisualStateManager.GoToState(StatefulView, "Pressed");
                ExecuteCommandIfCan(StatefulView.PressedCommand);
                StatefulView.InvokePressed();

                break;
            case UIGestureRecognizerState.Ended:
                VisualStateManager.GoToState(StatefulView, VisualStateManager.CommonStates.Normal);
                ExecuteCommandIfCan(StatefulView.TappedCommand);
                StatefulView.InvokeTapped();

                //// TODO: Fix working of native gesture recognizers of MAUI
                foreach (var item in StatefulView.GestureRecognizers)
                {
                    Debug.WriteLine(item.GetType().Name + " is executing manually by " + this.GetType().Name);
                    if (item is TapGestureRecognizer tgr)
                    {
                        tgr.Command.Execute(StatefulView);
                    }
                }

                break;
        }
    }

    internal class UIContinousGestureRecognizer : UIGestureRecognizer
    {
        private readonly Action<UIGestureRecognizer> action;

        public UIContinousGestureRecognizer(Action<UIGestureRecognizer> action)
        {
            this.action = action;
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            State = UIGestureRecognizerState.Began;

            action(this);

            base.TouchesBegan(touches, evt);
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            State = UIGestureRecognizerState.Ended;

            action(this);

            base.TouchesEnded(touches, evt);
        }
    }
}
#endif