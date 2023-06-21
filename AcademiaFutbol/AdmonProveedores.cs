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
    public partial class AdmonProveedores : Form
    {
        private string rol;
        public AdmonProveedores()
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
        }

        private void RecargaTodo()
        {
            this.Name = "";
            this.Email = "";
            this.address = "";
            this.phone = "";
            this.providerid = 0;

            txtBuscarUsuario.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            txtDirección.Text = "";
            activarBotones();

            try
            {
                Conexion conObj = new Conexion();
                string query = "SELECT * FROM Proveedores";
                if (conObj.queryAdapter(query) != null)
                {
                    grdProveedores.Columns.Clear();
                    grdProveedores.DataSource = null;
                    grdProveedores.DataSource = conObj.queryAdapter(query);
                    lblCantidadRegistros.Text = "Cantidad de Registros: " + grdProveedores.Rows.Count;
                }
                else
                {
                    MessageBox.Show("No hay registros en la tabla Proveedores", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string parentName = txtBuscarUsuario.Text;
            if (parentName != "")
            {
                try
                {
                    Conexion conObj = new Conexion();
                    string query = "SELECT * FROM Proveedores WHERE Name LIKE '%"+ parentName + "%'";
                    if(conObj.queryAdapter(query) != null)
                    {
                        grdProveedores.Columns.Clear();
                        grdProveedores.DataSource = null;
                        grdProveedores.DataSource = conObj.queryAdapter(query);
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
                MessageBox.Show("Favor de llenar la caja de texto para buscar un Proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void setCurrentRol(string rol)
        {
            this.rol = rol;
        }

        private void AdmonUsuarios_Load(object sender, EventArgs e)
        {

        }

        private int providerid = 0;
        private string Name = "";
        private string Email = "";
        private string address = "";
        private string phone = "";
        private void grdUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdProveedores.DataSource != null)
                {
                    this.providerid = Convert.ToInt32(grdProveedores.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.Name = grdProveedores.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.Email = grdProveedores.Rows[e.RowIndex].Cells[4].Value.ToString();
                    this.address = grdProveedores.Rows[e.RowIndex].Cells[2].Value.ToString();
                    this.phone = grdProveedores.Rows[e.RowIndex].Cells[3].Value.ToString();

                    txtNombre.Text = this.Name;
                    txtEmail.Text = this.Email;
                    txtDirección.Text = this.address;
                    txtTelefono.Text = this.phone;
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
                if (grdProveedores.DataSource != null)
                {
                    this.providerid = Convert.ToInt32(grdProveedores.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.Name = grdProveedores.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.Email = grdProveedores.Rows[e.RowIndex].Cells[4].Value.ToString();
                    this.address = grdProveedores.Rows[e.RowIndex].Cells[2].Value.ToString();
                    this.phone = grdProveedores.Rows[e.RowIndex].Cells[3].Value.ToString();

                    txtNombre.Text = this.Name;
                    txtEmail.Text = this.Email;
                    txtDirección.Text = this.address;
                    txtTelefono.Text = this.phone;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void updateProveedores(int pproviderid, string pName, string pEmail, string pAddress, string pPhone)
        {
            try
            {
                Conexion conObj = new Conexion();
                string query = "UPDATE Proveedores SET Name = '"+ pName + "', Email = '"+ pEmail + "', Address = '"+ pAddress + "', Phone = '"+pPhone+"' WHERE providerid = "+pproviderid;
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
            if(this.providerid != 0)
            {
                seModifica = true;
                desactivarBotones();
            }
            else 
            {
                MessageBox.Show("Seleccione un Proveedor antes de modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    updateProveedores(this.providerid, this.Name, this.Email, this.address, this.phone);
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
                    addProveedores(this.Name, this.Email, this.address, this.phone);
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
            this.providerid = 0;
            grdProveedores.DataSource = null;
            txtBuscarUsuario.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDirección.Text = "";
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
            if (this.providerid != 0)
            {
                DialogResult resp = MessageBox.Show("¿Estas seguro que deseas Eliminar al Proveedor "+this.Name+"?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resp == DialogResult.Yes)
                {
                    deleteUser(this.providerid);
                }
            } 
            else
            {
                MessageBox.Show("Seleccione un Proveedor antes de eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteUser(int pproviderid)
        {
            try
            {
                Conexion conObj = new Conexion();
                string query = "DELETE FROM Proveedores WHERE providerid = " + pproviderid;
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
            txtDirección.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            desactivarBotones();
        }

        private void addProveedores(string pName, string pEmail, string pAddress, string pPhone)
        {
            try
            {
                Conexion conObj = new Conexion();
                string query = "INSERT INTO Proveedores (Name, Email, Address, Phone) VALUES('" + pName + "','" + pEmail + "','" + pAddress + "', '"+pPhone+"')";
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
