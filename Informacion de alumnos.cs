using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa___Lista_de_alumnos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Defino valores maximos a las fechas
            dateNacimiento.MaxDate = DateTime.Now;
            dateIngreso.MaxDate = DateTime.Now;
        }

        // Defino la lista de tipo Alumnos para guardar todos los objetos
        List<Alumnos> ListaAlumnos = new List<Alumnos>();

        // Boton Agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Verificar() == false)
            {
                MessageBox.Show("Debe completar todos los campos para continuar...","Atencion!", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                // Convierto los valores decimales del NumericUpDown a int
                int Leg = Convert.ToInt32(numLegajo.Value);
                int Mat = Convert.ToInt32(numMataprobadas.Value);
                // Paso el estado del check box a la funcion 
                bool Act = checkBox.Checked; Activo(Act);

                // Creo el objetos con los datos correspondientes
                Alumnos Persona = new Alumnos(Leg, txtNombre.Text, txtApellido.Text, dateNacimiento.Value, dateIngreso.Value, Act, Mat);
                
                // Lo agrego a la lista
                ListaAlumnos.Add(Persona);

                // Agrego el objeto al DGV
                dataGridView1.Rows.Add(ListaAlumnos.Last().Legajo, ListaAlumnos.Last().Nombre, ListaAlumnos.Last().Apellido, ListaAlumnos.Last().Edad, ListaAlumnos.Last().Activo);

                // Actualizo la informacion adicional del alumno
                lblAntiguedad.Text = "- Antiguedad: " + (ListaAlumnos.Last().Antiguedad()).ToString();
                lblMatNO.Text = "- Materias no aprobadas: " + (ListaAlumnos.Last().matNoaprobadas()).ToString();
                lblAñosIngreso.Text = "- Edad de ingreso: " + (ListaAlumnos.Last().EdadIngreso()).ToString();

                Clean();
            }
        }

        // Metodo para saber si hay algun campo incompleto
        public bool Verificar ()
        {
            if (numLegajo.Value == 0 || txtNombre.Text == "" || txtApellido.Text == "")
            {
                return false;
            } 
            else
            {
                return true;
            }
        }

        // Metodo para saber si el alumno esta activo o no 
        public static bool Activo(bool act)
        {
            if (act == false)
            {
                act = false;
                return false;
            }
            else
            {
                act = true;
                return true; 
            }
        }

        // Metodo para limpiar los campos
        public void Clean()
        {
            numLegajo.Value = 0;
            txtNombre.Text = "";
            txtApellido.Text = "";
            dateNacimiento.Value = new DateTime(1999, 1, 1);
            dateIngreso.Value = new DateTime(2023, 1, 1);
            numMataprobadas.Value = 0;
            checkBox.Checked = false;
            lblAntiguedad.Text = "- Antiguedad: ";
            lblMatNO.Text = "- Materias no aprobadas: ";
            lblAñosIngreso.Text = "- Edad de ingreso: ";
        }

        // Metodo para mostratr los datos del alumno seleccionado
        public void Muestrodatos (int index)
        {
            numLegajo.Value = ListaAlumnos[index].Legajo;
            txtNombre.Text = ListaAlumnos[index].Nombre;
            txtApellido.Text = ListaAlumnos[index].Apellido;
            dateNacimiento.Value = ListaAlumnos[index].Fechanacimiento;
            dateIngreso.Value = ListaAlumnos[index].Fechaingreso;
            checkBox.Checked = ListaAlumnos[index].Activo;
            numMataprobadas.Value = ListaAlumnos[index].Mataprobadas;
            lblAntiguedad.Text = "- Antiguedad: " + ListaAlumnos[index].Antiguedad().ToString();
            lblMatNO.Text = "- Materias no aprobadas: " + ListaAlumnos[index].matNoaprobadas().ToString();
            lblAñosIngreso.Text = "- Edad de ingreso: " + ListaAlumnos[index].EdadIngreso().ToString();
        }

        // Boton Modificar
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                int select = dataGridView1.SelectedRows[0].Index; // Fila seleccionada
                // Objeto tipo Alumnos de la fila seleccionada
                Alumnos PersonaSeleccionada = ListaAlumnos[select];

                if (Verificar() == false)
                {
                    MessageBox.Show("Debe completar todos los campos para continuar...", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Convierto los valores decimales del NumericUpDown a int
                    int Leg = Convert.ToInt32(numLegajo.Value);
                    int Mat = Convert.ToInt32(numMataprobadas.Value);
                    // Paso el estado del check box a la funcion 
                    bool Act = checkBox.Checked; Activo(Act);

                    // Actualizo los datos del objeto
                    PersonaSeleccionada.Legajo = Leg;
                    PersonaSeleccionada.Nombre = txtNombre.Text;
                    PersonaSeleccionada.Apellido = txtApellido.Text;
                    PersonaSeleccionada.Fechanacimiento = dateNacimiento.Value;
                    PersonaSeleccionada.Fechaingreso = dateIngreso.Value;
                    PersonaSeleccionada.Activo = Act;
                    PersonaSeleccionada.Mataprobadas = Mat;

                    // Actualizo el DGV
                    dataGridView1.Rows[select].Cells[0].Value = Leg;
                    dataGridView1.Rows[select].Cells[1].Value = txtNombre.Text;
                    dataGridView1.Rows[select].Cells[2].Value = txtApellido.Text;
                    dataGridView1.Rows[select].Cells[3].Value = PersonaSeleccionada.Edad;
                    dataGridView1.Rows[select].Cells[4].Value = Act;

                    // Actualizo la informacion adicional del alumno
                    lblAntiguedad.Text = "- Antiguedad: " + PersonaSeleccionada.Antiguedad().ToString();
                    lblMatNO.Text = "- Materias no aprobadas: " + PersonaSeleccionada.matNoaprobadas().ToString();
                    lblAñosIngreso.Text = "- Edad de ingreso: " + PersonaSeleccionada.EdadIngreso().ToString();

                    Clean();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un alumno para utilizar esta función...", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento del DGV que se ejecuta al seleccionar una fila
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex >= 0) // Verificar que este seleccionando una fila
            {
                Muestrodatos(index);
            }
        }
        // Evento del DGV que se ejecuta al pasar el mouse sobre una fila
        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                Muestrodatos(index);
            }
        }
        // Evento del DGV que se ejecuta al sacar el mouse
        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) // Si no hay filas seleccionadas
            {
                Clean();
            }
        }

        // Boton Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1) // Si hay filas seleccionadas
            {
                int select = dataGridView1.SelectedRows[0].Index; // Fila seleccionada

                ListaAlumnos[select] = null; // Asigno null al objeto seleccionado de la lista

                ListaAlumnos.RemoveAt(select); // Elimino el objeto seleccionado de la lista

                dataGridView1.Rows.RemoveAt(select); // Elimino a la persona del DGV

                Clean();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un alumno para utilizar esta función...", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
