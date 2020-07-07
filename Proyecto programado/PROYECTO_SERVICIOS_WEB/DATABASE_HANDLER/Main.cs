using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DATABASE_HANDLER
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button_probar_conexion_Click(object sender, EventArgs e)
        {
            Tareas.crear_admin_maestro();
        }
    }
}
