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
    public partial class AdmonAlumnos : Form
    {
        private string rol;
        public AdmonAlumnos()
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
            txtDiseases.ReadOnly = true;
            txtCURP.ReadOnly = true;
            txtLugarNacimiento.ReadOnly = true;
            cboPadre.Enabled = false;
            cboTipoSangre.Enabled = false;
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
            txtDiseases.ReadOnly = false;
            txtCURP.ReadOnly = false;
            txtLugarNacimiento.ReadOnly = false;
            cboPadre.Enabled = true;
            cboTipoSangre.Enabled = true;
        }

        private void RecargaTodo()
        {
            this.Name = "";
            this.Email = "";
            this.address = "";
            this.phone = "";
            this.diseases = "";
            this.curp = "";
            this.nss = "";
            this.birthPlace = "";
            this.birthDate = DateTime.Now;
            this.studentid = 0;
            this.bloodtype = "";
            this.parentid = 0;

            txtBuscarUsuario.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            txtFechaNacimiento.Text = "";
            txtDirección.Text = "";
            txtCURP.Text = "";
            txtNSS.Text = "";
            txtLugarNacimiento.Text = "";
            txtDiseases.Text = "";
            cboTipoSangre.SelectedIndex = 0;
            cboPadre.SelectedIndex = 0;
            activarBotones();

            try
            {
                Conexion conObj = new Conexion();
                string query = "SELECT * FROM Alumnos";
                if (conObj.queryAdapter(query) != null)
                {
                    grdAlumnos.Columns.Clear();
                    grdAlumnos.DataSource = null;
                    grdAlumnos.DataSource = conObj.queryAdapter(query);
                    lblCantidadRegistros.Text = "Cantidad de Registros: " + grdAlumnos.Rows.Count;
                }
                else
                {
                    MessageBox.Show("No hay registros en la tabla Alumnos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string studentName = txtBuscarUsuario.Text;
            if (studentName != "")
            {
                try
                {
                    Conexion conObj = new Conexion();
                    string query = "SELECT * FROM Alumnos WHERE Name LIKE '%"+ studentName + "%'";
                    if(conObj.queryAdapter(query) != null)
                    {
                        grdAlumnos.Columns.Clear();
                        grdAlumnos.DataSource = null;
                        grdAlumnos.DataSource = conObj.queryAdapter(query);
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
                MessageBox.Show("Favor de llenar la caja de texto para buscar un Alumno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string query = "SELECT * FROM Padres";
                if (conObj.queryAdapter(query) != null)
                {
                    cboPadre.ValueMember = "ParentId";
                    cboPadre.DisplayMember = "Name";
                    cboPadre.DataSource = conObj.queryAdapter(query);
                }
                else
                {
                    MessageBox.Show("No hay registros en el catalogo de Padres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int studentid = 0;
        private string Name = "";
        private string Email = "";
        private string address = "";
        private DateTime birthDate = DateTime.Now;
        private string phone = "";
        private string nss = "";
        private string curp = "";
        private string diseases = "";
        private string birthPlace = "";
        private int parentid = 0;
        private string bloodtype = "";
        private void grdUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdAlumnos.DataSource != null)
                {
                    this.studentid = Convert.ToInt32(grdAlumnos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.Name = grdAlumnos.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.curp = grdAlumnos.Rows[e.RowIndex].Cells[7].Value.ToString();
                    this.Email = grdAlumnos.Rows[e.RowIndex].Cells[5].Value.ToString();
                    this.address = grdAlumnos.Rows[e.RowIndex].Cells[11].Value.ToString();
                    this.phone = grdAlumnos.Rows[e.RowIndex].Cells[6].Value.ToString();
                    this.birthDate = Convert.ToDateTime(grdAlumnos.Rows[e.RowIndex].Cells[3].Value.ToString());
                    this.diseases = grdAlumnos.Rows[e.RowIndex].Cells[10].Value.ToString();
                    this.nss = grdAlumnos.Rows[e.RowIndex].Cells[8].Value.ToString();
                    this.birthPlace = grdAlumnos.Rows[e.RowIndex].Cells[4].Value.ToString();
                    this.bloodtype = grdAlumnos.Rows[e.RowIndex].Cells[9].Value.ToString();
                    this.parentid = Convert.ToInt32(grdAlumnos.Rows[e.RowIndex].Cells[2].Value.ToString());

                    txtNombre.Text = this.Name;
                    txtEmail.Text = this.Email;
                    txtDirección.Text = this.address;
                    txtTelefono.Text = this.phone;
                    txtFechaNacimiento.Value = this.birthDate;
                    txtDiseases.Text = this.diseases;
                    txtNSS.Text = this.nss;
                    txtLugarNacimiento.Text = this.birthPlace;
                    txtCURP.Text = this.curp;
                    cboPadre.SelectedValue = this.parentid;
                    cboTipoSangre.SelectedText = this.bloodtype;
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
                if (grdAlumnos.DataSource != null)
                {
                    this.studentid = Convert.ToInt32(grdAlumnos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.Name = grdAlumnos.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.curp = grdAlumnos.Rows[e.RowIndex].Cells[7].Value.ToString();
                    this.Email = grdAlumnos.Rows[e.RowIndex].Cells[5].Value.ToString();
                    this.address = grdAlumnos.Rows[e.RowIndex].Cells[11].Value.ToString();
                    this.phone = grdAlumnos.Rows[e.RowIndex].Cells[6].Value.ToString();
                    this.birthDate = Convert.ToDateTime(grdAlumnos.Rows[e.RowIndex].Cells[3].Value.ToString());
                    this.diseases = grdAlumnos.Rows[e.RowIndex].Cells[10].Value.ToString();
                    this.nss = grdAlumnos.Rows[e.RowIndex].Cells[8].Value.ToString();
                    this.birthPlace = grdAlumnos.Rows[e.RowIndex].Cells[4].Value.ToString();
                    this.bloodtype = grdAlumnos.Rows[e.RowIndex].Cells[9].Value.ToString();
                    this.parentid = Convert.ToInt32(grdAlumnos.Rows[e.RowIndex].Cells[2].Value.ToString());

                    txtNombre.Text = this.Name;
                    txtEmail.Text = this.Email;
                    txtDirección.Text = this.address;
                    txtTelefono.Text = this.phone;
                    txtFechaNacimiento.Value = this.birthDate;
                    txtDiseases.Text = this.diseases;
                    txtNSS.Text = this.nss;
                    txtLugarNacimiento.Text = this.birthPlace;
                    txtCURP.Text = this.curp;
                    cboPadre.SelectedValue = this.parentid;
                    cboTipoSangre.SelectedText = this.bloodtype;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void updateAlumnos(int pstudentid, string pName, string pEmail, string pAddress, string pPhone, DateTime pBirthDate, string pbirthPlace, string pcurp, string pnss, string pdiseases, int pParentId, string pBloodType)
        {
            try
            {
                Conexion conObj = new Conexion();
                string query = "UPDATE Alumnos SET Name = '"+ pName + "', Email = '"+ pEmail + "', Address = '"+ pAddress + "', Phone = '"+pPhone+"', BirthDate = '"+ pBirthDate.ToString("yyyy-MM-dd") + "', BirthPlace = '"+pbirthPlace+"', NSS = '"+pnss+"', CURP = '"+pcurp+"', diseases = '"+pdiseases+"', Parent = "+pParentId+", BloodType = '"+pBloodType+"' WHERE studentid = "+pstudentid;
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
            if(this.studentid != 0)
            {
                seModifica = true;
                desactivarBotones();
            }
            else 
            {
                MessageBox.Show("Seleccione un Alumno antes de modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    this.diseases = txtDiseases.Text;
                    this.nss = txtNSS.Text;
                    this.curp = txtCURP.Text;
                    this.parentid = Convert.ToInt32(cboPadre.SelectedValue);
                    this.bloodtype = cboTipoSangre.Text;
                    updateAlumnos(this.studentid, this.Name, this.Email, this.address, this.phone, this.birthDate, this.birthPlace, this.curp, this.nss, this.diseases, this.parentid, this.bloodtype);
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
                    this.diseases = txtDiseases.Text;
                    this.nss = txtNSS.Text;
                    this.curp = txtCURP.Text;
                    this.parentid = Convert.ToInt32(cboPadre.SelectedValue);
                    this.bloodtype = cboTipoSangre.Text;
                    addAlumnos(this.Name, this.Email, this.address, this.phone, this.birthDate, this.birthPlace, this.curp, this.nss, this.diseases, this.parentid, this.bloodtype);
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
            this.diseases = "";
            this.curp = "";
            this.nss = "";
            this.birthPlace = "";
            this.studentid = 0;
            this.bloodtype = "";
            this.parentid = 0;
            grdAlumnos.DataSource = null;
            txtBuscarUsuario.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDirección.Text = "";
            txtFechaNacimiento.Text = "";
            txtCURP.Text = "";
            txtNSS.Text = "";
            txtLugarNacimiento.Text = "";
            txtDiseases.Text = "";
            cboTipoSangre.SelectedIndex = 0;
            cboPadre.SelectedIndex = 0;
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
            if (this.studentid != 0)
            {
                DialogResult resp = MessageBox.Show("¿Estas seguro que deseas Eliminar al Alumno "+this.Name+"?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resp == DialogResult.Yes)
                {
                    deleteUser(this.studentid);
                }
            } 
            else
            {
                MessageBox.Show("Seleccione un Alumno antes de eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteUser(int pstudentid)
        {
            try
            {
                Conexion conObj = new Conexion();
                string query = "DELETE FROM Alumnos WHERE studentid = " + pstudentid;
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
            txtDiseases.Text = "";
            cboTipoSangre.SelectedIndex = 0;
            cboPadre.SelectedIndex = 0;
            desactivarBotones();
        }

        private void addAlumnos(string pName, string pEmail, string pAddress, string pPhone, DateTime pbirthDate, string pbirthPlace, string pcurp, string pnss, string pdiseases, int pParentId, string pBloodType)
        {
            try
            { // GETDATE(), IDENT_CURRENT('inventario') - 1
                Conexion conObj = new Conexion();
                string query = "INSERT INTO Alumnos (Name, Email, Address, Phone, birthDate, birthPlace, Curp, Nss, diseases, Parent, BloodType) VALUES('" + pName + "','" + pEmail + "','" + pAddress + "', '"+pPhone+"', '"+ pbirthDate.ToString("yyyy-MM-dd") + "', '"+pbirthPlace+"', '"+pcurp+"', '"+pnss+"', '"+pdiseases+"', "+pParentId+", '"+pBloodType+"')";
                string query2 = "INSERT INTO EstatusPago (Student, Status, Parent, StartDate, LastDate) VALUES(IDENT_CURRENT('alumnos') - 1, 0, "+pParentId+ ", GETDATE(),'" + DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd") + "')";
                int regs = 0;
                conObj.nonQueryAdapter(query, out regs);
                conObj.nonQueryAdapter(query2, out regs);
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
