using System.Diagnostics.Metrics;
using System.IO;
using System.Net.Mail;


namespace autoemail_sender
{
    public partial class Form1 : Form
    {
        List<Account> accountdata = new List<Account>();
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        public void sendmail(string name,string pwd)
        {

            try
            {
                //string Email = guna2TextBox4.Text;
                //string Password = guna2TextBox5.Text;
                string Email = name;
                string Password = pwd;
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient(textBox5.Text);
                mail.From = new MailAddress(Email);
                mail.To.Add(textBox1.Text);
                mail.Subject = textBox2.Text;
                mail.Body = textBox3.Text;



                smtp.Port = Convert.ToInt32(textBox4.Text);
                smtp.Credentials = new System.Net.NetworkCredential(Email, Password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
                MessageBox.Show("Mail has been sent successfully!", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string line in System.IO.File.ReadLines(@"accdata.txt"))
            {
                
                try
                {
                    string[] subs = line.Split(' ');
                    accountdata.Add(new Account() { Name = subs[0], Password = subs[1] });

                }
                catch
                {
                    MessageBox.Show("You hava a wrong accdata Format ");

                }
                


            }
            controll();
        }
        public void controll()
        {
            int Count = 0;
            try
            {
                for (int i = 0; i <= (int)numericUpDown1.Value; i++)
                {
                    

                    if (Count == accountdata.Count())
                    {
                        Count = 0;
                    }
                    else
                    {
                        Count++;

                    }
                   


                    sendmail(accountdata[Count].Name, accountdata[Count].Password);
                    Thread.Sleep(700);

                }
                MessageBox.Show("Finished");

            }
            catch
            {
                MessageBox.Show($"Fail");


            }
          
           
            

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}