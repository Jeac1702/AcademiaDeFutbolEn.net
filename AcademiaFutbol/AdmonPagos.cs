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
    public partial class AdmonPagos : Form
    {
        private string rol;
        public AdmonPagos()
        {
            InitializeComponent();
        }


        private void activarBotones()
        {

            btnAceptar.Visible = false;
            btnCancelar.Visible = false;

            txtNombre.Enabled = false;
            txtTarifa.ReadOnly = true;

        }


        private void desactivarBotones()
        {

            btnAceptar.Visible = true;
            btnCancelar.Visible = true;

            txtNombre.Enabled = true;

            txtTarifa.ReadOnly = false;

        }

        private void RecargaTodo()
        {
             this.Studentid = 0;
             this.statusid = 0;
             this.name = "";
             this.fecha = DateTime.Now;
             this.userid = 2;
             this.stock = 0;
             this.paid = 0.0;
             this.unitprice = 0.0;

            txtBuscarUsuario.Text = "";
            txtTarifa.Text = "";
            txtNombre.Text = "";

            activarBotones();

            try
            {
                Conexion conObj = new Conexion();
                string query = "SELECT * FROM EstatusPago";
                if (conObj.queryAdapter(query) != null)
                {
                    grdPagos.Columns.Clear();
                    grdPagos.DataSource = null;
                    grdPagos.DataSource = conObj.queryAdapter(query);
                    lblCantidadRegistros.Text = "Cantidad de Registros: " + grdPagos.Rows.Count;
                }
                else
                {
                    MessageBox.Show("No hay registros en la tabla Inventario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        grdPagos.Columns.Clear();
                        grdPagos.DataSource = null;
                        grdPagos.DataSource = conObj.queryAdapter(query);
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
                string query = "SELECT * FROM Alumnos";
                if (conObj.queryAdapter(query) != null)
                {
                    txtNombre.ValueMember = "StudentId";
                    txtNombre.DisplayMember = "Name";
                    txtNombre.DataSource = conObj.queryAdapter(query);
                }
                else
                {
                    MessageBox.Show("No hay registros en el catalogo de Inventario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int Studentid = 0;
        private int statusid = 0;
        private string name = "";
        private DateTime fecha = DateTime.Now;
        private int userid = 2;
        private int stock = 0;
        private double paid = 0.0;
        private double unitprice = 0.0;
        private void grdUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdPagos.DataSource != null)
                {
                    this.statusid = Convert.ToInt32(grdPagos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.Studentid = Convert.ToInt32(grdPagos.Rows[e.RowIndex].Cells[3].Value.ToString());
                    this.stock = Convert.ToInt32(grdPagos.Rows[e.RowIndex].Cells[2].Value.ToString());
                    this.name = grdPagos.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.unitprice = Convert.ToDouble(grdPagos.Rows[e.RowIndex].Cells[4].Value.ToString());

                    txtNombre.Text = this.name;
                    txtTarifa.Text = this.stock.ToString();
 
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
                if (grdPagos.DataSource != null)
                {
                    this.statusid = Convert.ToInt32(grdPagos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.Studentid = Convert.ToInt32(grdPagos.Rows[e.RowIndex].Cells[3].Value.ToString());
                    this.stock = Convert.ToInt32(grdPagos.Rows[e.RowIndex].Cells[2].Value.ToString());
                    this.name = grdPagos.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.unitprice = Convert.ToDouble(grdPagos.Rows[e.RowIndex].Cells[4].Value.ToString());

                    txtNombre.Text = this.name;
                    txtTarifa.Text = this.stock.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private bool estatusPago = false;
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(this.statusid != 0)
            {
                estatusPago = true;
                desactivarBotones();
            }
            else 
            {
                MessageBox.Show("Seleccione un Product antes de modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {         
          
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            this.Studentid = 0;
            this.statusid = 0;
            this.name = "";
            this.fecha = DateTime.Now;
            this.userid = 2;
            this.stock = 0;
            this.paid = 0.0;
            this.unitprice = 0.0;

            grdPagos.DataSource = null;
            txtBuscarUsuario.Text = "";
            txtTarifa.Text = "";
            txtNombre.Text = "";

            lblCantidadRegistros.Text = "Cantidad de Registros: " + 0;
            activarBotones();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
