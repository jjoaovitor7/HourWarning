namespace App
{
    using System;
    using Gtk;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    class HourWarning : Window
    {

        public static async Task SetInterval(System.Action action, TimeSpan timeout)
        {
            await Task.Delay(timeout).ConfigureAwait(false);

            action();

            await SetInterval(action, timeout);
        }

        async void showAtOneHour(Gtk.Label label)
        {
            int time = 3600;
            await SetInterval(() =>
            {
                if (time > 0)
                {
                    label.Text = Convert.ToString(time, 10);
                    time -= 1;
                }
                else
                {
                    MessageBox.Show("Tá na hora de descansar um pouco ,_,");
                    Thread.Sleep(-1);
                }
            }, TimeSpan.FromSeconds(1));
        }

        public HourWarning() : base("HourWarning")
        {
            SetDefaultSize(250, 250);
            SetPosition(WindowPosition.Center);

            VBox box = new VBox(true, 0);

            Gtk.Label title = new Gtk.Label("Hour Warning");
            Gtk.Label seconds = new Gtk.Label("0");

            Gtk.Button btnStart = new Gtk.Button("START");
            btnStart.Clicked += (obj, evt) => showAtOneHour(seconds);

            box.Add(title);
            box.Add(seconds);
            box.Add(btnStart);

            DeleteEvent += delegate
            {
                Gtk.Application.Quit();
            };

            Add(box);
            ShowAll();
        }

        public static void Main()
        {
            Gtk.Application.Init();
            new HourWarning();
            Gtk.Application.Run();
        }
    }
}