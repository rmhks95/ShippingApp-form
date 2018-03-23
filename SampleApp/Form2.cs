using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetShipping.SampleApp
{
    public partial class addVal : Form
    {
        public char res;

        public addVal()
        {
            InitializeComponent();
        }
        

        private void check_button_Click(object sender, EventArgs e)
        {
            string business = DotNetShipping.AddressValidation.Main(add1_box.Text, add2_box.Text, city_box.Text, state_box.Text, zip_box.Text);



            if (res == 'Y' || res == 'N') { ClearTextBoxes(); }
            
        }

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

    }
}
