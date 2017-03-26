using crowdlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
        public MainWindow()
        {
            InitializeComponent();
            //
            timer.Tick += Timer_Tick_Drawer;
            timer.Interval = TimeSpan.FromMilliseconds(20) ;
            timer.Start();
        }

        private void Timer_Tick_Drawer(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            r.DrawCells(canvas1, world.Cells);
        }

        World world = new World();
        Renderer r = new Renderer();
        DispatcherTimer timer = new DispatcherTimer();

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                world = new World();
        }
    }
}
