using System;
using System.Collections.Generic;
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

namespace GraphModified
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Graph graph;
        private Canvas canvasNodes;

        public MainWindow()
        {
            InitializeComponent();

            graph = new Graph();

            ListBoxNodes.ItemsSource = graph.Nodes;
            listBoxEdges.ItemsSource = graph.Edges;

        }

        private void CanvasNodes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {

                if (canvasNodes != null)
                {
                    Point point = e.GetPosition(canvasNodes);
                    graph.AddNode(point.X, point.Y);
                }
            }
            catch
            {
                //not used
            }
        }

        private bool isDraggingNode = false;
        private Point? previousPoint = null;
        private Node firstNode = null;

        private void GridNode_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid grid = sender as Grid;

            if (grid != null)
            {
                grid.CaptureMouse();


                if (radioAddNode.IsChecked == true)
                {
                    isDraggingNode = true;
                    previousPoint = e.GetPosition(canvasNodes);
                }
                if (radioAddEdge.IsChecked == true)
                {
                    Node currentNode = null;
                    currentNode = grid.DataContext as Node;

                    if (firstNode == null)
                    {
                        firstNode = currentNode;
                    }
                    else
                    {
                        graph.AddEdge(firstNode, currentNode);
                        firstNode = null;
                    }
                }


                if (radioDelete.IsChecked == true)
                {
                   
                    Point currentPoint = e.GetPosition(canvasNodes);
                    
                    HitTestResult result = VisualTreeHelper.HitTest(canvasNodes, currentPoint);
                    if (result != null)
                    {
                        canvasNodes.Children.Remove(result.VisualHit as UIElement);
                    }
                }


            }
        }

        private void GridNode_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraggingNode)
            {
                Grid element = sender as Grid;
                if (element != null)
                {
                    Node node = element.DataContext as Node;
                    if (node != null && previousPoint.HasValue)
                    {
                        Point point = e.GetPosition(canvasNodes);

                        double xDiff = point.X - previousPoint.Value.X;
                        double yDiff = point.Y - previousPoint.Value.Y;

                        node.X += xDiff;
                        node.Y += yDiff;
                        node.CenterX += xDiff;
                        node.CenterY += yDiff;

                        previousPoint = point;
                    }
                }
            }
        }

        private void GridNode_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Grid grid = sender as Grid;
            if (grid != null)
            {
                grid.ReleaseMouseCapture();
                isDraggingNode = false;
                previousPoint = null;
            }
        }

        private void CanvasNodes_Loaded(object sender, RoutedEventArgs e)
        {
            canvasNodes = sender as Canvas;
        }
    }
}
