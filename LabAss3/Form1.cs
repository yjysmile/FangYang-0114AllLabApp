using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Validations;

namespace LabAss3
{
    public partial class frmCustomerDataEntry : Form
    {
        public frmCustomerDataEntry()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string Gender, Hobby, Status = "";
            if (radioMale.Checked) Gender = "Male";
            else Gender = "Female";
            if (chkReading.Checked) Hobby = "Reading";
            else Hobby = "Painting";
            if (radioMarried.Checked) Status = "Married";
            else Status = "Unmarried";

            try
            {
                CustomerValidation objVal = new CustomerValidation();
                objVal.CheckCustomerName(txtName.Text);
                frmCustomerPreview objPreview = new frmCustomerPreview();
                objPreview.SetValues(txtName.Text, cmbCountry.Text, Gender, Hobby, Status);
                objPreview.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void frmCustomerDataEntry_Load(object sender, EventArgs e)
        {
            //Open a Connection
            string strConnection = "Data Source=DESKTOP-767N059;Initial Catalog=CustomerDB;Integrated Security=True;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();

            //Fire a Command
            string strCommand = "Select * From Customer";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            //Bind Data with UI
            DataSet objDataSet = new DataSet();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objCommand);
            objDataAdapter.Fill(objDataSet);
            dataGridView1.DataSource = objDataSet.Tables[0];

            //Close the Connection
            objConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Gender, Hobby, Status = "";
            if (radioMale.Checked) Gender = "Male";
            else Gender = "Female";
            if (chkReading.Checked) Hobby = "Reading";
            else Hobby = "Painting";
            if (radioMarried.Checked) Status = "1";
            else Status = "0";

            //Open a Connection
            string strConnection = "Data Source=MSI;Initial Catalog=CustomerDB;Integrated Security=True;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();

            //Fire a Command
            string strCommand = "insert into Customer(CustomerName,Country,Gender,Hobby,Married) values('" + txtName.Text + "','"
                + cmbCountry.Text + "','"
                + Gender + "','"
                + Hobby + "',"
                + Status + ")";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            objCommand.ExecuteNonQuery();

            //Close the Connection
            objConnection.Close();
            loadCustomer();
        }

        private void loadCustomer()
        {
            //Open a Connection
            string strConnection = "Data Source=MSI;Initial Catalog=CustomerDB;Integrated Security=True;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();

            //Fire a Command
            string strCommand = "Select * From Customer";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            //Bind Data with UI
            DataSet objDataSet = new DataSet();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objCommand);
            objDataAdapter.Fill(objDataSet);
            dataGridView1.DataSource = objDataSet.Tables[0];

            //Close the Connection
            objConnection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clearForm();
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            displayCustomer(id);
        }

        private void clearForm()
        {
            txtName.Text = "";
            cmbCountry.Text = "";
            radioMale.Checked = false;
            radioFemale.Checked = false;
            chkPainting.Checked = false;
            chkReading.Checked = false;
            radioMarried.Checked = false;
            radioUnmarried.Checked = false;
        }
        private void displayCustomer(String id)
        {
            //Open a Connection
            string strConnection = "Data Source=MSI;Initial Catalog=CustomerDB;Integrated Security=True;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();

            //Fire a Command
            string strCommand = "Select * From Customer where id =" + id;
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            //Bind Data with UI
            DataSet objDataSet = new DataSet();
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objCommand);
            objDataAdapter.Fill(objDataSet);
            //Close the Connection
            objConnection.Close();
            label4.Text = objDataSet.Tables[0].Rows[0][0].ToString().Trim(); ;
            txtName.Text = objDataSet.Tables[0].Rows[0][1].ToString().Trim();
            cmbCountry.Text = objDataSet.Tables[0].Rows[0][2].ToString().Trim();
            string Gender = objDataSet.Tables[0].Rows[0][3].ToString().Trim();
            if (Gender.Equals("Male")) radioMale.Checked = true;
            else radioFemale.Checked = true;
            string Hobby = objDataSet.Tables[0].Rows[0][4].ToString().Trim();
            if (Hobby.Equals("Male")) chkReading.Checked = true;
            else chkPainting.Checked = true;
            string Married = objDataSet.Tables[0].Rows[0][5].ToString().Trim();
            if (Married.Equals("Male")) radioMarried.Checked = true;
            else radioUnmarried.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Gender, Hobby, Status = "";
            if (radioMale.Checked) Gender = "Male";
            else Gender = "Female";
            if (chkReading.Checked) Hobby = "Reading";
            else Hobby = "Painting";
            if (radioMarried.Checked) Status = "1";
            else Status = "0";
            //Open a Connection
            string strConnection = "Data Source=MSI;Initial Catalog=CustomerDB;Integrated Security=True;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            //Fire a Command
            string strCommand = "UPDATE Customer SET CustomerName =@CustomerName£¬Country=@Country," +
                "Gender=@Gender, Hobby=@Hobby, Married= @Married WHERE id=@id";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            objCommand.Parameters.AddWithValue("@CustomerName", txtName.Text.Trim());
            objCommand.Parameters.AddWithValue("@Country", cmbCountry.Text.ToString().Trim());
            objCommand.Parameters.AddWithValue("@Gender", Gender);
            objCommand.Parameters.AddWithValue("@Hobby", Hobby);
            objCommand.Parameters.AddWithValue("@Harried", Status);
            objCommand.Parameters.AddWithValue("@id", label4.Text.Trim());
            objCommand.ExecuteNonQuery();
            //close the Connection
            objConnection.Close();
            clearForm();
            loadCustomer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Open a Connection
            string strConnection = "Data Source=MSI;Initial Catalog=CustomerDB;Integrated Security=True;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();

            //Fire a Command
            string strCommand = "Delete from Customer where id = '" + label4.Text + "'";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            objCommand.ExecuteNonQuery();
            //Close the Connection
            objConnection.Close();
            clearForm();
            loadCustomer();
        }
    }
}