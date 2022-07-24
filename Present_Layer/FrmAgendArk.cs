using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic_Layer;
using Entity_Layer;

namespace Present_Layer
{
    public partial class FrmAgendArk : Form
    {
        Tools_Contact tools = new Tools_Contact();
        private bool Edit = false;
        static Entity entity = new Entity();
        private string idContact = entity.IdContact;
       


        public FrmAgendArk()
        {
            InitializeComponent();
        }

        private void FrmAgendArk_Load(object sender, EventArgs e)
        {
            LoadDgv();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string genero_status = entity.Genero_status = cbxGenero.SelectedItem.ToString();
            string status_estCivil = entity.Status_estCivil = cbxEstado_c.SelectedItem.ToString();

            //To Create on Click Save
            if (Edit == false)
            {
                
                //string genero_status = cbxGenero.SelectedItem.ToString();
                //string status_estCivil = cbxEstado_c.SelectedItem.ToString();
                //Console.WriteLine(status_estCivil);

                if (tbxName.Text != "" && tbxLastname.Text != "" && tbxAdress.Text != "" && tbxPhone.Text != "" && tbxEmail.Text != "")
                {

                    try
                    {
                        tools.Create_Contact(tbxName.Text, tbxLastname.Text, dtpFechaN.Value, tbxAdress.Text, genero_status, status_estCivil, tbxPhone.Text, tbxEmail.Text);
                        MessageBox.Show("se creó correctamente");
                        LoadDgv();
                        ClearForm();

                    }
                    catch (Exception x)
                    {

                        MessageBox.Show("No se pudieron insertar los datos por:" + x);
                    }

                }
                else
                {
                    MessageBox.Show("Asegurese de llenar todos los campos correctamente");
                };
            }

            //To Edit on Click Save
            if (Edit == true)
            {
                try
                {
                    tools.Edit_Contact(tbxName.Text, tbxLastname.Text, dtpFechaN.Value, tbxAdress.Text, genero_status/*Value to comboboxes*/, status_estCivil, tbxPhone.Text, tbxEmail.Text, idContact);
                    MessageBox.Show("Se editó correctamente");
                    Edit = false;
                    LoadDgv();
                    ClearForm();
                }
                catch (Exception x)
                {
                    MessageBox.Show("No se pudo editar los datos correctamente por:" + x);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (DgvView.SelectedRows.Count > 0)
            {
                Edit = true;
                tbxName.Text = DgvView.CurrentRow.Cells["Nombre"].Value.ToString();
                tbxLastname.Text = DgvView.CurrentRow.Cells["Apellido"].Value.ToString();
                dtpFechaN.Text = DgvView.CurrentRow.Cells["Fecha_nacimiento"].Value.ToString();
                tbxAdress.Text = DgvView.CurrentRow.Cells["Direccion"].Value.ToString();
                cbxGenero.Text = DgvView.CurrentRow.Cells["Genero"].Value.ToString();
                cbxEstado_c.Text = DgvView.CurrentRow.Cells["Estado_civil"].Value.ToString();
                tbxPhone.Text = DgvView.CurrentRow.Cells["Telefono"].Value.ToString();
                tbxEmail.Text = DgvView.CurrentRow.Cells["Email"].Value.ToString();
                idContact = DgvView.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DgvView.SelectedRows.Count > 0)
            {
                idContact = DgvView.CurrentRow.Cells["Id"].Value.ToString();
                tools.Delete_Contact(idContact);
                MessageBox.Show("Se ha eliminado correctamente");
                LoadDgv();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila primero,\npor favor");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSearch(tbxSearch.Text);
        }



        //Methods

        //--//

        //Method to load the view in Data Grid view Component
        private void LoadDgv()
        {
            Tools_Contact tool = new Tools_Contact();
            DgvView.DataSource = tool.ViewAllContacts();
        }

        private void LoadSearch(string name)
        {
            Tools_Contact tool = new Tools_Contact();
            DgvView.DataSource = tool.SearchContact(name);
        }

        //Method to clear Frm
        private void ClearForm()
        {
            tbxName.Text = "";
            tbxLastname.Text = "";
            dtpFechaN.ResetText();
            tbxAdress.Text = "";
            //--//
            //cbxEstado_c.SelectedItem = null;
            //cbxGenero.SelectedItem = null;
            tbxPhone.Text = "";
            tbxEmail.Text = "";

        }
        //

    }
}

