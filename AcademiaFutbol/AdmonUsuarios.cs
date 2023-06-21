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
    public partial class AdmonUsuarios : Form
    {
        private string rol;
        public AdmonUsuarios()
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
            txtPassword.ReadOnly = true;
            txtFechaCreacion.ReadOnly = true;
            txtEmail.ReadOnly = true;
            cboRol.Enabled = false;
        }


        private void desactivarBotones()
        {
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
            btnAgregarUsuario.Visible = false;
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;

            txtNombre.ReadOnly = false;
            txtPassword.ReadOnly = false;
            txtFechaCreacion.ReadOnly = true;
            txtEmail.ReadOnly = false;
            cboRol.Enabled = true;
        }

        private void RecargaTodo()
        {
            this.rolUser = 0;
            this.Name = "";
            this.Email = "";
            this.password = "";
            this.createdDate = DateTime.Now;
            this.userid = 0;

            txtBuscarUsuario.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            cboRol.Text = "";
            txtPassword.Text = "";
            txtPassword.PasswordChar = '*';
            txtFechaCreacion.Text = "";
            btnVerOcultar.Text = "Ver";
            activarBotones();

            try
            {
                Conexion conObj = new Conexion();
                string query = "SELECT * FROM Usuarios";
                if (conObj.queryAdapter(query) != null)
                {
                    grdUsuarios.Columns.Clear();
                    grdUsuarios.DataSource = null;
                    grdUsuarios.DataSource = conObj.queryAdapter(query);
                    lblCantidadRegistros.Text = "Cantidad de Registros: " + grdUsuarios.Rows.Count;
                }
                else
                {
                    MessageBox.Show("No hay registros en la tabla Usuarios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string userName = txtBuscarUsuario.Text;
            if ( userName != "")
            {
                try
                {
                    Conexion conObj = new Conexion();
                    string query = "SELECT * FROM Usuarios WHERE Name LIKE '%"+userName+"%'";
                    if(conObj.queryAdapter(query) != null)
                    {
                        grdUsuarios.Columns.Clear();
                        grdUsuarios.DataSource = null;
                        grdUsuarios.DataSource = conObj.queryAdapter(query);
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
                MessageBox.Show("Favor de llenar la caja de texto para buscar un usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerOcultar_Click(object sender, EventArgs e)
        {
            if(btnVerOcultar.Text == "Ver")
            {
                btnVerOcultar.Text = "Ocultar";
                txtPassword.PasswordChar = '\0'; //'\u0000'
            } else
            {
                btnVerOcultar.Text = "Ver";
                txtPassword.PasswordChar = '*';
            }
        }

        public void setCurrentRol(string rol)
        {
            this.rol = rol;
        }

        private void AdmonUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                Conexion conObj = new Conexion();
                string query = "SELECT * FROM Roles";
                if (conObj.queryAdapter(query) != null)
                {
                    cboRol.ValueMember = "RoleId";
                    cboRol.DisplayMember = "Name";
                    cboRol.DataSource = conObj.queryAdapter(query);                
                }
                else
                {
                    MessageBox.Show("No hay registros en el catalogo de Roles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int userid = 0;
        private string Name = "";
        private string Email = "";
        private string password = "";
        private DateTime createdDate = DateTime.Now;
        private int rolUser = 0;
        private void grdUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdUsuarios.DataSource != null)
                {
                    this.userid = Convert.ToInt32(grdUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.Name = grdUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.Email = grdUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
                    this.password = grdUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
                    this.createdDate = Convert.ToDateTime(grdUsuarios.Rows[e.RowIndex].Cells[4].Value.ToString());
                    this.rolUser = Convert.ToInt32(grdUsuarios.Rows[e.RowIndex].Cells[5].Value.ToString());

                    txtNombre.Text = this.Name;
                    txtEmail.Text = this.Email;
                    txtPassword.Text = this.password;
                    txtFechaCreacion.Text = this.createdDate.ToString();
                    cboRol.SelectedValue = this.rolUser;
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
                if (grdUsuarios.DataSource != null)
                {
                    this.userid = Convert.ToInt32(grdUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.Name = grdUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.Email = grdUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
                    this.password = grdUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
                    this.createdDate = Convert.ToDateTime(grdUsuarios.Rows[e.RowIndex].Cells[4].Value.ToString());
                    this.rolUser = Convert.ToInt32(grdUsuarios.Rows[e.RowIndex].Cells[5].Value.ToString());

                    txtNombre.Text = this.Name;
                    txtEmail.Text = this.Email;
                    txtPassword.Text = this.password;
                    txtFechaCreacion.Text = this.createdDate.ToString();
                    cboRol.SelectedValue = this.rolUser;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        public void updateUsuarios(int puserId, string pname, string pemail, string ppassword, int prol)
        {
            try
            {
                Conexion conObj = new Conexion();
                string query = "UPDATE Usuarios SET Name = '"+ pname + "', Email = '"+pemail+"', Password = '"+ppassword+"', Role = "+prol+" WHERE UserId = "+puserId;
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
            if(this.userid != 0)
            {
                seModifica = true;
                desactivarBotones();
            }
            else 
            {
                MessageBox.Show("Seleccione un usuario antes de modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    this.password = txtPassword.Text;
                    this.rolUser = Convert.ToInt32(cboRol.SelectedValue.ToString());
                    updateUsuarios(this.userid, this.Name, this.Email, this.password, this.rolUser);
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
                    this.password = txtPassword.Text;
                    this.createdDate = Convert.ToDateTime(txtFechaCreacion.Text);
                    this.rolUser = Convert.ToInt32(cboRol.SelectedValue.ToString());
                   addUsuarios(this.userid, this.Name, this.Email, this.password, this.createdDate, this.rolUser);
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
            this.rolUser = 0;
            this.Name = "";
            this.Email = "";
            this.password = "";
            this.createdDate = DateTime.Now;
            this.userid = 0;
            grdUsuarios.DataSource = null;
            txtBuscarUsuario.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            cboRol.Text = "";
            txtPassword.Text = "";
            txtPassword.PasswordChar = '*';
            txtFechaCreacion.Text = "";
            btnVerOcultar.Text = "Ver";
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
            if (this.userid != 0)
            {
                DialogResult resp = MessageBox.Show("¿Estas seguro que deseas Eliminar al usuario "+this.Name+"?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resp == DialogResult.Yes)
                {
                    deleteUser(this.userid);
                }
            } 
            else
            {
                MessageBox.Show("Seleccione un usuario antes de eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteUser(int puserId)
        {
            try
            {
                Conexion conObj = new Conexion();
                string query = "DELETE FROM Usuarios WHERE UserId = " + puserId;
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
            txtFechaCreacion.Text = DateTime.Now.ToString();
            txtPassword.Text = "";
            txtPassword.PasswordChar = '*';
            txtEmail.Text = "";
            cboRol.SelectedIndex = 0;
            desactivarBotones();
        }

        private void addUsuarios(int puserid, string pName, string pEmail, string ppassword, DateTime pcreatedDate, int prolUser)
        {
            try
            {
                Conexion conObj = new Conexion();
                string query = "INSERT INTO Usuarios (Name, Email, Password, CreatedDate, Role) VALUES('" + pName + "','" + pEmail + "','" + ppassword + "', GETDATE(), " + prolUser + ")";
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
