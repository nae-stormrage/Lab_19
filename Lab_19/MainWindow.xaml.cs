using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_19
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int N = 10;

            try
            {
                N = Convert.ToInt32(FigureCount.Text);
            }
            catch
            {
                this.Title = "Только целое число!";
            }

            try
            {
                GenerateShapes(N);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void GenerateShapes(int N)
        {
            Random rndShapeType = new Random(DateTime.Now.Millisecond);
            Random rndStyle = new Random(DateTime.Now.Second);
            Random rndPosition = new Random(DateTime.Now.Minute);
            Random rndSize = new Random(DateTime.Now.Hour);
            Random rndX1 = new Random(DateTime.Now.Millisecond);
            Random rndX2 = new Random(DateTime.Now.Millisecond);
            Random rndY1 = new Random(DateTime.Now.Millisecond);
            Random rndY2 = new Random(DateTime.Now.Millisecond);


            for (int i = 0; i < N; i++)
            {
                Shape currentShape;
                int ShapeType = rndShapeType.Next(0, 3);

                if (ShapeType == 0)
                {
                    currentShape = new Ellipse();
                }
                else if (ShapeType == 1)
                {
                    currentShape = new Rectangle();
                }
                else 
                {
                    currentShape = new Line { X1 = rndX1.Next(5, 500), X2 = rndX2.Next(5, 500), Y1 = rndY1.Next(5, 250), Y2 = rndY2.Next(5, 250) };
                }
                

                int shapeStyle = rndStyle.Next(0, 4) + 1;
                String styleName = "style" + shapeStyle.ToString();
                Style currentStyle = (Style) this.FindResource(styleName);
                currentShape.Style = currentStyle;

                currentShape.Width = rndSize.Next(10, 200);
                currentShape.Height = rndSize.Next(10, 100);

                MainCanvas.Children.Add(currentShape);
                Canvas.SetLeft(currentShape, rndPosition.Next(5, 750));
                Canvas.SetTop(currentShape, rndPosition.Next(5, 400));
            }
        }
    }
}
