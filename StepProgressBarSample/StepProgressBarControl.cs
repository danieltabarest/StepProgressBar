using System;
using System.Linq;
using Xamarin.Forms;

namespace StepProgressBarSample
{
    public class StepProgressBarControl : StackLayout
    {
        ImageButton _lastStepSelected;
        BoxView _separatorLine;
        public static readonly BindableProperty StepsProperty = BindableProperty.Create(nameof(Steps), typeof(int), typeof(StepProgressBarControl), 0);
        public static readonly BindableProperty StepSelectedProperty = BindableProperty.Create(nameof(StepSelected), typeof(int), typeof(StepProgressBarControl), 0, defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty StepColorProperty = BindableProperty.Create(nameof(StepColor), typeof(Xamarin.Forms.Color), typeof(StepProgressBarControl), Color.Black, defaultBindingMode: BindingMode.TwoWay);

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


        public StepProgressBarControl()
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
                this.Orientation = StackOrientation.Vertical;

                var grid = new Grid();


                StackLayout stackLayout1 = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing= 0 };
                StackLayout stackLayout2 = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing= 0 };
                this.Children.Add(stackLayout1);
                this.Children.Add(stackLayout2);

                for (int i = 0; i < Steps; i++)
                {
                    Label label = new Label() { Text = "Diagnostico",
                                                WidthRequest = 10,
                                                HorizontalTextAlignment = TextAlignment.Center,
                                                VerticalOptions = LayoutOptions.Center,
                                                HorizontalOptions = LayoutOptions.FillAndExpand ,   
                                                FontSize = 10 };

                    var button = new ImageButton()
                    {
                        ClassId = $"{i + 1}",
                        Style = Resources["startImageButtonStyle"] as Style
                    };

                    button.Clicked += ImageButton_Clicked;

                    stackLayout1.Children.Add(button);
                    stackLayout2.Children.Add(label);

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
                        stackLayout1.Children.Add(_separatorLine);
                    }
                }
            }
            else if (propertyName == StepColorProperty.PropertyName)
            {
                AddStyles();
            }
        }
        void ImageButton_Clicked(object sender, System.EventArgs e)
        {
            SelectElement(sender as ImageButton);
        }

        void SelectElement(ImageButton elementSelected)
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
                if (item is ImageButton)
                {
                    if (item != null)
                    {
                        item.Style = Resources["selectedStyle"] as Style;
                        SetCornerRadius(item);
                    }
                }
            }
        }

        void ResetElements(ImageButton elementSelected)
        {
            foreach (var item in this.Children)
            {
                if (item is ImageButton && Convert.ToInt32(item.ClassId) == Convert.ToInt32(elementSelected.ClassId))
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
                if (item is ImageButton && Convert.ToInt32(item.ClassId) > Convert.ToInt32(elementSelected.ClassId))
                {
                    if (item != null)
                    {
                        item.Style = Resources["startImageButtonStyle"] as Style;
                        SetCornerRadius(item);
                    }
                }
            }
        }

        private static void SetCornerRadius(View item)
        {
            if (item is ImageButton)
            {
                ((ImageButton)item).CornerRadius = 20;
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

            var unselectedStyle = new Style(typeof(ImageButton))
            {
                Setters = {
                    new Setter { Property = BackgroundColorProperty,   Value = Color.Transparent },
                    new Setter { Property = ImageButton.BorderColorProperty,   Value = StepColor },
                    new Setter { Property = ImageButton.BorderWidthProperty,   Value = 0.5 },
                    new Setter { Property = ImageButton.CornerRadiusProperty,   Value = 30 },
                    new Setter { Property = ImageButton.AspectProperty,   Value = Aspect.Fill },
                    new Setter { Property = ImageButton.SourceProperty,   Value = "dcon" },
                    new Setter { Property = HeightRequestProperty,   Value = 22 },
                    new Setter { Property = WidthRequestProperty,   Value = 22 }
            }
            };

            var startImageButtonStyle = new Style(typeof(ImageButton))
            {
                Setters = {
                    new Setter { Property = BackgroundColorProperty,   Value = Color.Transparent },
                    new Setter { Property = ImageButton.BorderColorProperty,   Value = StepColor },
                    new Setter { Property = ImageButton.BorderWidthProperty,   Value = 0.5 },
                    new Setter { Property = ImageButton.CornerRadiusProperty,   Value = 30 },
                    new Setter { Property = ImageButton.AspectProperty,   Value = Aspect.Fill },
                    new Setter { Property = ImageButton.SourceProperty,   Value = "" },
                    new Setter { Property = HeightRequestProperty,   Value = 22 },
                    new Setter { Property = WidthRequestProperty,   Value = 22 }
            }
            };

            var selectedStyle = new Style(typeof(ImageButton))
            {
                Setters = {
                    new Setter { Property = BackgroundColorProperty, Value = Color.White },
                    new Setter { Property = ImageButton.BorderColorProperty, Value = Color.Green },
                    new Setter { Property = ImageButton.BorderWidthProperty,   Value = 0.5 },
                    new Setter { Property = ImageButton.CornerRadiusProperty,   Value = 30 },
                    new Setter { Property = ImageButton.AspectProperty,   Value = Aspect.Fill },
                    new Setter { Property = ImageButton.SourceProperty,   Value = "green_check" },
                    new Setter { Property = HeightRequestProperty,   Value = 22 },
                    new Setter { Property = WidthRequestProperty,   Value = 22 },
            }
            };

            Resources = new ResourceDictionary();

            Resources.Add("startImageButtonStyle", startImageButtonStyle);
            Resources.Add("unSelecteStyleLine", unSelecteStyleLine);
            Resources.Add("selecteStyleLine", selecteStyleLine);
            Resources.Add("unSelectedStyle", unselectedStyle);
            Resources.Add("selectedStyle", selectedStyle);
        }
    }
}