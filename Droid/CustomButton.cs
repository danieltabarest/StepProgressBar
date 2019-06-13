using System;
using StepProgressBarSample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButton))]
namespace StepProgressBarSample.Droid
{
    public class CustomButton: ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {   // perform initial setup
                /*
                Control.Gravity = global::Android.Views.GravityFlags.Center;
                Control.SetPadding(20, 30, 0, 0);

                //Image on Top
                Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, Resource.Drawable.green_check, 0, 0);*/
            }
        }
    }
}
