using crowdlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        World world;
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            //
            NumericUpDown nud = new NumericUpDown()
            {
                Increment = 1,
                Minimum = 1
            };
            WFH_nud.Child = nud;

            //
            timer.Tick += Timer_Tick_Drawer;
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Start();
        }

        private void Timer_Tick_Drawer(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            Renderer.DrawCanvas(canvas1, world.Cells, world.People);
        }
        private int PeopleToCreate { get { return int.Parse(WFH_nud.Child.Text); } }


        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                world = new World(PeopleToCreate);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            world = new World(PeopleToCreate);
        }
    }
}
