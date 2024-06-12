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

namespace Hospital_Mangement_System
{
    public partial class Medicine : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=WASSAF;Initial Catalog=Hospital;Integrated Security=True");

        public Medicine()
        {
            InitializeComponent();
            populate();
        }

        private void txtPatientName_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMedicineID.Text == "" || txtMedicineName.Text == "" || txtManufacturerName.Text == "" ||txtQuantity.Text == "" || dateMedicine.Value.ToString() == "" || txtUnitPrice.Text == "" || txtCategory.Text == "")
            {
                MessageBox.Show("Missing Information! Fill all details carefully.");
            }
            else
            {
                conn.Open();
                string query = "INSERT INTO Medicine VALUES("+txtMedicineID.Text+",'"+txtMedicineName.Text+"','"+txtManufacturerName.Text+"',"+txtQuantity.Text+",'"+dateMedicine.Value.ToString()+"',"+txtUnitPrice.Text+",'"+txtCategory.Text+"')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Medicine Added Successfully.");
                conn.Close();
                populate();
                reset();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMedicineID.Text == "")
            {
                MessageBox.Show("Enter Medicine ID to delete it");
            }
            else
            {
                conn.Open();
                string query = "DELETE FROM Medicine WHERE MedicineID = " + txtMedicineID.Text + "";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Medicine Deleted Successfully.");
                conn.Close();
                populate();
                reset();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMedicineID.Text == "")
            {
                MessageBox.Show("Enter Medicine ID to update it.");
            }
            else
            {
                conn.Open();
                string query = "UPDATE Medicine Set MedicineName = '" + txtMedicineName.Text + "', Manufacturer = '"+txtManufacturerName.Text+"', QuantityAvailable = "+txtQuantity.Text+", ExpiryDate = '"+dateMedicine.Value.ToString()+"', UnitPrice = "+txtUnitPrice.Text+", Category = '"+txtCategory.Text+ "' WHERE MedicineID = " + txtMedicineID.Text + "";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Medicine Details Updated Successfully.");
                conn.Close();
                populate();
                reset();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            populate(); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            Doctor doctor = new Doctor();
            doctor.Show();
            this.Hide();
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
            this.Hide();
        }

        private void btnMedicines_Click(object sender, EventArgs e)
        {
            Medicine medicine = new Medicine();
            medicine.Show();
            this.Hide();
        }

        private void btnDiagnosis_Click(object sender, EventArgs e)
        {
            Diagnosis diagnosis = new Diagnosis();
            diagnosis.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }

        private void DGVDiagnosis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMedicineID.Text = DGVMedicines.SelectedRows[0].Cells[0].Value.ToString(); ;
            txtMedicineName.Text = DGVMedicines.SelectedRows[0].Cells[1].Value.ToString(); ;
            txtManufacturerName.Text = DGVMedicines.SelectedRows[0].Cells[2].Value.ToString(); ;
            txtQuantity.Text = DGVMedicines.SelectedRows[0].Cells[3].Value.ToString(); ;
            dateMedicine.Text = DGVMedicines.SelectedRows[0].Cells[4].Value.ToString(); ;
            txtUnitPrice.Text = DGVMedicines.SelectedRows[0].Cells[5].Value.ToString(); ;
            txtCategory.Text = DGVMedicines.SelectedRows[0].Cells[6].Value.ToString(); ;
        }

        private void reset()
        {
            DateTime dateTime = DateTime.Today;
            txtMedicineID.Text = "";
            txtMedicineName.Text = "";
            txtManufacturerName.Text = "";
            txtQuantity.Text = "";
            dateMedicine.Text = dateTime.ToString();
            txtUnitPrice.Text = "";
            txtCategory.Text = "";
        }

        void populate()
        {
            conn.Open();
            string query = "SELECT * FROM Medicine";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            var dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DGVMedicines.DataSource = dataSet.Tables[0];
            conn.Close();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.Show();
            this.Hide();
        }

        private void btnSurgery_Click(object sender, EventArgs e)
        {
            Surgery surgery = new Surgery();
            surgery.Show();
            this.Hide();
        }

        private void btnLabTests_Click(object sender, EventArgs e)
        {
            LabTest labTests = new LabTest();
            labTests.Show();
            this.Hide();
        }

        private void btnRadiology_Click(object sender, EventArgs e)
        {
            Radiology radiology = new Radiology();
            radiology.Show();
            this.Hide();
        }

        private void btnBloodDonor_Click(object sender, EventArgs e)
        {
            BloodDonor bloodDonor = new BloodDonor();
            bloodDonor.Show();
            this.Hide();
        }

        private void btnPrescription_Click(object sender, EventArgs e)
        {
            Prescription prescription = new Prescription();
            prescription.Show();
            this.Hide();
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            Department departments = new Department();
            departments.Show();
            this.Hide();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            Rooms rooms = new Rooms();
            rooms.Show();
            this.Hide();
        }

        private void btnWardAdmission_Click(object sender, EventArgs e)
        {
            WardAdmission wardAdmission = new WardAdmission();
            wardAdmission.Show();
            this.Hide();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            Billing billing = new Billing();
            billing.Show();
            this.Hide();
        }

        private void btnOutGoingPatient_Click(object sender, EventArgs e)
        {
            OutGoingPatient outGoingPatient = new OutGoingPatient();
            outGoingPatient.Show();
            this.Hide();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            Attendance attendance = new Attendance();
            attendance.Show();
            this.Hide();
        }

        private void btnEquipment_Click(object sender, EventArgs e)
        {
            Equipment equipment = new Equipment();
            equipment.Show();
            this.Hide();
        }

        private void btnMaintenanceLog_Click(object sender, EventArgs e)
        {
            MaintenanceLog maintenanceLog = new MaintenanceLog();
            maintenanceLog.Show();
            this.Hide();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            staff.Show();
            this.Hide();
        }

        private void btnNurseWardStaff_Click(object sender, EventArgs e)
        {
            NurseWardStaff nurseWardStaff = new NurseWardStaff();
            nurseWardStaff.Show();
            this.Hide();
        }

        private void btnSecurityStaff_Click(object sender, EventArgs e)
        {
            SecurityStaff securityStaff = new SecurityStaff();
            securityStaff.Show();
            this.Hide();
        }

        private void btnTransportStaff_Click(object sender, EventArgs e)
        {
            TransportStaff transportStaff = new TransportStaff();
            transportStaff.Show();
            this.Hide();
        }
    }
}
