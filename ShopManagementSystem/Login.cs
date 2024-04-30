namespace ShopManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else if (username == "admin" && password == "1234")
            {
                Dashboard ds = new Dashboard();
                ds.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Username or password is wrong!");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblReset_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
        }
    }
}