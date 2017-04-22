using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Class12.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class BrushPage : Page
    {
        public BrushPage()
        {
            this.InitializeComponent();
            InitRect_1();
        }

        private void InitRect_1()
        {
            Visual rect_visual = ElementCompositionPreview.GetElementVisual(rect_1);
            SpriteVisual spritevisual = rect_visual.Compositor.CreateSpriteVisual();
            CompositionNineGridBrush brush = rect_visual.Compositor.CreateNineGridBrush();
            brush.Source = rect_visual.Compositor.CreateColorBrush(Windows.UI.Colors.Red);
            brush.SetInsets(1, 3, 5, 7);
            brush.IsCenterHollow = true;
            spritevisual.Brush = brush;
            ElementCompositionPreview.SetElementChildVisual(canvas_1, spritevisual);

            ExpressionAnimation animation1 = rect_visual.Compositor.CreateExpressionAnimation("Visual.Size");
            animation1.SetReferenceParameter("Visual", rect_visual);
            spritevisual.StartAnimation("Size", animation1);
            ExpressionAnimation animation2 = rect_visual.Compositor.CreateExpressionAnimation("-Visual.Size.X/2");
            animation2.SetReferenceParameter("Visual", rect_visual);
            spritevisual.StartAnimation("Offset.X", animation2);
            spritevisual.StartAnimation("Offset.Y", animation2);
        }
    }
}
