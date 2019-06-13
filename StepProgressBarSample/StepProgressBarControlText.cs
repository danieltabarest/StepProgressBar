using System;
using System.Linq;
using Xamarin.Forms;

namespace StepProgressBarSample
{
    public class StepProgressBarControlText : StackLayout
    {
        Button _lastStepSelected;
        BoxView _separatorLine;
        public static readonly BindableProperty StepsProperty = BindableProperty.Create(nameof(Steps), typeof(int), typeof(StepProgressBarControlText), 0);
        public static readonly BindableProperty StepSelectedProperty = BindableProperty.Create(nameof(StepSelected), typeof(int), typeof(StepProgressBarControlText), 0, defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty StepColorProperty = BindableProperty.Create(nameof(StepColor), typeof(Xamarin.Forms.Color), typeof(StepProgressBarControlText), Color.Black, defaultBindingMode: BindingMode.TwoWay);

        public Color StepColor
        {
            get { return (Color)GetValue(StepColorProperty); }
            set { SetValue(StepColorProperty, value); }
        }

        public int Steps
        {
            get { return (int)GetValue(StepsProperty); }
            set { SetValue(StepsProperty, value); }
        }

        public int StepSelected
        {
            get { return (int)GetValue(StepSelectedProperty); }
            set { SetValue(StepSelectedProperty, value); }
        }


        public StepProgressBarControlText()
        {
            Orientation = StackOrientation.Horizontal;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            Padding = new Thickness(10, 0);
            Spacing = 0;
            AddStyles();

        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == StepsProperty.PropertyName)
            {
                for (int i = 0; i < Steps; i++)
                {
                    var button = new Button()
                    {
                        ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Top,0),
                        //Text = "Diagnastico",
                        ClassId = $"{i + 1}",
                        Style = Resources["startButtonStyle"] as Style
                    };

                    button.Clicked += Button_Clicked;

                    this.Children.Add(button);

                    if (i < Steps - 1)
                    {
                        _separatorLine = new BoxView()
                        {
                            Style = Resources["unSelecteStyleLine"] as Style,
                            ClassId = $"{i + 1}",
                            HeightRequest = 1,
                            WidthRequest = 5,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.FillAndExpand
                        };
                        this.Children.Add(_separatorLine);
                    }
                }
            }
            else if (propertyName == StepColorProperty.PropertyName)
            {
                AddStyles();
            }
        }
        void Button_Clicked(object sender, System.EventArgs e)
        {
            SelectElement(sender as Button);
        }

        void SelectElement(Button elementSelected)
        {
            StepSelected = Convert.ToInt32(elementSelected.ClassId);
            if (_lastStepSelected != null && Convert.ToInt32(elementSelected.ClassId) < Convert.ToInt32(_lastStepSelected.ClassId))
            {
                ResetElements(elementSelected);
                _lastStepSelected = elementSelected;
                return;
            }

            _lastStepSelected = elementSelected;

            foreach (var item in this.Children)
            {
                if (Convert.ToInt32(item.ClassId) == StepSelected)
                {
                    if (item != null)
                    {
                        item.Style = Resources["unSelectedStyle"] as Style;
                        SetCornerRadius(item);
                        break;
                    }
                }
                if (item is BoxView)
                {
                    if (item != null)
                    {
                        item.Style = Resources["selecteStyleLine"] as Style;
                        SetCornerRadius(item);
                    }

                }
                if (item is Button)
                {
                    if (item != null)
                    {
                        item.Style = Resources["selectedStyle"] as Style;
                        SetCornerRadius(item);
                    }
                }
            }
        }

        void ResetElements(Button elementSelected)
        {
            foreach (var item in this.Children)
            {
                if (item is Button && Convert.ToInt32(item.ClassId) == Convert.ToInt32(elementSelected.ClassId))
                {
                    if (item != null)
                    {
                        item.Style = Resources["unSelectedStyle"] as Style;
                        SetCornerRadius(item);
                        continue;
                    }

                }
                if (item is BoxView && Convert.ToInt32(item.ClassId) >= Convert.ToInt32(elementSelected.ClassId))
                {
                    if (item != null)
                    {
                        item.Style = Resources["unSelecteStyleLine"] as Style;
                        SetCornerRadius(item);
                    }
                }
                if (item is Button && Convert.ToInt32(item.ClassId) > Convert.ToInt32(elementSelected.ClassId))
                {
                    if (item != null)
                    {
                        item.Style = Resources["startButtonStyle"] as Style;
                        SetCornerRadius(item);
                    }
                }
            }
        }

        private static void SetCornerRadius(View item)
        {
            if (item is Button)
            {
                ((Button)item).CornerRadius = 20;
            }
            else
            {
                ((BoxView)item).CornerRadius = 20;
            }
        }

        void AddStyles()
        {

            var unSelecteStyleLine = new Style(typeof(BoxView))
            {
                Setters = {
                    new Setter { Property = BackgroundColorProperty,   Value = Color.Silver },
            }
            };

            var selecteStyleLine = new Style(typeof(BoxView))
            {
                Setters = {
                    new Setter { Property = BackgroundColorProperty,   Value = Color.Green },
            }
            };

            var unselectedStyle = new Style(typeof(Button))
            {
                Setters = {
                    new Setter { Property = BackgroundColorProperty,   Value = Color.Transparent },
                    new Setter { Property = Button.BorderColorProperty,   Value = StepColor },
                    new Setter { Property = Button.BorderWidthProperty,   Value = 0.5 },
                    new Setter { Property = Button.TextColorProperty,   Value = Color.Blue },
                    new Setter { Property = Button.CornerRadiusProperty,   Value = 30 },
                    //new Setter { Property = Button.,   Value = Aspect.Fill },
                    new Setter { Property = Button.ImageSourceProperty,   Value = "dcon" },
                    new Setter { Property = HeightRequestProperty,   Value = 22 },
                    new Setter { Property = WidthRequestProperty,   Value = 22 }
            }
            };

            var startButtonStyle = new Style(typeof(Button))
            {
                Setters = {
                    new Setter { Property = BackgroundColorProperty,   Value = Color.Transparent },
                    new Setter { Property = Button.BorderColorProperty,   Value = StepColor },
                    new Setter { Property = Button.BorderWidthProperty,   Value = 0.5 },
                    new Setter { Property = Button.TextColorProperty,   Value = Color.Blue },
                    new Setter { Property = Button.CornerRadiusProperty,   Value = 30 },
                    //new Setter { Property = Button.AspectProperty,   Value = Aspect.Fill },
                    new Setter { Property = Button.ImageSourceProperty,   Value = "" },
                    new Setter { Property = HeightRequestProperty,   Value = 22 },
                    new Setter { Property = WidthRequestProperty,   Value = 22 }
            }
            };

            var selectedStyle = new Style(typeof(Button))
            {
                Setters = {
                    new Setter { Property = BackgroundColorProperty, Value = Color.White },
                    new Setter { Property = Button.BorderColorProperty, Value = Color.Green },
                    new Setter { Property = Button.BorderWidthProperty,   Value = 0.5 },
                    new Setter { Property = Button.CornerRadiusProperty,   Value = 30 },
                    new Setter { Property = Button.TextColorProperty,   Value = Color.Blue },
                    //new Setter { Property = Button.AspectProperty,   Value = Aspect.Fill },
                    new Setter { Property = Button.ImageSourceProperty,   Value = "green_check" },
                    new Setter { Property = HeightRequestProperty,   Value = 22 },
                    new Setter { Property = WidthRequestProperty,   Value = 22 },
            }
            };

            Resources = new ResourceDictionary();

            Resources.Add("startButtonStyle", startButtonStyle);
            Resources.Add("unSelecteStyleLine", unSelecteStyleLine);
            Resources.Add("selecteStyleLine", selecteStyleLine);
            Resources.Add("unSelectedStyle", unselectedStyle);
            Resources.Add("selectedStyle", selectedStyle);
        }
    }
}