using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Data.Entities.Models;
using Library.Domain.Repositories;

namespace Library.Presentation.Borrowings
{
    public partial class AllLoans : Form
    {
        private readonly HistoryRepository _historyRepository;
        public AllLoans()
        {
            InitializeComponent();
            _historyRepository = new HistoryRepository();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AllLoans_Load(object sender, EventArgs e)
        {

            Reset();
            if (lstLoans.Items.Count == 0)
            {
                MessageBox.Show("No loans!");
                Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstLoans.SelectedItem == null)
            {
                MessageBox.Show(@"You haven't chosen anything");
                return;
                
            }

            if (_historyRepository.RemoveLoan(lstLoans.SelectedItem.ToString()))
                MessageBox.Show("Removed loan");
            Reset();

        }

        public void Reset()
        {
            lstLoans.Items.Clear();
            var history = _historyRepository.GetAll();
            foreach (var loan in history)
            {
                lstLoans.Items.Add(loan.Loan);
            }
        }
    }
}
