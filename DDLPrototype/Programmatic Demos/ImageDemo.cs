//using DeclarativeLayout.Structs;
//using System.Windows.Forms;

//namespace DeclarativeLayout.Demos
//{
//    public class ImageDemo : Layout
//    {
//        public ImageDemo(Form form, IMeasurer measurer) : base(form)
//        {
//            Color backgroundColor = new Color(100, 0, 0, 139); // dark blue
//            Color fontColor = new Color(255, 255, 255); // white
//            Color lineColor = new Color(255, 0, 0); ; // red

//            StackPanel stackPanel = new StackPanel()
//            {
//                Margin = new Thickness
//                {
//                    left = 40,
//                    top = 40,
//                    right = 40
//                },
//                HorizontalAlignment = Structs.HorizontalAlignment.Stretch
//            };

//            TextBlock textBlock1 = new TextBlock("HOW TO WIN")
//            {
//                FontColor = fontColor,
//                FontFamily = "Segoe UI",
//                FontSize = 12
//            };

//            Rectangle horizontalLine = new Rectangle()
//            {
//                Fill = lineColor,
//                Margin = new Thickness
//                {
//                    top = 8
//                },
//                HorizontalAlignment = Structs.HorizontalAlignment.Stretch,
//                Height = 2
//            }; 

//            TextBlock textBlock2 = new TextBlock("GAMBLING")
//            {
//                FontColor = fontColor,
//                FontFamily = "Constantia",
//                FontSize = 50, // should be bold
//                Margin = new Thickness
//                {
//                    top = 100,
//                    left = 100
//                }
//            };
//            TextBlock textBlock3 = new TextBlock("TO WIN 101")
//            {
//                FontColor = fontColor,
//                FontFamily = "Constantia",
//                FontSize = 50, // should be bold
//                Margin = new Thickness
//                {
//                    top = 0
//                }
//            };

//            TextBlock textBlock4 = new TextBlock("Presentation definitely not by a casino. The house never wins.")
//            {
//                FontColor = fontColor,
//                Margin = new Thickness
//                {
//                    top = 0,
//                    left = 10,
//                    right = 10
//                },
//                FontFamily = "Segoe UI",
//                FontSize = 12,
//                HorizontalAlignment = Structs.HorizontalAlignment.Right
//            };

//            Image dice = new Image()
//            {
//                Source = Application.StartupPath + @"\dice.png",
//                Width = 100,
//                Height = 100
//            };

//            stackPanel.Children.Add(textBlock1);
//            stackPanel.Children.Add(horizontalLine);
//            stackPanel.Children.Add(dice);
//            stackPanel.Children.Add(textBlock2);
//            stackPanel.Children.Add(textBlock3);
//            stackPanel.Children.Add(textBlock4);

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
//            this.Grid.Children.Add(stackPanel);

//            this.Grid.ShowLayoutRectangles = true;

//            this.LayOut(measurer);
//            this.Arrange();
//            //this.Refresh();
//        }
//    }
//}