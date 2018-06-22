using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestUniversalApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int _updateUIwaitInMs = 50;
        Random _rand = new Random(DateTime.Now.Millisecond);
        int _numberOfRectangleInRow = 100;
        int _numberOfRectangleInCol = 140;

        public MainPage()
        {
            try
            {
                this.InitializeComponent();
                FillGrid();
                // Task Start a background task
                Task taskA = Task.Factory.StartNew(() =>
                                                        RandomDisplayAsync()
                                                        );

            }
            catch (Exception ex)
            {
                //TODO
            }
        }

        private void FillGrid()
        {
            //Adding rectangle in grid
            for (int index = 0; index < _numberOfRectangleInRow; index++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(1, GridUnitType.Star);
                gMain.RowDefinitions.Add(row);
            }

            for (int index = 0; index < _numberOfRectangleInCol; index++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = new GridLength(1, GridUnitType.Star);
                gMain.ColumnDefinitions.Add(col);
            }

            for (int r = 0; r < _numberOfRectangleInRow; r++)
            {
                for (int c = 0; c < _numberOfRectangleInCol; c++)
                {
                    Rectangle rect = new Rectangle();
                    Grid.SetColumn(rect, c);
                    Grid.SetRow(rect, r);
                    ChangeColour(rect, true);
                    gMain.Children.Add(rect);
                }
            }
        }

        private async Task RandomDisplayAsync()
        {
            try
            {   //TODO
                while (true)
                {
                    //Update UI in UI thread
                    await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync
                        (CoreDispatcherPriority.Normal,
                        () =>
                                {
                                    // Your UI update code goes here!
                                    //ChangeColour(r1);
                                    //ChangeColour(r2);
                                    //ChangeColour(r3);
                                    //ChangeColour(r4);
                                    //ChangeColour(r5);
                                    //ChangeColour(r6);
                                    //ChangeColour(r7);
                                    //ChangeColour(r8);
                                    //ChangeColour(r9);

                                    RandomDisplay();
                                }
                        );
                    System.Threading.Tasks.Task.Delay(_updateUIwaitInMs).Wait();
                };
            }
            catch (Exception ex)
            {
                //TODO
            }
        }

        private void RandomDisplay()
        {
            try
            {
                int index = _rand.Next(0, _numberOfRectangleInRow * _numberOfRectangleInCol - 1);

                if (index < gMain.Children.Count)
                {
                    Rectangle rect = gMain.Children[index] as Rectangle;
                    if (rect != null)
                    {
                        ChangeColour(rect,false);
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO
            }
        }

        private void ChangeColour(Rectangle rectControl, bool changeOnlyTransparency)
        {
            int n1 = _rand.Next(0, 255);
           

            byte a = byte.Parse(n1.ToString());
         
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            // Describes the brush's color using RGB values. 
            // Each value has a range of 0-255.
            if (changeOnlyTransparency)
            {
                mySolidColorBrush.Color = Color.FromArgb(a, 100, 100, 100);
            }
            else
            {
                int n2 = _rand.Next(0, 255);
                int n3 = _rand.Next(0, 255);
                int n4 = _rand.Next(0, 255);
                byte r = byte.Parse(n2.ToString());
                byte g = byte.Parse(n3.ToString());
                byte b = byte.Parse(n4.ToString());

                mySolidColorBrush.Color = Color.FromArgb(a, r, g, b);
            }
            
            //mySolidColorBrush.Color = Color.FromArgb(a, 100, 100, 100);

            rectControl.Fill = mySolidColorBrush;
        }
    }
}
