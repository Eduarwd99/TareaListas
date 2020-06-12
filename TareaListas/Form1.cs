using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TareaListas.Modelo;

namespace TareaListas
{
    public partial class Form1 : Form
    {
        private List<Estudiantes> lista = new List<Estudiantes>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Numero de matricula ingresada no valida...
            if (this.txtMatricula.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar el numero de matricula del estudiante");
                this.txtMatricula.Focus();
            }
            else if (this.txtApellidos.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar los apellidos del estudiante");
                this.txtApellidos.Focus();
            }
            else if (this.txtNombres.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar los nombres del estudiante");
                this.txtNombres.Focus();
            }
            else if (!(int.TryParse(this.txtEdad.Text, out int edad)))
            {
                MessageBox.Show("Edad ingresada no valida...");
                this.txtEdad.Focus();
            }
            else if (this.cmbSexo.Text == "")
            {
                MessageBox.Show("Debe seleccionar el sexo del estudiante");
                this.cmbSexo.Focus();
            }
            else
            {
                Estudiantes alumno = new Estudiantes();
                alumno.matricula = this.txtMatricula.Text;
                alumno.apellidos = this.txtApellidos.Text;
                alumno.nombres = this.txtNombres.Text;
                alumno.edad = edad;
                alumno.sexo = this.cmbSexo.Text;

                lista.Add(alumno);

                this.gridEstudiante.DataSource = null;
                this.gridEstudiante.DataSource = lista;

                this.txtMatricula.Text = "";
                this.txtApellidos.Text = "";
                this.txtNombres.Text = "";
                this.txtEdad.Text = "";
                this.cmbSexo.Text = "";
            }  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.gridEstudiante.DataSource = null;
            this.gridEstudiante.DataSource = lista.Where(data => data.matricula == this.txtMatricula.Text).ToList();

            this.txtMayor.Text = lista.Max(data => data.edad).ToString();
            this.txtMenor.Text = lista.Min(data => data.edad).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void label6_Click(object sender, EventArgs e)
        {
        }
    }
}
