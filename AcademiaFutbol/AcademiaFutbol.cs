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
    public partial class AcademiaFutbol : Form
    {
        private string rol;
        public AcademiaFutbol()
        {
            InitializeComponent();
            
        }

        public void setCurrentRol(string rol)
        {
            this.rol = rol;
        }

        private Form activeForm = null;
        private void openChildForms(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelFormularios.Controls.Add(childForm);
            panelFormularios.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnAdmonUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                AdmonUsuarios admonUsuarios = new AdmonUsuarios();
                string rol = string.Empty;
                Conexion conObj = new Conexion();
                conObj.queryScalarAdapter("Usuarios", "Role", "", out rol);
                admonUsuarios.setCurrentRol(rol);
                openChildForms(admonUsuarios);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            try
            {
                if(activeForm != null)
                    activeForm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPadres_Click(object sender, EventArgs e)
        {
            try
            {
                AdmonPadres admonPadres = new AdmonPadres();
                string rol = string.Empty;
                Conexion conObj = new Conexion();
                conObj.queryScalarAdapter("Usuarios", "Role", "", out rol);
                admonPadres.setCurrentRol(rol);
                openChildForms(admonPadres);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            try
            {
                AdmonProfesores admonProfesores = new AdmonProfesores();
                string rol = string.Empty;
                Conexion conObj = new Conexion();
                conObj.queryScalarAdapter("Usuarios", "Role", "", out rol);
                admonProfesores.setCurrentRol(rol);
                openChildForms(admonProfesores);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            try
            {
                AdmonAlumnos admonAlumnos = new AdmonAlumnos();
                string rol = string.Empty;
                Conexion conObj = new Conexion();
                conObj.queryScalarAdapter("Usuarios", "Role", "", out rol);
                admonAlumnos.setCurrentRol(rol);
                openChildForms(admonAlumnos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            try
            {
                AdmonProveedores admonProveedores = new AdmonProveedores();
                string rol = string.Empty;
                Conexion conObj = new Conexion();
                conObj.queryScalarAdapter("Usuarios", "Role", "", out rol);
                admonProveedores.setCurrentRol(rol);
                openChildForms(admonProveedores);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            try
            {
                AdmonInventario admonInventario = new AdmonInventario();
                string rol = string.Empty;
                Conexion conObj = new Conexion();
                conObj.queryScalarAdapter("Usuarios", "Role", "", out rol);
                admonInventario.setCurrentRol(rol);
                openChildForms(admonInventario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            try
            {
                AdmonCompras admonCompras = new AdmonCompras();
                string rol = string.Empty;
                Conexion conObj = new Conexion();
                conObj.queryScalarAdapter("Usuarios", "Role", "", out rol);
                admonCompras.setCurrentRol(rol);
                openChildForms(admonCompras);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHistorialPagos_Click(object sender, EventArgs e)
        {
            try
            {
                AdmonHistorialPagos admonHP = new AdmonHistorialPagos();
                string rol = string.Empty;
                Conexion conObj = new Conexion();
                conObj.queryScalarAdapter("Usuarios", "Role", "", out rol);
                admonHP.setCurrentRol(rol);
                openChildForms(admonHP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            try
            {
                AdmonPagos admonPagos = new AdmonPagos();
                string rol = string.Empty;
                Conexion conObj = new Conexion();
                conObj.queryScalarAdapter("Usuarios", "Role", "", out rol);
                admonPagos.setCurrentRol(rol);
                openChildForms(admonPagos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
