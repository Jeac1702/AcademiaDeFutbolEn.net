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
    public partial class AdmonCompras : Form
    {
        private string rol;
        public AdmonCompras()
        {
            InitializeComponent();
        }

        private void RecargaTodo()
        {
            this.PurchaseId = 0;
            this.Product = 0;
            this.PurchaseBy = 0;
            this.fecha = DateTime.Now;
            this.Paid = 0.0;
            this.UnitPrice = 0.0;
            this.Amount = 0;
            this.ProvideId = 0;

            txtBuscarUsuario.Text = "";
            txtCantidad.Text = "";
            txtNombre.Text = "";
            txtCreadoPor.Text = "";
            txtFecha.Text = "";
            txtPago.Text = "";
            txtPrecioU.Text = "";
            cboProveedor.Text = "";

            try
            {
                Conexion conObj = new Conexion();
                string query = "SELECT * FROM Compras";
                if (conObj.queryAdapter(query) != null)
                {
                    grdCompras.Columns.Clear();
                    grdCompras.DataSource = null;
                    grdCompras.DataSource = conObj.queryAdapter(query);
                    lblCantidadRegistros.Text = "Cantidad de Registros: " + grdCompras.Rows.Count;
                }
                else
                {
                    MessageBox.Show("No hay registros en la tabla Compras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            
            string PurchaseId = txtBuscarUsuario.Text;
            if (PurchaseId != "")
            {
                try
                {
                    Conexion conObj = new Conexion();
                    string query = "SELECT * FROM Compras WHERE PurchaseId = "+ PurchaseId + "";
                    if(conObj.queryAdapter(query) != null)
                    {
                        grdCompras.Columns.Clear();
                        grdCompras.DataSource = null;
                        grdCompras.DataSource = conObj.queryAdapter(query);
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
                MessageBox.Show("Favor de llenar la caja de texto para buscar un Compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string query = "SELECT * FROM Proveedores";
                if (conObj.queryAdapter(query) != null)
                {
                    cboProveedor.ValueMember = "ProviderId";
                    cboProveedor.DisplayMember = "Name";
                    cboProveedor.DataSource = conObj.queryAdapter(query);
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

            try
            {
                Conexion conObj = new Conexion();
                string query = "SELECT * FROM Usuarios";
                if (conObj.queryAdapter(query) != null)
                {
                    txtCreadoPor.ValueMember = "UserId";
                    txtCreadoPor.DisplayMember = "Name";
                    txtCreadoPor.DataSource = conObj.queryAdapter(query);
                }
                else
                {
                    MessageBox.Show("No hay registros en el catalogo de Usuarios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                Conexion conObj = new Conexion();
                string query = "SELECT * FROM Inventario";
                if (conObj.queryAdapter(query) != null)
                {
                    txtNombre.ValueMember = "ProductId";
                    txtNombre.DisplayMember = "Name";
                    txtNombre.DataSource = conObj.queryAdapter(query);
                }
                else
                {
                    MessageBox.Show("No hay registros en el catalogo de Productos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int PurchaseId = 0;
        private int Product = 0;
        private int PurchaseBy = 0;
        private int Amount = 0;
        private double UnitPrice = 0.0;
        private double Paid = 0.0;
        private int ProvideId = 0;
        private DateTime fecha = DateTime.Now;
        private void grdUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdCompras.DataSource != null)
                {
                    this.PurchaseId = Convert.ToInt32(grdCompras.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.PurchaseBy = Convert.ToInt32(grdCompras.Rows[e.RowIndex].Cells[1].Value.ToString());
                    this.fecha = Convert.ToDateTime(grdCompras.Rows[e.RowIndex].Cells[2].Value.ToString());
                    this.Product = Convert.ToInt32(grdCompras.Rows[e.RowIndex].Cells[3].Value.ToString());
                    this.Amount = Convert.ToInt32(grdCompras.Rows[e.RowIndex].Cells[4].Value.ToString());
                    this.UnitPrice = Convert.ToDouble(grdCompras.Rows[e.RowIndex].Cells[5].Value.ToString());
                    this.Paid = Convert.ToDouble(grdCompras.Rows[e.RowIndex].Cells[6].Value.ToString());
                    this.ProvideId = Convert.ToInt32(grdCompras.Rows[e.RowIndex].Cells[7].Value.ToString());


                    txtCantidad.Text = this.Amount.ToString();
                    txtPrecioU.Text = this.UnitPrice.ToString();
                    txtPago.Text = this.Paid.ToString();
                    txtFecha.Text = this.fecha.ToString();
                    txtCreadoPor.SelectedValue = this.PurchaseBy;
                    txtNombre.SelectedValue = this.Product;
                    cboProveedor.SelectedValue = this.ProvideId;
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
                if (grdCompras.DataSource != null)
                {
                    this.PurchaseId = Convert.ToInt32(grdCompras.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.PurchaseBy = Convert.ToInt32(grdCompras.Rows[e.RowIndex].Cells[1].Value.ToString());
                    this.fecha = Convert.ToDateTime(grdCompras.Rows[e.RowIndex].Cells[2].Value.ToString());
                    this.Product = Convert.ToInt32(grdCompras.Rows[e.RowIndex].Cells[3].Value.ToString());
                    this.Amount = Convert.ToInt32(grdCompras.Rows[e.RowIndex].Cells[4].Value.ToString());
                    this.UnitPrice = Convert.ToDouble(grdCompras.Rows[e.RowIndex].Cells[5].Value.ToString());
                    this.Paid = Convert.ToDouble(grdCompras.Rows[e.RowIndex].Cells[6].Value.ToString());
                    this.ProvideId = Convert.ToInt32(grdCompras.Rows[e.RowIndex].Cells[7].Value.ToString());


                    txtCantidad.Text = this.Amount.ToString();
                    txtPrecioU.Text = this.UnitPrice.ToString();
                    txtPago.Text = this.Paid.ToString();
                    txtFecha.Text = this.fecha.ToString();
                    txtCreadoPor.SelectedValue = this.PurchaseBy;
                    txtNombre.SelectedValue = this.Product;
                    cboProveedor.SelectedValue = this.ProvideId;
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
            this.Product = 0;
            this.PurchaseBy = 0;
            this.fecha = DateTime.Now;
            this.Paid = 0.0;
            this.UnitPrice = 0.0;
            this.Amount = 0;
            this.ProvideId = 0;
            grdCompras.DataSource = null;
            txtBuscarUsuario.Text = "";
            txtCantidad.Text = "";
            txtNombre.Text = "";
            txtCreadoPor.Text = "";
            txtFecha.Text = "";
            txtPago.Text = "";
            txtPrecioU.Text = "";
            cboProveedor.Text = "";
            lblCantidadRegistros.Text = "Cantidad de Registros: " + 0;
        }
    }
}
