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
    public partial class AdmonInventario : Form
    {
        private string rol;
        public AdmonInventario()
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
            txtStock.ReadOnly = true;
            txtPrecioU.ReadOnly = true;

            cboProveedor.Enabled = false;
        }


        private void desactivarBotones()
        {
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
            btnAgregarUsuario.Visible = false;
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;

            txtNombre.ReadOnly = false;
            txtPrecioU.ReadOnly = false;
            txtStock.ReadOnly = false;
            cboProveedor.Enabled = true;
        }

        private void RecargaTodo()
        {
             this.providerid = 0;
             this.productId = 0;
             this.name = "";
             this.fecha = DateTime.Now;
             this.userid = 2;
             this.stock = 0;
             this.paid = 0.0;
             this.unitprice = 0.0;

            txtBuscarUsuario.Text = "";
            txtStock.Text = "";
            txtNombre.Text = "";

            activarBotones();

            try
            {
                Conexion conObj = new Conexion();
                string query = "SELECT * FROM Inventario";
                if (conObj.queryAdapter(query) != null)
                {
                    grdInventario.Columns.Clear();
                    grdInventario.DataSource = null;
                    grdInventario.DataSource = conObj.queryAdapter(query);
                    lblCantidadRegistros.Text = "Cantidad de Registros: " + grdInventario.Rows.Count;
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
            string productName = txtBuscarUsuario.Text;
            if (productName != "")
            {
                try
                {
                    Conexion conObj = new Conexion();
                    string query = "SELECT * FROM Inventario WHERE Name LIKE '%"+ productName + "%'";
                    if(conObj.queryAdapter(query) != null)
                    {
                        grdInventario.Columns.Clear();
                        grdInventario.DataSource = null;
                        grdInventario.DataSource = conObj.queryAdapter(query);
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
                MessageBox.Show("Favor de llenar la caja de texto para buscar un Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("No hay registros en el catalogo de Inventario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int providerid = 0;
        private int productId = 0;
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
                if (grdInventario.DataSource != null)
                {
                    this.productId = Convert.ToInt32(grdInventario.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.providerid = Convert.ToInt32(grdInventario.Rows[e.RowIndex].Cells[3].Value.ToString());
                    this.stock = Convert.ToInt32(grdInventario.Rows[e.RowIndex].Cells[2].Value.ToString());
                    this.name = grdInventario.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.unitprice = Convert.ToDouble(grdInventario.Rows[e.RowIndex].Cells[4].Value.ToString());

                    txtNombre.Text = this.name;
                    txtStock.Text = this.stock.ToString();
                    txtPrecioU.Text = this.unitprice.ToString();
                    cboProveedor.SelectedValue = this.providerid;
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
                if (grdInventario.DataSource != null)
                {
                    this.productId = Convert.ToInt32(grdInventario.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.providerid = Convert.ToInt32(grdInventario.Rows[e.RowIndex].Cells[3].Value.ToString());
                    this.stock = Convert.ToInt32(grdInventario.Rows[e.RowIndex].Cells[2].Value.ToString());
                    this.name = grdInventario.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.unitprice = Convert.ToDouble(grdInventario.Rows[e.RowIndex].Cells[4].Value.ToString());

                    txtNombre.Text = this.name;
                    txtStock.Text = this.stock.ToString();
                    txtPrecioU.Text = this.unitprice.ToString();
                    cboProveedor.SelectedValue = this.providerid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void updateInventario(int pproductid, string pName, int pStock, int pProvider, double pUnitPrice)
        {
            try
            {
                Conexion conObj = new Conexion();
                string query = "UPDATE Inventario SET Name = '"+ pName + "', Stock = "+ pStock + ", Provider = "+ pProvider + ", UnitPrice = "+pUnitPrice+" WHERE productid = "+ pproductid;
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
            if(this.productId != 0)
            {
                seModifica = true;
                desactivarBotones();
            }
            else 
            {
                MessageBox.Show("Seleccione un Product antes de modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    this.stock = Convert.ToInt32(txtStock.Text);
                    this.unitprice = Convert.ToDouble(txtPrecioU.Text);
                    this.providerid = Convert.ToInt32(cboProveedor.SelectedValue);
                    updateInventario(this.productId, this.name, this.stock, this.providerid, this.unitprice );
                    seModifica = false;
                }                         
            }

            if (seInserta)
            {
                DialogResult resp = MessageBox.Show("¿Estas seguro de agregar el registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resp == DialogResult.Yes)
                {
                    this.name = txtNombre.Text;
                    this.stock = Convert.ToInt32(txtStock.Text);
                    this.unitprice = Convert.ToDouble(txtPrecioU.Text);
                    this.providerid = Convert.ToInt32(cboProveedor.SelectedValue);
                    addInventario(this.name,this.stock, this.unitprice, this.providerid);
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
            this.providerid = 0;
            this.productId = 0;
            this.name = "";
            this.fecha = DateTime.Now;
            this.userid = 2;
            this.stock = 0;
            this.paid = 0.0;
            this.unitprice = 0.0;

            grdInventario.DataSource = null;
            txtBuscarUsuario.Text = "";
            txtStock.Text = "";
            txtNombre.Text = "";
            txtPrecioU.Text = "";
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
            if (this.productId != 0)
            {
                DialogResult resp = MessageBox.Show("¿Estas seguro que deseas Eliminar al Product "+this.Name+"?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resp == DialogResult.Yes)
                {
                    deleteUser(this.productId);
                }
            } 
            else
            {
                MessageBox.Show("Seleccione un Product antes de eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteUser(int pproductId)
        {
            try
            {
                Conexion conObj = new Conexion();
                string query = "DELETE FROM Inventario WHERE providerid = " + pproductId;
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
            txtStock.Text = "";
            txtPrecioU.Text = "";
                            
            desactivarBotones();
        }

        private void addInventario(string pName, int pStock, double pUnitPrice, int pProvider)
        {
            try
            {
                Conexion conObj = new Conexion();
                string query = "INSERT INTO Inventario (Name, Stock, Provider, UnitPrice) VALUES('" + pName + "'," + pStock + "," + pProvider + ", "+ pUnitPrice + ")";
                string query2 = "INSERT INTO Compras (PurchaseBy, Date, Product, Amount, UnitPrice, Paid, Provider) VALUES("+this.userid+ ", GETDATE(), IDENT_CURRENT('inventario') - 1, "+pStock+", "+ pUnitPrice + ", "+(pUnitPrice * pStock) +", "+pProvider+")";
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
