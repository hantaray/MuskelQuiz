using System;
using System.Collections.Generic;
using System.ComponentModel;
using Quizz_PhysioUnited.ViewModels;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Quizz_PhysioUnited
{
    public class LoadingView : ContentView, INotifyPropertyChanged
    {


        private bool isLoading;
        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }

            set
            {
                isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public LoadingView()
        {


            //this.IsVisible = true;


            BindingContext = this;
            this.SetBinding(Image.IsVisibleProperty, "IsLoading");

            //BindingContext =  new

            //LoadingViewModel lvw = new LoadingViewModel();

            //Binding myBinding = new Binding("IsLoading");
            //myBinding.Source = lvw.IsLoading;
            //myBinding.Mode = BindingMode.TwoWay;
            //myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //BindingOperations.SetBinding(txtText, TextBox.TextProperty, myBinding);


            RelativeLayout relLay = new RelativeLayout();
            

            Image background = new Image {  Source = "BG_chance.png",
                                            Opacity = 1,
                                            Aspect = Aspect.Fill};

            //background.BindingContext = this;
            //background.SetBinding(Image.IsVisibleProperty, "IsLoading");

            relLay.Children.Add(background,
                xConstraint: Constraint.Constant(0),
                yConstraint: Constraint.Constant(0),
                widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
                heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height; })
                );

            ActivityIndicator actIndi = new ActivityIndicator
            {
                IsRunning = false,
                IsVisible = false,
                //SetBinding(ActivityIndicator.IsRunningProperty, "IsRunning"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Color = Color.Black,
            };

        
            
            actIndi.BindingContext = this;
            actIndi.SetBinding(ActivityIndicator.IsRunningProperty, "IsLoading");
            actIndi.SetBinding(IsVisibleProperty, "IsLoading");

            relLay.Children.Add(actIndi,
                widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
                heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height; })
                );

            Content = relLay;

            //Content = new StackLayout
            //{
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    //Orientation = StackOrientation.Vertical,
            //    //BackgroundColor = Color.Red,
            //    Children = {
            //        new Image
            //        {
            //            //xConstraint: Constraint.Constant(0),
            //            //yConstraint: Constraint.Constant(0),
            //            //widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
            //            //heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height; }));
            //        }

            //        //new Label { Text = "Welcome to Xamarin.Forms!",
            //        //VerticalOptions = LayoutOptions.CenterAndExpand,
            //        //HorizontalOptions = LayoutOptions.CenterAndExpand}

            //    }
            //};
        }

        public object RowDefinitions { get; }
    }
}