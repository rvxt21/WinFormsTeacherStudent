﻿using System;
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
    public partial class Form1 : Form
    {
        private List<Teacher> list;
        private Form2 f2 = new Form2();
        private List<Student> list1 = new List<Student>();
        private AddTeacher addTeacherF = new AddTeacher();
        private AddStudent addStudentForm = new AddStudent();
        public Form1()
        {
            InitializeComponent();
            list = new List<Teacher>();
            StaticTeacher.ListTeacher = list;
            InitialModel();
            InitialComboBox();
            DataTable(list);
            DataTableStudent(list1);
            SearchAge(list1);
            InitialTreeView();
        }
        public void FindStudent()
        {
            if (list1.Count > 0)
            {
                list1.Clear();
            }
            string type = this.comboBox1.SelectedItem.ToString();
            for (int i = 0; i < list.Count; i++)
            {

                List<Student> listStudent = list[i].getCourseWorkStudents();
                for (int j = 0; j < listStudent.Count; j++)
                {
                    if (type == listStudent[j].TypeStudent.ToString())
                    {
                        list1.Add(listStudent[j]);
                    }
                }
            }
            DataTableStudent(list1);
            SearchAge(list1);
        }
        private void DataTableStudent(List<Student> list)
        {

            DataTable tabel = new DataTable("name");
            tabel.Columns.Add("Id");
            tabel.Columns.Add("Name");
            tabel.Columns.Add("Surname");
            tabel.Columns.Add("Group");
            tabel.Columns.Add("Type");
            tabel.Columns.Add("Age");
            tabel.Columns.Add("City");
            tabel.Columns.Add("Street");
            tabel.Columns.Add("House");
            if (list.Count > 0)
            {
                list.Clear();
            }
            for (int i = 0; i < list.Count; i++)
                tabel.Rows.Add(i + 1, list[i].Name, list[i].Surname, list[i].Age, list[i].Group, list[i].TypeStudent, list[i].Adress.City, list[i].Adress.Street, list[i].Adress.House);

            this.dataGridView2.DataSource = tabel;
        }
        private void DataTable(List<Teacher> list)
        {

            DataTable tabel = new DataTable("name");
            tabel.Columns.Add("ID");
            tabel.Columns.Add("Name");
            tabel.Columns.Add("Surname");
            tabel.Columns.Add("Age");
            tabel.Columns.Add("City");
            tabel.Columns.Add("Street");
            tabel.Columns.Add("House");

            for (int i = 0; i < list.Count; i++)
                tabel.Rows.Add(i + 1, list[i].Name, list[i].Surname, list[i].Age, list[i].Adress.City, list[i].Adress.Street, list[i].Adress.House);
            this.dataGridView1.DataSource = tabel;
        }
        public void InitialComboBox()
        {
            this.comboBox1.Items.Add("exelent");
            this.comboBox1.Items.Add("good");
            this.comboBox1.Items.Add("three");
            this.comboBox1.Items.Add("bad");
            this.comboBox1.Items.Add("very bad");
        }
        public void InitialModel()
        {
            Adress adres1 = new Adress("Kherson", "Universitetska", 12);
            Student student1 = new Student(221, "Maria", "Pushkariova", 18, adres1, typeStudent.exelent);
            Student student2 = new Student(121, "Egor", "Kazenov", 18, adres1, typeStudent.good);
            Student student3 = new Student(121, "Natalia", "Ivanova", 17, adres1, typeStudent.exelent);
            Student student4 = new Student(231, "Anastasia", "Koryagina", 18, adres1, typeStudent.exelent);
            Student student5 = new Student(231, "Ivan", "Safontev", 19, adres1, typeStudent.exelent);
            Teacher teacher1 = new Teacher(2, "English", "Olga", "Gnedkova", 30, adres1);
            Teacher teacher2 = new Teacher(3, "Math", "Anastasia", "Bistryanceva", 30, adres1);
            teacher1.AddCourseWorkStudent(student1);
            teacher1.AddCourseWorkStudent(student2);
            teacher2.AddCourseWorkStudent(student3);
            teacher2.AddCourseWorkStudent(student4);
            teacher2.AddCourseWorkStudent(student5);
            list.Add(teacher1);
            list.Add(teacher2);
            StaticTeacher.ListTeacher = list;
        }
        public void InitialTreeView()
        {
            TreeNode root = new TreeNode();

            root.Name = "Root";
            root.Text = "List";
            this.treeView1.Nodes.Add(root);
            for (int i = 0; i < list.Count; i++)
            {
                this.treeView1.Nodes[0].Nodes.Add(list[i].Name + " " + list[i].Surname);
                List<Student> listStudent = list[i].getCourseWorkStudents();
                for (int j = 0; j < listStudent.Count; j++)
                    this.treeView1.Nodes[0].Nodes[i].Nodes.Add(listStudent[j].Name + " " + listStudent[j].Surname);
            }

            /*
            this.treeView1.Nodes[0].Nodes.Add("text1");
            this.treeView1.Nodes[0].Nodes.Add("text2");

            this.treeView1.Nodes[0].Nodes[0].Nodes.Add("text1.1");
            this.treeView1.Nodes[0].Nodes[1].Nodes.Add("text1.2");*/

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void SearchAge(List<Student> list1)
        {
            this.chart1.Series["Age"].Points.Clear();
            for (int i = 0; i < list1.Count; i++)
            {
                this.chart1.Series["Age"].Points.AddXY(list1[i].Name, list1[i].Age);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FindStudent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(f2.getText);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addTeacherF.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            list.Add(StaticTeacher.Teacher);
            DataTable(list);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addStudentForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            list1.Add(StaticStudent.Student);
        }
    }
}
