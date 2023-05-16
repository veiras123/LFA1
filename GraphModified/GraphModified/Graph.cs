using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphModified
{
    class Graph
    {
        public ObservableCollection<Node> Nodes { get; private set; }
        public ObservableCollection<Edge> Edges { get; private set; }

        private int nextIndex;


        public Graph()
        {
            this.Nodes = new ObservableCollection<Node>();
            this.Edges = new ObservableCollection<Edge>();
            this.nextIndex = 1;
        }

        public Node AddNode(double x, double y)
        {
            Node node = new Node(nextIndex, x, y);
            this.Nodes.Add(node);
            nextIndex++;
            return node;
        }

        public void AddEdge(Node startNode, Node endNode)
        {
            this.Edges.Add(new Edge(startNode, endNode));
        }
    }
    public class Edge : DependencyObject
    {


        public Node StartNode
        {
            get { return (Node)GetValue(StartNodeProperty); }
            set { SetValue(StartNodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartNode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartNodeProperty =
            DependencyProperty.Register("StartNode", typeof(Node), typeof(Edge), new PropertyMetadata(null));



        public Node EndNode
        {
            get { return (Node)GetValue(EndNodeProperty); }
            set { SetValue(EndNodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EndNode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EndNodeProperty =
            DependencyProperty.Register("EndNode", typeof(Node), typeof(Edge), new PropertyMetadata(null));

        public Edge(Node startNode, Node endNode)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
        }
    }

    public class Node : DependencyObject
    {


        public int Index
        {
            get { return (int)GetValue(IndexProperty); }
            set { SetValue(IndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Index.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.Register("Index", typeof(int), typeof(Node), new PropertyMetadata(0));



        public double X
        {
            get { return (double)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        // Using a DependencyProperty as the backing store for X.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(double), typeof(Node), new PropertyMetadata(0.0));



        public double Y
        {
            get { return (double)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Y.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(double), typeof(Node), new PropertyMetadata(0.0));


        public double CenterX
        {
            get { return (double)GetValue(CenterXProperty); }
            set { SetValue(CenterXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CenterX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CenterXProperty =
            DependencyProperty.Register("CenterX", typeof(double), typeof(Node), new PropertyMetadata(0.0));



        public double CenterY
        {
            get { return (double)GetValue(CenterYProperty); }
            set { SetValue(CenterYProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CenterY.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CenterYProperty =
            DependencyProperty.Register("CenterY", typeof(double), typeof(Node), new PropertyMetadata(0.0));



        public double Size
        {
            get { return (double)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Size.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(double), typeof(Node), new PropertyMetadata(0.0));





        public Node(int index, double centerX, double centerY)
        {
            this.Index = index;
            this.CenterX = centerX;
            this.CenterY = centerY;
            this.Size = 50;
            this.X = this.CenterX - this.Size / 2;
            this.Y = this.CenterY - this.Size / 2;
        }
    }
}
