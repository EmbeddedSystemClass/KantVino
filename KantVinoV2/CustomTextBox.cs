using System;
using System.Windows.Forms;

namespace KantVinoV2
{
    public partial class CustomTextBox : TextBox
    {
            public event EventHandler TextEndEdit;
            private Timer _timer;

            public CustomTextBox()
            {
                _timer = new Timer();
                _timer.Interval = 1000;
                _timer.Tick += timer_Tick;
                this.TextChanged += txt_TextChanged;
            }
            private void txt_TextChanged(object sender, EventArgs e)
            {
                _timer.Stop();
                _timer.Start();
            }
            private void timer_Tick(object sender, EventArgs e)
            {
                _timer.Stop();
                if (TextEndEdit != null) TextEndEdit(this, new EventArgs());
            }
    }
}
