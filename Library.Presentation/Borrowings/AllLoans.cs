using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            var history = _historyRepository.GetAll();
            foreach (var loan in history)
            {
                lstLoans.Items.Add(loan.Loan);
            }
        }
    }
}
