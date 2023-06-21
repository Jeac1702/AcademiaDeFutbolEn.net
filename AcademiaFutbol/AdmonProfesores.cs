using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcademiaFutbol.Clases;

namespace AcademiaFutbol
{
    public partial class AdmonProfesores : Form
    {
        private string rol;
        public AdmonProfesores()
        {
            InitializeComponent();
        }


        private void activarBotones()
        {
            btnModificar.Visible = true;
            btnEliminar.Visible = true;
            btnAgregarUsuario.Visible = true;
            btnAceptar.Visible = false;
            btnCancelar.Visible = false;

            txtNombre.ReadOnly = true;
            txtDirección.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtFechaNacimiento.Enabled = false;
            txtNSS.ReadOnly = true;
            txtRFC.ReadOnly = true;
            txtCURP.ReadOnly = true;
            txtLugarNacimiento.ReadOnly = true;

        }


        private void desactivarBotones()
        {
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
            btnAgregarUsuario.Visible = false;
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;

            txtNombre.ReadOnly = false;
            txtDirección.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtFechaNacimiento.Enabled = true;

            txtNSS.ReadOnly = false;
            txtRFC.ReadOnly = false;
            txtCURP.ReadOnly = false;
            txtLugarNacimiento.ReadOnly = false;
        }

        private void RecargaTodo()
        {
            this.Name = "";
            this.Email = "";
            this.address = "";
            this.phone = "";
            this.rfc = "";
            this.curp = "";
            this.nss = "";
            this.birthPlace = "";
            this.birthDate = DateTime.Now;
            this.coachid = 0;

            txtBuscarUsuario.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            txtFechaNacimiento.Text = "";
            txtDirección.Text = "";
            txtCURP.Text = "";
            txtNSS.Text = "";
            txtLugarNacimiento.Text = "";
            txtRFC.Text = "";
            activarBotones();

            try
            {
                Conexion conObj = new Conexion();
                string query = "SELECT * FROM Profesores";
                if (conObj.queryAdapter(query) != null)
                {
                    grdProfesores.Columns.Clear();
                    grdProfesores.DataSource = null;
                    grdProfesores.DataSource = conObj.queryAdapter(query);
                    lblCantidadRegistros.Text = "Cantidad de Registros: " + grdProfesores.Rows.Count;
                }
                else
                {
                    MessageBox.Show("No hay registros en la tabla Profesores", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            RecargaTodo();                              
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string coachName = txtBuscarUsuario.Text;
            if (coachName != "")
            {
                try
                {
                    Conexion conObj = new Conexion();
                    string query = "SELECT * FROM Profesores WHERE Name LIKE '%"+ coachName + "%'";
                    if(conObj.queryAdapter(query) != null)
                    {
                        grdProfesores.Columns.Clear();
                        grdProfesores.DataSource = null;
                        grdProfesores.DataSource = conObj.queryAdapter(query);
                    }
                    else
                    {
                        MessageBox.Show("Registro no encontrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor de llenar la caja de texto para buscar un Profesor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void setCurrentRol(string rol)
        {
            this.rol = rol;
        }

        private void AdmonUsuarios_Load(object sender, EventArgs e)
        {

        }

        private int coachid = 0;
        private string Name = "";
        private string Email = "";
        private string address = "";
        private DateTime birthDate = DateTime.Now;
        private string phone = "";
        private string nss = "";
        private string curp = "";
        private string rfc = "";
        private string birthPlace = "";
        private void grdUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdProfesores.DataSource != null)
                {
                    this.coachid = Convert.ToInt32(grdProfesores.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.Name = grdProfesores.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.curp = grdProfesores.Rows[e.RowIndex].Cells[2].Value.ToString();
                    this.Email = grdProfesores.Rows[e.RowIndex].Cells[4].Value.ToString();
                    this.address = grdProfesores.Rows[e.RowIndex].Cells[6].Value.ToString();
                    this.phone = grdProfesores.Rows[e.RowIndex].Cells[5].Value.ToString();
                    this.birthDate = Convert.ToDateTime(grdProfesores.Rows[e.RowIndex].Cells[3].Value.ToString());
                    this.rfc = grdProfesores.Rows[e.RowIndex].Cells[7].Value.ToString();
                    this.nss = grdProfesores.Rows[e.RowIndex].Cells[8].Value.ToString();
                    this.birthPlace = grdProfesores.Rows[e.RowIndex].Cells[9].Value.ToString();

                    txtNombre.Text = this.Name;
                    txtEmail.Text = this.Email;
                    txtDirección.Text = this.address;
                    txtTelefono.Text = this.phone;
                    txtFechaNacimiento.Value = this.birthDate;
                    txtRFC.Text = this.rfc;
                    txtNSS.Text = this.nss;
                    txtLugarNacimiento.Text = this.birthPlace;
                    txtCURP.Text = this.curp;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdProfesores.DataSource != null)
                {
                    this.coachid = Convert.ToInt32(grdProfesores.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.Name = grdProfesores.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.curp = grdProfesores.Rows[e.RowIndex].Cells[2].Value.ToString();
                    this.Email = grdProfesores.Rows[e.RowIndex].Cells[4].Value.ToString();
                    this.address = grdProfesores.Rows[e.RowIndex].Cells[6].Value.ToString();
                    this.phone = grdProfesores.Rows[e.RowIndex].Cells[5].Value.ToString();
                    this.birthDate = Convert.ToDateTime(grdProfesores.Rows[e.RowIndex].Cells[3].Value.ToString());
                    this.rfc = grdProfesores.Rows[e.RowIndex].Cells[7].Value.ToString();
                    this.nss = grdProfesores.Rows[e.RowIndex].Cells[8].Value.ToString();
                    this.birthPlace = grdProfesores.Rows[e.RowIndex].Cells[9].Value.ToString();

                    txtNombre.Text = this.Name;
                    txtEmail.Text = this.Email;
                    txtDirección.Text = this.address;
                    txtTelefono.Text = this.phone;
                    txtFechaNacimiento.Value = this.birthDate;
                    txtRFC.Text = this.rfc;
                    txtNSS.Text = this.nss;
                    txtLugarNacimiento.Text = this.birthPlace;
                    txtCURP.Text = this.curp;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void updateProfesores(int pcoachid, string pName, string pEmail, string pAddress, string pPhone, DateTime pBirthDate, string pbirthPlace, string pcurp, string pnss, string prfc)
        {
            try
            {
                Conexion conObj = new Conexion();
                string query = "UPDATE Profesores SET Name = '"+ pName + "', Email = '"+ pEmail + "', Address = '"+ pAddress + "', Phone = '"+pPhone+"', BirthDate = '"+ pBirthDate.ToString("yyyy-MM-dd") + "', BirthPlace = '"+pbirthPlace+"', NSS = '"+pnss+"', CURP = '"+pcurp+"', RFC = '"+prfc+"' WHERE coachid = "+pcoachid;
                int regs = 0;
                conObj.nonQueryAdapter(query,out regs);
                if (regs > 0)
                {
                    MessageBox.Show("Se afectaron "+regs+" registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("No se realizaron modificaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiar();
            }
        }
        private bool seModifica = false;
        private bool seInserta = false;
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(this.coachid != 0)
            {
                seModifica = true;
                desactivarBotones();
            }
            else 
            {
                MessageBox.Show("Seleccione un Profesor antes de modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            if (seModifica)
            {
                DialogResult resp = MessageBox.Show("¿Estas seguro de realizar modificar el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resp == DialogResult.Yes)
                {
                    this.Name = txtNombre.Text;
                    this.Email = txtEmail.Text;
                    this.address = txtDirección.Text;
                    this.phone = txtTelefono.Text;
                    this.birthDate = txtFechaNacimiento.Value;
                    this.birthPlace = txtLugarNacimiento.Text;
                    this.rfc = txtRFC.Text;
                    this.nss = txtNSS.Text;
                    this.curp = txtCURP.Text;
                    updateProfesores(this.coachid, this.Name, this.Email, this.address, this.phone, this.birthDate, this.birthPlace, this.curp, this.nss, this.rfc);
                    seModifica = false;
                }                         
            }

            if (seInserta)
            {
                DialogResult resp = MessageBox.Show("¿Estas seguro de agregar el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resp == DialogResult.Yes)
                {
                    this.Name = txtNombre.Text;
                    this.Email = txtEmail.Text;
                    this.address = txtDirección.Text;
                    this.phone = txtTelefono.Text;
                    this.birthDate = txtFechaNacimiento.Value;
                    this.birthPlace = txtLugarNacimiento.Text;
                    this.rfc = txtRFC.Text;
                    this.nss = txtNSS.Text;
                    this.curp = txtCURP.Text;
                    addProfesores(this.Name, this.Email, this.address, this.phone, this.birthDate, this.birthPlace, this.curp, this.nss, this.rfc);
                    seInserta = false;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            this.Name = "";
            this.Email = "";
            this.address = "";
            this.phone = "";
            this.birthDate = DateTime.Now;
            this.rfc = "";
            this.curp = "";
            this.nss = "";
            this.birthPlace = "";
            this.coachid = 0;
            grdProfesores.DataSource = null;
            txtBuscarUsuario.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDirección.Text = "";
            txtFechaNacimiento.Text = "";
            txtCURP.Text = "";
            txtNSS.Text = "";
            txtLugarNacimiento.Text = "";
            txtRFC.Text = "";
            seModifica = false;
            seInserta = false;
            lblCantidadRegistros.Text = "Cantidad de Registros: " + 0;
            activarBotones();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (seModifica)
            {
                DialogResult resp = MessageBox.Show("¿Estas seguro que deseas cancelar la modificación?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resp == DialogResult.Yes)
                {
                    limpiar();
                }
            }

            if (seInserta)
            {
                DialogResult resp = MessageBox.Show("¿Estas seguro que deseas cancelar la operación?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resp == DialogResult.Yes)
                {
                    limpiar();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.coachid != 0)
            {
                DialogResult resp = MessageBox.Show("¿Estas seguro que deseas Eliminar al Profesor "+this.Name+"?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resp == DialogResult.Yes)
                {
                    deleteUser(this.coachid);
                }
            } 
            else
            {
                MessageBox.Show("Seleccione un Profesor antes de eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteUser(int pcoachid)
        {
            try
            {
                Conexion conObj = new Conexion();
                string query = "DELETE FROM Profesores WHERE coachid = " + pcoachid;
                int regs = 0;
                conObj.nonQueryAdapter(query, out regs);
                if (regs > 0)
                {
                    MessageBox.Show("Se eliminaron " + regs + " registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("No se eliminaron registros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiar();
            }
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            seInserta = true;
            txtNombre.Text = "";
            txtFechaNacimiento.Value = DateTime.Now;
            txtDirección.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtCURP.Text = "";
            txtNSS.Text = "";
            txtLugarNacimiento.Text = "";
            txtRFC.Text = "";
            desactivarBotones();
        }

        private void addProfesores(string pName, string pEmail, string pAddress, string pPhone, DateTime pbirthDate, string pbirthPlace, string pcurp, string pnss, string prfc)
        {
            try
            {
                Conexion conObj = new Conexion();
                string query = "INSERT INTO Profesores (Name, Email, Address, Phone, birthDate, birthPlace, Curp, Nss, Rfc) VALUES('" + pName + "','" + pEmail + "','" + pAddress + "', '"+pPhone+"', '"+ pbirthDate.ToString("yyyy-MM-dd") + "', '"+pbirthPlace+"', '"+pcurp+"', '"+pnss+"', '"+prfc+"')";
                int regs = 0;
                conObj.nonQueryAdapter(query, out regs);
                if (regs > 0)
                {
                    MessageBox.Show("Se agregaron " + regs + " registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("No se realizaró el alta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiar();
            }
        }
    }
}
