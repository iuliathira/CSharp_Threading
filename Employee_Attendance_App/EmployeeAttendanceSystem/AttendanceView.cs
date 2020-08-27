using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeAttendanceSystem.Model;
using EmployeeAttendanceSystem.Services;

namespace EmployeeAttendanceSystem
{
    public partial class AttendanceView : Form
    {
        private EmployeeService service;

        public AttendanceView()
        {
            InitializeComponent();

        }

        public AttendanceView(EmployeeService service, Employee e)
        {
            InitializeComponent();
            this.service = service;
            populateTable(GetAttendances(e));
        }

        public void populateTable(List<Attendance> attendances)
        {
            if(dataGridView1.Rows.Count > 0)
                dataGridView1.Columns.Clear();
            dataGridView1.DataSource = attendances;
        }

        public List<Attendance> GetAttendances(Employee e)
        {
            return service.GetAttendancesForEmployee(e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
