using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherStudent
{
    public partial class AddStudent : Form
    {
        Form2 f2 = new Form2();
        public AddStudent()
        {
            InitializeComponent();
            InitialComboBox();
        }
        public void InitialComboBox()
        {
            this.comboBox1.Items.AddRange(Enum.GetNames(typeof(typeStudent)));
        }
        public void InitialComboBox2()
        { 
            /*this.comboBox2.DataSource = StaticTeacher.ListTeacher;
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.ValueMember="Surname";*/
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string name = this.textBox1.Text;
            string surname = this.textBox2.Text;
            int age = Convert.ToInt32(this.textBox3.Text);
            int group = Convert.ToInt32(this.textBox4.Text);
            StaticStudent.adresStudent = StaticAdress.Adress;
            typeStudent type1 = (typeStudent)this.comboBox1.SelectedItem;
            Student student = new Student(group, name, surname, age, StaticStudent.adresStudent,type1);
            StaticStudent.Student = student;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2.Show();
        }
    }
}
