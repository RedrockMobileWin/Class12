using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Class12
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            menu_listview.SelectedIndex = 0;
            page_frame.Navigate(typeof(Pages.AnimationPage));
        }

        private void menu_listview_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                switch ((e.ClickedItem as TextBlock).Text)
                {
                    case "合成动画": page_frame.Navigate(typeof(Pages.AnimationPage)); menu_listview.SelectedIndex = 0; break;
                    case "合成画笔": page_frame.Navigate(typeof(Pages.BrushPage)); menu_listview.SelectedIndex = 1; break;
                    case "合成效果": page_frame.Navigate(typeof(Pages.EffectPage)); menu_listview.SelectedIndex = 2; break;
                }
            }
        }
    }
}
