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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)      
        {
            try
            {
                string userName = txtUsuario.Text;
                string password = txtPassword.Text;
                if(userName == "USUARIO" && password == "CONTRASEÑA")
                {
                    userName = "";
                    password = "";
                }

                if (userName != "" && password != "")
                {
                    Conexion conObj = new Conexion();
                    string query = "SELECT * FROM Usuarios WHERE Name = '"+userName+"' AND Password = '"+password+"'";
                    if(conObj.queryAdapter(query).Rows.Count > 0)
                    {
                        AcademiaFutbol academiaFutbol = new AcademiaFutbol();
                        string rol = string.Empty;
                        conObj.queryScalarAdapter("Usuarios", "Role", "", out rol);
                        academiaFutbol.setCurrentRol(rol);
                        academiaFutbol.Show();
                        this.Hide();
                    } else
                    {
                        MessageBox.Show("Usuario o Contraseña no válidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Llena los campos de Usuario y Contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "CONTRASEÑA")
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
                txtPassword.ForeColor = Color.LightGray;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "CONTRASEÑA";
                btnVerOcultar.Text = "VER";
                txtPassword.PasswordChar = '\0'; //'\u0000'
                txtPassword.ForeColor = Color.DimGray;
            }
        }

        private void btnVerOcultar_Click(object sender, EventArgs e)
        {
            if(btnVerOcultar.Text == "VER" && txtPassword.Text != "CONTRASEÑA")
            {
                txtPassword.PasswordChar= '\0'; //'\u0000'
                btnVerOcultar.Text = "OCULTAR";
            } 
            else if(btnVerOcultar.Text == "OCULTAR" && txtPassword.Text != "CONTRASEÑA")
            {
                txtPassword.PasswordChar = '*';
                btnVerOcultar.Text = "VER";
            }
        }
    }
}
