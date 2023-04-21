using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Data;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmCustomerDataEntry_Load(object sender, EventArgs e)
        {
            // Open a Connection
            string strConnection = "Data Source=Apocalypse;Initial Catalog=CustomerDB;Persist Security Info=True;User ID=sa;Password=112233;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            // Fire a Command
            string strCommand = "Select * From Customer";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            // Bind Data with UI
            DataSet objDataSet = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);
            dtgCustomer.DataSource = objDataSet.Tables[0];
            // Close the Connection
            objConnection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Gender, Hobby, Status = "";
            if (radioMale.Checked) Gender = "Male";
            else Gender = "Fenale";
            if (chkReading.Checked) Hobby = "Reading";
            else Hobby = "Painting";
            if (radioMarried.Checked) Status = "1";
            else Status = "0";
            // Open a Connection
            string strConnection = "Data Source=Apocalypse;Initial Catalog=CustomerDB;Persist Security Info=True;User ID=sa;Password=112233;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            // Fire a Command
            string strCommand = "insert into Customer(CustomerName,Country,Gender,Hobby,Married) values('" + txtName.Text + "' ,'"
            + cmbCountry.Text + "','"
            + Gender +"','"
            + Hobby + "',"
            + Status + ")";
            SqlCommand objComnand = new SqlCommand(strCommand, objConnection);
            objComnand.ExecuteNonQuery();
            // Close the Connection
            objConnection.Close();
            loadCustomer();
        }

        private void loadCustomer()
        {
            // Open a Connection
            string strConnection = "Data Source=Apocalypse;Initial Catalog=CustomerDB;Persist Security Info=True;User ID=sa;Password=112233;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            // Fire a Command
            string strCommand = "Select * From Customer";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            // Bind Data with UI
            DataSet objDataSet = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);
            dtgCustomer.DataSource = objDataSet.Tables[0];
            // Close the Connection
            objConnection.Close();
        }

        private void dtgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clearForm();
            string id = dtgCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
            displayCustomer(id);
        }

        private void displayCustomer(string id)
        {
            //Open a Connection

            string strConnection = "Data Source=Apocalypse;Initial Catalog=CustomerDB;Persist Security Info=True;User ID=sa;Password=112233;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            //Fire a Command
            string strCommand = "Select * From Customer where id =" + id;
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            //Bind Data with UI
            DataSet objDataSet = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);
            objConnection.Close();
            lblID.Text = objDataSet.Tables[0].Rows[0][0].ToString().Trim();
            txtName.Text = objDataSet.Tables[0].Rows[0][1].ToString().Trim();
            cmbCountry.Text = objDataSet.Tables[0].Rows[0][2].ToString().Trim();
            string Gender = objDataSet.Tables[0].Rows[0][3].ToString().Trim();
            if (Gender.Equals("Male")) radioMale.Checked = true;
            else radioFemale.Checked = true;
            string Hobby = objDataSet.Tables[0].Rows[0][4].ToString().Trim();
            if (Hobby.Equals("Reading")) chkReading.Checked = true;
            else chkPainting.Checked = true;
            string Married = objDataSet.Tables[0].Rows[0][5].ToString().Trim();
            if (Married.Equals("True")) radioMarried.Checked = true;
            else radioUnmarried.Checked = true;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string Gender, Hobby, Status = "";
            if (radioMale.Checked) Gender = "Male";
            else Gender = "Female";
            if (chkReading.Checked) Hobby = "Reading";
            else Hobby = "Painting";
            if (radioMarried.Checked) Status = "1";
            else Status = "0";
            //Open a Connection
            string strConnection = "Data Source=Apocalypse;Initial Catalog=CustomerDB;Persist Security Info=True;User ID=sa;Password=112233;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            //Fire a Command
            string strCommand = "UPDATE Customer SET CustomerName =@CustomerName,Country=@Country," +
                "Gender=@Gender,Hobby=@Hobby,Married=@Married WHERE id=@id";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            objCommand.Parameters.AddWithValue("@CustomerName", txtName.Text.Trim());
            objCommand.Parameters.AddWithValue("@Country", cmbCountry.SelectedItem.ToString().Trim());
            objCommand.Parameters.AddWithValue("@Gender", Gender);
            objCommand.Parameters.AddWithValue("@Hobby", Hobby);
            objCommand.Parameters.AddWithValue("@Married", Status);
            objCommand.Parameters.AddWithValue("@id", lblID.Text.Trim());
            objCommand.ExecuteNonQuery();
            //Close the Connection
            objConnection.Close();
            clearForm();
            loadCustomer();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Open a Connection
            string strConnection = "Data Source=Apocalypse;Initial Catalog=CustomerDB;Persist Security Info=True;User ID=sa;Password=112233;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            // Fire a Command
            string strCommand = "Delete from Customer where id ='" + lblID.Text + "'";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            objCommand.ExecuteNonQuery();
            //Close the Connection
            objConnection.Close();
            clearForm();
            loadCustomer();
        }
    }
}
