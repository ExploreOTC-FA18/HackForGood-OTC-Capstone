using System;
using System.Collections.Generic;
using BorrowMyAngel.Client;
using BorrowMyAngel.Server;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BorrowMyAngel.View
{
    public partial class MainPage : ContentPage
    {
        private double _origBackgroundScale;
        private double _origBackgroundPosY;
        private bool _showNewScreen;
        private Page _newScreen;

        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            _origBackgroundScale = backgroundImage.Scale;
            _origBackgroundPosY = backgroundImage.TranslationY;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Just incase the user is coming from somwhere that would have the
            //  server/client being ran let's shut that off
            TCPClient.Stop();
            TCPServer.Stop();

            //When the page loads let's find out what the size of the banner
            //  should be. We want it to always be 1/16th of the current screen
            //  size.
            banner.HeightRequest = DeviceDisplay.ScreenMetrics.Height / 16;

            //Set up the update timer for the screen that will control animation
            //  states.
            Device.StartTimer(TimeSpan.FromMilliseconds(1), Update);

            //Set up the initial position, scale, and opacity for all the views
            //  that will be animated
            backgroundImage.Scale = backgroundImage.Scale + 20;
            backgroundImage.TranslationY = backgroundImage.TranslationY + 1800;

            banner.Opacity = 0;
            btnFindAngel.Opacity = 0;
            btnCreateAccount.Opacity = 0;
            btnLogin.Opacity = 0;

            //When the view first appears we need to animate the background image
            //  to get all the other animations rolling
            //First set up the main animation handler
            AnimateBackgroundImage(backgroundImage.Scale, 
                                   _origBackgroundScale, 
                                   backgroundImage.TranslationY, 
                                   _origBackgroundPosY, 0, 1);
        }

        private bool Update()
        {
            //The first thing we need to check the state of is if the background
            //  image has finished animating
            if (!_showNewScreen)
            {
                if (backgroundImage.Scale <= _origBackgroundScale)
                {
                    //Now that the background image has been animated we then animate
                    //  the banner and buttons
                    if (banner.Opacity <= 0)
                    {
                        FadeItems(1, 1000);
                    }
                    else if (banner.Opacity >= 0.99)
                    {
                        //All the animations are complete so return false to stop 
                        //  the timer.
                        return false;
                    }
                }
            }
            else
            {
                if (banner.Opacity <= 0.01)
                {
                    if (backgroundImage.Scale <= _origBackgroundScale)
                    {
                        AnimateBackgroundImage(_origBackgroundScale,
                                               backgroundImage.Scale + 20,
                                               _origBackgroundPosY,
                                               backgroundImage.TranslationY + 1800,
                                               0, 1);
                    }
                    else if (backgroundImage.Scale >= _origBackgroundScale + 20)
                    {
                        Navigation.PushAsync(_newScreen);
                        _showNewScreen = false;
                        return false;
                    }
                }
            }

            return true;
        }

        void LoginClicked(object sender, System.EventArgs e)
        {
            _newScreen = new LoginScreen();
            SetUpScreenTransition();
        }

        void FindAngelClicked(object sender, System.EventArgs e)
        {
            _newScreen = new ConnectionScreen();
            SetUpScreenTransition();
        }

        void CreateAccountClicked(object sender, System.EventArgs e)
        {
            _newScreen = new AccountCreationScreen();
            SetUpScreenTransition();
        }

        void AttributionClicked(object sender, System.EventArgs e)
        {
            _newScreen = new AttributionScreen();
            SetUpScreenTransition();
        }

        private void FadeItems(double opacity, uint length)
        {
            banner.FadeTo(opacity, length);
            btnFindAngel.FadeTo(opacity, length);
            btnCreateAccount.FadeTo(opacity, length);
            btnLogin.FadeTo(opacity, length);
        }

        private void SetUpScreenTransition()
        {
            _showNewScreen = true;
            FadeItems(0, 500);
            Device.StartTimer(TimeSpan.FromMilliseconds(1), Update);
        }

        private void AnimateBackgroundImage(double scaleStart, double scaleEnd, double translationStart, double translationEnd, double startTime, double endTime)
        {
            var backgroundImageAnim = new Animation();
            var scale = new Animation(callback: d => backgroundImage.Scale = d,
                                      start: scaleStart,
                                      end: scaleEnd);
            var translation = new Animation(callback: d => backgroundImage.TranslationY = d,
                                            start: translationStart,
                                            end: translationEnd);

            //Add the scaling and translation animation. these animations will 
            //  start 20% into the animation (0.2) and will last until the end 
            //  of the animation time (1)
            backgroundImageAnim.Add(startTime, endTime, scale);
            backgroundImageAnim.Add(startTime, endTime, translation);
            //Finally commit the animation to begin the animation
            backgroundImageAnim.Commit(backgroundImage, "backgroundImageAnim", length: 1200);
        }
    }
}
