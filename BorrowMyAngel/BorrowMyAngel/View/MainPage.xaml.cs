using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BorrowMyAngel.View
{
    public partial class MainPage : ContentPage
    {
        private double _origBackgroundScale;
        private double _origBackgroundPosY;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //When the page loads let's find out what the size of the banner
            //  should be. We want it to always be 1/16th of the current screen
            //  size.
            banner.HeightRequest = DeviceDisplay.ScreenMetrics.Height / 16;

            //Set up the update timer for the screen that will control animation
            //  states.
            Device.StartTimer(TimeSpan.FromMilliseconds(1), Update);

            //Set up the initial position, scale, and opacity for all the views
            //  that will be animated
            _origBackgroundScale = backgroundImage.Scale;
            _origBackgroundPosY = backgroundImage.TranslationY;
            //backgroundImage.Opacity = 0;
            backgroundImage.Scale = backgroundImage.Scale + 20;
            backgroundImage.TranslationY = backgroundImage.TranslationY + 1800;

            banner.Opacity = 0;
            btnFindAngel.Opacity = 0;
            btnCreateAccount.Opacity = 0;
            btnLogin.Opacity = 0;

            //When the view first appears we need to animate the background image
            //  to get all the other animations rolling
            //First set up the main animation handler
            var backgroundImageAnim = new Animation();
            var scale = new Animation(callback: d => backgroundImage.Scale = d,
                                      start: backgroundImage.Scale,
                                      end: _origBackgroundScale);
            var translation = new Animation(callback: d => backgroundImage.TranslationY = d,
                                            start: backgroundImage.TranslationY,
                                            end: _origBackgroundPosY);

            //Add the scaling and translation animation. these animations will 
            //  start 20% into the animation (0.2) and will last until the end 
            //  of the animation time (1)
            backgroundImageAnim.Add(0, 1, scale);
            backgroundImageAnim.Add(0, 1, translation);
            //Finally commit the animation to begin the animation
            backgroundImageAnim.Commit(backgroundImage, "backgroundImageAnim", length: 1500);
        }

        private bool Update()
        {
            //The first thing we need to check the state of is if the background
            //  image has finished animating
            if (backgroundImage.Scale <= _origBackgroundScale)
            {
                //Now that the background image has been animated we then animate
                //  the banner and buttons
                if (banner.Opacity <= 0)
                {
                    banner.FadeTo(1, 1000);
                    btnFindAngel.FadeTo(1, 1000);
                    btnCreateAccount.FadeTo(1, 1000);
                    btnLogin.FadeTo(1, 1000);
                }
                else if (banner.Opacity >= 0.99)
                {
                    //All the animations are complete so return false to stop 
                    //  the timer.
                    return false;
                }
            }

            return true;
        }
    }
}
