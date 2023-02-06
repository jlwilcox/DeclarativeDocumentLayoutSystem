//using DDLPrototype.Structs;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace DDLPrototype.Demos
//{
//    public class PanelDemo : Layout
//    {
//        public PanelDemo(Form form) : base(form)
//        {
//            StackPanel stackPanel = new StackPanel();
//            stackPanel.HorizontalAlignment = Structs.HorizontalAlignment.Center;

//            TextBlock textBlock1 = new TextBlock("The quick");
//            TextBlock textBlock2 = new TextBlock("brown fox");
//            TextBlock textBlock3 = new TextBlock("lazy dog");

//            StackPanel stackPanel2 = new StackPanel
//            {
//                Horizontal = true,
//                Margin = new Thickness
//                {
//                    top = 50,
//                    bottom = 30,
//                    left = 50,
//                    right = 50
//                },
//                Padding = new Thickness
//                {
//                    right = 30,
//                    left = 30
//                }
//            };

//            TextBlock textBlock4 = new TextBlock("Inside");
//            textBlock4.Font = new Font(textBlock4.Font.FontFamily, 45);

//            TextBlock textBlock5 = new TextBlock("Horizontal")
//            {
//                Margin = new Thickness
//                {
//                    left = 100,
//                    right = 50,
//                    top = 15,
//                    bottom = 2
//                },
//                Padding = new Thickness
//                {
//                    left = 20,
//                    right = 20,
//                    top = 20,
//                    bottom = 20
//                },
//                Font = new Font("Georgia", 30),
//                FontColor = Color.White
//            };

//            TextBlock textBlock6 = new TextBlock("Panel")
//            {
//                Margin = new Thickness
//                {
//                    top = 20
//                }
//            };

//            stackPanel2.Children.Add(textBlock4);
//            stackPanel2.Children.Add(textBlock5);
//            stackPanel2.Children.Add(textBlock6);


//            stackPanel.Children.Add(textBlock1);
//            stackPanel.Children.Add(textBlock2);
//            stackPanel.Children.Add(stackPanel2);
//            stackPanel.Children.Add(textBlock3);

//            Shapes.Rectangle rectangle = new Shapes.Rectangle
//            {
//                Fill = Color.Teal
//            };

//            this.Grid.Children.Add(rectangle);
//            this.Grid.Children.Add(stackPanel);

//            this.Grid.ShowLayoutRectangles = true;

//            this.LayOut();
//            this.Arrange();
//        }
//    }
//}
