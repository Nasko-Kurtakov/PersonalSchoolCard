using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApplication1
{
    public partial class PersonalRecord : Form
    {
        public PersonalRecord()
        {
            InitializeComponent();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            Success sc = new Success();
            sc.Show();
        }

    }
}
