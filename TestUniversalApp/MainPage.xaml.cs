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
        Random _rand = new Random(DateTime.Now.Millisecond);

        public MainPage()
        {
            try
            {
                this.InitializeComponent();
                // Task
                // Better: Create and start the task in one operation. 
                Task taskA = Task.Factory.StartNew(() =>
                                                        RandomDisplayAsync()
                                                        );


                //taskA.Start();//.Wait();
            }
            catch (Exception ex)
            {
                //TODO
            }
          
        }

        private async Task RandomDisplayAsync()
        {
            try
            {
                while (true)
                {
                    await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync
                        (CoreDispatcherPriority.Normal,
                        () =>
                                {
                                    // Your UI update code goes here!
                                    ChangeColour(r1);
                                    ChangeColour(r2);
                                    ChangeColour(r3);
                                    ChangeColour(r4);
                                    ChangeColour(r5);
                                    ChangeColour(r6);
                                    ChangeColour(r7);
                                    ChangeColour(r8);
                                    ChangeColour(r9);
                                }
                        );
                    System.Threading.Tasks.Task.Delay(100).Wait();
                };
            }
            catch (Exception ex)
            {
                //TODO
            }
        }

        private void ChangeColour(Rectangle rectControl)
        {
            int n1 = _rand.Next(0, 255);
            int n2= _rand.Next(0, 255);
            int n3 = _rand.Next(0, 255);
            int n4 = _rand.Next(0, 255);

            byte a = byte.Parse(n1.ToString());
            byte r = byte.Parse(n2.ToString());
            byte g = byte.Parse(n3.ToString());
            byte b = byte.Parse(n4.ToString());

            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            // Describes the brush's color using RGB values. 
            // Each value has a range of 0-255.
            mySolidColorBrush.Color = Color.FromArgb(a, r, g, b);


            rectControl.Fill = mySolidColorBrush;
        }
    }
}
