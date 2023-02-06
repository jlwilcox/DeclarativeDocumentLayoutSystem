//using DeclarativeLayout.Structs;
//using System.Windows.Forms;

//namespace DeclarativeLayout.Demos
//{
//    public class CreativeWriting : Layout
//    {
//        public CreativeWriting(Form form, IMeasurer measurer) : base(form)
//        {
//            Color backgroundColor = new Color(254, 239, 233);
//            Color fontColor = new Color(75, 39, 30);
//            Color lineColor = new Color(246, 216, 186);

//            StackPanel stackPanel = new StackPanel()
//            {
//                Margin = new Thickness
//                {
//                    left = 40,
//                    top = 40,
//                    right = 40
//                }
//            };

//            TextBlock textBlock1 = new TextBlock("A GUIDE FOR YOUNG WRITERS")
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
//                Width = 700,
//                Height = 2
//            }; 

//            TextBlock textBlock2 = new TextBlock("CREATIVE")
//            {
//                FontColor = fontColor,
//                FontFamily = "Constantia",
//                FontSize = 50, // should be bold
//                Margin = new Thickness
//                {
//                    top = 140
//                }
//            };
//            TextBlock textBlock3 = new TextBlock("WRITING 101")
//            {
//                FontColor = fontColor,
//                FontFamily = "Constantia",
//                FontSize = 50, // should be bold
//                Margin = new Thickness
//                {
//                    top = -17
//                }
//            };

//            TextBlock textBlock4 = new TextBlock("Presentation by Group 1")
//            {
//                FontColor = fontColor,
//                Margin = new Thickness
//                {
//                    top = 5,
//                    left = 10
//                },
//                FontFamily = "Segoe UI",
//                FontSize = 12
//            };

//            stackPanel.Children.Add(textBlock1);
//            stackPanel.Children.Add(horizontalLine);
//            stackPanel.Children.Add(textBlock2);
//            stackPanel.Children.Add(textBlock3);
//            stackPanel.Children.Add(textBlock4);

//            Rectangle rectangle = new Rectangle
//            {
//                Fill = backgroundColor
//            };

//            this.Grid.Children.Add(rectangle);
//            this.Grid.Children.Add(stackPanel);

//            this.Grid.ShowLayoutRectangles = true;

//            //this.LayOut();
//            //this.Arrange();
//        }
//    }
//}
