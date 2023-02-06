//using DeclarativeLayout.Structs;
//using System.Windows.Forms;

//namespace DeclarativeLayout.Demos
//{
//    public class DockPanelDemo : Layout
//    {
//        public DockPanelDemo(Form form, IMeasurer measurer) : base(form)
//        {
//            Color backgroundColor = new Color(100, 0, 0, 139); // dark blue
//            Color fontColor = new Color(255, 255, 255); // white
//            Color lineColor = new Color(255, 0, 0); ; // red

//            DockPanel dockPanel = new DockPanel()
//            {
//                Margin = new Thickness
//                {
//                    left = 50,
//                    top = 50,
//                    bottom = 50,
//                    right = 50
//                }
//            };

//            TextBlock textBlock1 = new TextBlock("HOW TO WIN")
//            {
//                FontColor = fontColor,
//                FontFamily = "Segoe UI",
//                FontSize = 12
//            };

//            TextBlock textBlock2 = new TextBlock("GAMBLING")
//            {
//                FontColor = fontColor,
//                FontFamily = "Constantia",
//                FontSize = 50 // should be bold
//            };

//            textBlock2.SetAttachedProperty(GlobalAttachedPropertyManager.GetAttachedProperty("Dock", typeof(DockPanel)), Dock.Top);

//            TextBlock textBlock3 = new TextBlock("FUN!")
//            {
//                FontColor = fontColor,
//                FontFamily = "Constantia",
//                FontSize = 50, // should be bold
//                HorizontalAlignment = Structs.HorizontalAlignment.Right
//            };

//            textBlock3.SetAttachedProperty(GlobalAttachedPropertyManager.GetAttachedProperty("Dock", typeof(DockPanel)), Dock.Bottom);

//            TextBlock textBlock4 = new TextBlock("WIN!")
//            {
//                FontColor = fontColor,
//                FontFamily = "Constantia",
//                FontSize = 50, // should be bold
//            };

//            textBlock2.SetAttachedProperty(GlobalAttachedPropertyManager.GetAttachedProperty("Dock", typeof(DockPanel)), Dock.Right);

//            //TextBlock textBlock5 = new TextBlock("V FUN!")
//            //{
//            //    FontColor = fontColor,
//            //    Font = new Font("Constantia", 50, FontStyle.Bold),
//            //    HorizontalAlignment = Structs.HorizontalAlignment.Center
//            //};

//            dockPanel.Children.Add(textBlock1);
//            dockPanel.Children.Add(textBlock2);
//            dockPanel.Children.Add(textBlock3);
//            dockPanel.Children.Add(textBlock4);

//            StackPanel stackPanel = new StackPanel()
//            {
//                Horizontal = true
//            };

//            stackPanel.SetAttachedProperty(GlobalAttachedPropertyManager.GetAttachedProperty("Dock", typeof(DockPanel)), Dock.Bottom);

//            TextBlock textBlock5 = new TextBlock("Stack 1!")
//            {
//                FontColor = fontColor,
//                FontFamily = "Constantia",
//                FontSize = 50, // should be bold
//            };

//            textBlock5.SetAttachedProperty(GlobalAttachedPropertyManager.GetAttachedProperty("Dock", typeof(DockPanel)), Dock.Right);

//            TextBlock textBlock6 = new TextBlock("Stack 2!")
//            {
//                FontColor = fontColor,
//                FontFamily = "Constantia",
//                FontSize = 50, // should be bold
//            };

//            stackPanel.Children.Add(textBlock5);
//            stackPanel.Children.Add(textBlock6);


//            dockPanel.Children.Add(stackPanel);

//            //dockPanel.SetDock(textBlock2, Dock.Top);
//            //dockPanel.SetDock(textBlock3, Dock.Bottom);
//            //dockPanel.SetDock(textBlock4, Dock.Right);
//            //dockPanel.SetDock(textBlock5, Dock.Bottom);
//            //dockPanel.SetDock(stackPanel, Dock.Bottom);

//            Image image = new Image
//            {
//                Source = Application.StartupPath + @"\casino.jpg",
//                StretchMode = StretchMode.UniformToFill,
//            };

//            Rectangle rectangle = new Rectangle
//            {
//                Fill = backgroundColor,
//            };

//            this.Grid.Children.Add(image);
//            this.Grid.Children.Add(rectangle);
//            this.Grid.Children.Add(dockPanel);

//            this.Grid.ShowLayoutRectangles = true;

//            //this.LayOut();
//            //this.Arrange();
//            //this.Refresh();
//        }
//    }
//}
