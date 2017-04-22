using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Class12.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class AnimationPage : Page
    {
        private ViewModels.AnimationPageViewModel viewmodel;

        private ScrollViewer listview_sc;

        private Visual rect_1_visual;
        private Visual refreshing_visual;
        private ExpressionAnimation animation2;
        public AnimationPage()
        {
            this.InitializeComponent();
            viewmodel = new ViewModels.AnimationPageViewModel();
            this.DataContext = viewmodel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

        }

        private void but_1_Click(object sender, RoutedEventArgs e)
        {
            KeyFrameAnimation();
        }

        private void KeyFrameAnimation()
        {
            rect_1_visual = ElementCompositionPreview.GetElementVisual(rect_1);
            var animation = rect_1_visual.Compositor.CreateScalarKeyFrameAnimation();
            animation.Duration = new TimeSpan(0, 0, 0, 2);
            animation.InsertKeyFrame(0.3f, 0.6f);
            animation.InsertKeyFrame(0.6f, 0.8f);
            animation.InsertKeyFrame(1.0f, 1.0f);
            rect_1_visual.StartAnimation("Opacity", animation);
        }

        private void ExperessionAnimation()
        {
            refreshing_visual = ElementCompositionPreview.GetElementVisual(listview_sc);
            var propertyset = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(listview_sc);
            animation2 = refreshing_visual.Compositor.CreateExpressionAnimation("(PropertySet.Translation.Y==0)?40:0");
            animation2.SetReferenceParameter("PropertySet", propertyset);
            refreshing_visual.StartAnimation("Offset.Y", animation2);
        }

        private async Task Refresh()
        {
            try
            {
                string json = await HttpRequests.HttpRequestClient.LastestRequest();
                if (json != null)
                    viewmodel.Lastest = JsonConvert.DeserializeObject<Models.Lastest>(json);
            }
            catch (Exception)
            {
            }
        }
        private void Get_Child(DependencyObject o, int n)
        {
            try
            {
                int count = VisualTreeHelper.GetChildrenCount(o);
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        var child = VisualTreeHelper.GetChild(o, count - 1);
                        if (n == 0)
                        {
                            if (child is ScrollViewer)
                            {
                                listview_sc = child as ScrollViewer;
                            }
                            else
                            {
                                Get_Child(VisualTreeHelper.GetChild(o, count - 1), n);
                            }
                        }
                        else if (n == 1)
                        {

                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private async void listview_2_Loaded(object sender, RoutedEventArgs e)
        {
            Get_Child(listview_2, 0);
            ExperessionAnimation();
            await Refresh();
        }
    }
}
