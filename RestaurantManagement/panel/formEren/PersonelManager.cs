﻿using panel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace panel
{
    public partial class PersonelManager : Form
    {
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e) //bunu yanlışlıkla çağırdım gereksiz
        {

        }

        int ID = -1;
        public string Email;
        public string Password;
        //public Person Person { get; set; }

       
        


        public PersonelManager()
        {
            InitializeComponent();
           
        }

        private void formEmployeeHome_Load(object sender, EventArgs e)     //labela giren kişinin adını yazdırıcaz ama bunu load da yapıyoruz bu kısım önemli
        {                                                                //10 aralık dersi dakika 20 den sonra gösteriyor yaklaşık olarak 10.12 dersi
            
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {                   //birtane messagebox gösteriyor yes no butonları olan bu baya işe yarayabilir kendi kısmım için
                var result = MessageBox.Show("Do you want to close ?","System Message",MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes) //eğer cevap evet iseyi böyle kontrol ediyoruz harika birşey bu********************
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                UpdateBackGround(button1.Name);        //Burdan görüleceği üzere altta yazdığımız metoda string bir ad gönderiyorduk burdaki butonun adını göndermemiz gerekti
            }                                         //Bu sayede gerekli kontrolleri yapıyor foreach içinde alttakilerdede aynı şeyi yaptım sadece gönderdiğim button adı farklı
            catch (Exception)
            {

                throw;
            }
        }

       
        


        //Burda buton renkleri kontrol etmek için elle bir fonksiyon yazıyoruz
        private void UpdateBackGround(string name)      //button renklerini kontrol altında tutmak için 10 aralık dersinde yaptı oldukça önemli 
        {                                              //Ve altta buton adı kontrol edeceğimiz için name gönderdik birtane içine
            try
            {
                foreach (var control in PanelLeftMenu.Controls) //hobaaa bu baya iyi foreach içinde soldaki paneldeki değişkenler eğer button ise diye kontrol ettik
                {
                    if(control is Button)        //burda yaptığımız şey foreach ile sol paneldeki değişkenleri tek tek dönüyoruz ve eğer değişken buton ise çalışıyor
                                                //sonrasında ise eğer bu butonun adı bizim içine yolladığımız butonun adıysa onun rengini değiştiriyoruz
                                                //ve diğer addaki butonların rengini eski haline getiriyoruz
                    {
                        var btn = (Button)control;
                        if (btn.Name == name)
                        {
                            btn.BackColor = Color.RoyalBlue;
                        }
                        else
                        {
                            btn.BackColor = Color.MidnightBlue;
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Employee Details";
                Employee emp = new Employee();               //BURADA TÜM SATIRLARI ALMAK İÇİN GEREKLİ OLAN İŞLEMİ BÖYLE ÇAĞIRIYORUZ
                dgvData.DataSource = emp.GetAllEmployee();   //FONKSİYONU ZATEN EMPLOYEE.CS DE YAZMIŞTIK


                lblWelcome.Text=Email;
            
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        

        private void editToolStripMenuItem1_Click(object sender, EventArgs e) //sağ click atınca çıkan şey
        {
            try
            {
                Employee emp = new Employee();
                var dt = emp.GetEmployeeByID(ID);

                if (dt.Rows.Count > 0)
                {
                    emp.EmployeeID = int.Parse(dt.Rows[0]["EmployeeID"].ToString()); //direkt istersek c.CourseID=ID de diyebiliriz bunun için
                    emp.FirstName = dt.Rows[0]["FirstName"].ToString();
                    emp.Lastname = dt.Rows[0]["Lastname"].ToString();
                    emp.Email1 = dt.Rows[0]["Email"].ToString();
                    emp.Password1 = dt.Rows[0]["Password"].ToString();
                    emp.Salary = float.Parse(dt.Rows[0]["Salary"].ToString());
                    emp.Gender1 = dt.Rows[0]["Gender"].ToString();
                    emp.DepartmentID1 = int.Parse(dt.Rows[0]["DepartmentID"].ToString());

                    PersonelUpdate form = new PersonelUpdate(emp);
                    form.ShowDialog();


                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID == -1)
                {
                    return;
                }
                var result=MessageBox.Show("Are you sure to delete ?", "System Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Employee eDel = new Employee();
                    var r= eDel.EmployeeDelete(ID);
                    if (r > 0)
                    {
                        MessageBox.Show("Employee Deleted.");
                        dgvData.DataSource = eDel.GetAllEmployee(); //silindikten sonraki halini görmek için direkt olarak
                    }
                    else
                    {
                        MessageBox.Show("Employee NOT Deleted.");
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
       
        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                //formCourseAdd c = new formCourseAdd();   //course ekle panelini açtım bu sayede
                //c.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //bu eventten yapıldı sanırım hücrede ise çalışıcak bu baya iyi aslında
        private void dgvData_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) //mouse a sağ click attığında çıkan şey için
        {                                                    //11.12.2020      11 aralık dersi birşey anlamadım pek fazla bundan
            try
            {
                if(e.ColumnIndex!=-1 && e.RowIndex !=-1)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        dgvData.Rows[e.RowIndex].Selected = true;                       //buda sağ click attığımız satırı seçili hale getiricek
                        ID = int.Parse(dgvData.Rows[e.RowIndex].Cells[0].Value.ToString());
                        
                        var relativepos = dgvData.PointToClient(Cursor.Position);       //sağ clickde seçeneklerin nerde çıkıcağını seçtik cursorda çıktı tam olarak mouseda yani
                        contextMenuStrip1.Show(dgvData,relativepos);
                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                PersonelAdd pAdd = new PersonelAdd();   //course ekle panelini açtım bu sayede
                pAdd.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void button9_Click(object sender, EventArgs e) //ADD Button
        {
            
                try
                {
                    PersonelDelete pDelete = new PersonelDelete();   //Person Delete panelini açtım bu sayede
                    pDelete.ShowDialog();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            
        }

        private void button10_Click(object sender, EventArgs e)  //Update Button
        {
            try
            {
                Employee emp = new Employee();
                var dt = emp.GetEmployeeByID(ID);

                if (dt.Rows.Count > 0)
                {
                    emp.EmployeeID = int.Parse(dt.Rows[0]["EmployeeID"].ToString()); //direkt istersek c.CourseID=ID de diyebiliriz bunun için
                    emp.FirstName = dt.Rows[0]["FirstName"].ToString();
                    emp.Lastname = dt.Rows[0]["Lastname"].ToString();
                    emp.Email1 = dt.Rows[0]["Email"].ToString();
                    emp.Password1 = dt.Rows[0]["Password"].ToString();
                    emp.Salary = float.Parse(dt.Rows[0]["Salary"].ToString());
                    emp.Gender1 = dt.Rows[0]["Gender"].ToString();
                    emp.DepartmentID1 = int.Parse(dt.Rows[0]["DepartmentID"].ToString());

                    PersonelUpdate form = new PersonelUpdate(emp);
                    form.ShowDialog();


                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        private void dgvData_CellMouseDown1(object sender, DataGridViewCellMouseEventArgs e) //mouse a sağ click attığında çıkan şey için
        {                                                    //11.12.2020      11 aralık dersi birşey anlamadım pek fazla bundan
            try
            {
                if (e.ColumnIndex != -1 && e.RowIndex != -1)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        dgvData.Rows[e.RowIndex].Selected = true;                       //buda sağ click attığımız satırı seçili hale getiricek
                        ID = int.Parse(dgvData.Rows[e.RowIndex].Cells[0].Value.ToString());

                        var relativepos = dgvData.PointToClient(Cursor.Position);       //sağ clickde seçeneklerin nerde çıkıcağını seçtik cursorda çıktı tam olarak mouseda yani
                        contextMenuStrip1.Show(dgvData, relativepos);
                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
