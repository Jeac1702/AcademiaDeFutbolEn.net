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
    public partial class AdmonHistorialPagos : Form
    {
        private string rol;
        public AdmonHistorialPagos()
        {
            InitializeComponent();
        }

        private void RecargaTodo()
        {
            this.PaymentId = 0;
            this.Student = 0;
            this.fecha = DateTime.Now;
            this.Paid = 0.0;
            this.Fee = 0.0;
            this.change = 0.0;


            txtBuscarUsuario.Text = "";
            txtNombre.Text = "";
            txtFecha.Text = "";
            txtPago.Text = "";
            txtTarifa.Text = "";
            txtCambio.Text = "";

            try
            {
                Conexion conObj = new Conexion();
                string query = "SELECT * FROM HistorialPagos";
                if (conObj.queryAdapter(query) != null)
                {
                    grdPagos.Columns.Clear();
                    grdPagos.DataSource = null;
                    grdPagos.DataSource = conObj.queryAdapter(query);
                    lblCantidadRegistros.Text = "Cantidad de Registros: " + grdPagos.Rows.Count;
                }
                else
                {
                    MessageBox.Show("No hay registros en la tabla HistorialPagos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            
            string Paymentid = txtBuscarUsuario.Text;
            if (Paymentid != "")
            {
                try
                {
                    Conexion conObj = new Conexion();
                    string query = "SELECT * FROM HistorialPagos WHERE Paymentid = " + Paymentid + "";
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
                MessageBox.Show("Favor de llenar la caja de texto para buscar un Pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("No hay registros en el catalogo de Proveedores", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private int PaymentId = 0;
        private int Student = 0;
        private double Fee = 0.0;
        private double Paid = 0.0;
        private DateTime fecha = DateTime.Now;
        private double change = 0.0;
        private void grdUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdPagos.DataSource != null)
                {
                    this.PaymentId = Convert.ToInt32(grdPagos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.fecha = Convert.ToDateTime(grdPagos.Rows[e.RowIndex].Cells[2].Value.ToString());
                    this.Student = Convert.ToInt32(grdPagos.Rows[e.RowIndex].Cells[1].Value.ToString());
                    this.Fee = Convert.ToDouble(grdPagos.Rows[e.RowIndex].Cells[3].Value.ToString());
                    this.Paid = Convert.ToDouble(grdPagos.Rows[e.RowIndex].Cells[4].Value.ToString());
                    this.change = Convert.ToDouble(grdPagos.Rows[e.RowIndex].Cells[5].Value.ToString());

                    txtTarifa.Text = this.Fee.ToString();
                    txtPago.Text = this.Paid.ToString();
                    txtFecha.Text = this.fecha.ToString();
                    txtNombre.SelectedValue = this.Student;
                    txtCambio.Text = this.change.ToString();
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
                    this.PaymentId = Convert.ToInt32(grdPagos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.fecha = Convert.ToDateTime(grdPagos.Rows[e.RowIndex].Cells[2].Value.ToString());
                    this.Student = Convert.ToInt32(grdPagos.Rows[e.RowIndex].Cells[1].Value.ToString());
                    this.Fee = Convert.ToDouble(grdPagos.Rows[e.RowIndex].Cells[3].Value.ToString());
                    this.Paid = Convert.ToDouble(grdPagos.Rows[e.RowIndex].Cells[4].Value.ToString());
                    this.change = Convert.ToDouble(grdPagos.Rows[e.RowIndex].Cells[5].Value.ToString());

                    txtTarifa.Text = this.Fee.ToString();
                    txtPago.Text = this.Paid.ToString();
                    txtFecha.Text = this.fecha.ToString();
                    txtNombre.SelectedValue = this.Student;
                    txtCambio.Text = this.change.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            this.Student = 0;
            this.fecha = DateTime.Now;
            this.Paid = 0.0;
            this.Fee = 0.0;
            this.change = 0.0;

            grdPagos.DataSource = null;
            txtBuscarUsuario.Text = "";
            txtNombre.Text = "";

            txtFecha.Text = "";
            txtPago.Text = "";
            txtTarifa.Text = "";
            txtCambio.Text = "";
            lblCantidadRegistros.Text = "Cantidad de Registros: " + 0;
        }
    }
}
