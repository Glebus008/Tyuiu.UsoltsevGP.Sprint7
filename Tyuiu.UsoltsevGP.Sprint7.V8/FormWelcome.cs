using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Tyuiu.UsoltsevGP.Sprint7.V8
{
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            InitializeComponent();
            // Привязываем обработчик, если в дизайнере он не привязан
            button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            this.Hide();
            formMain.ShowDialog();
            this.Close(); // после закрытия FormMain закроется и FormWelcome
        }

        private void FormWelcome_Load(object sender, EventArgs e)
        {

        }
    }
}
