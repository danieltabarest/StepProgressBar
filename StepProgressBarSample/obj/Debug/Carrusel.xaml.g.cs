//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("StepProgressBarSample.Carrusel.xaml", "Carrusel.xaml", typeof(global::StepProgressBarSample.Carrusel))]

namespace StepProgressBarSample {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Carrusel.xaml")]
    public partial class Carrusel : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.ContentPage page;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::StepProgressBarSample.StepProgressBarControl stepBar;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::PanCardView.CarouselView MyCarouselView;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(Carrusel));
            page = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ContentPage>(this, "page");
            stepBar = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::StepProgressBarSample.StepProgressBarControl>(this, "stepBar");
            MyCarouselView = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::PanCardView.CarouselView>(this, "MyCarouselView");
        }
    }
}