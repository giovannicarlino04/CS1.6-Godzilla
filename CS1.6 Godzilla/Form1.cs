using Memory;

namespace CS1._6_Godzilla
{
    public partial class Form1 : Form
    {
        Mem m = new Mem();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

            int pID = m.GetProcIdFromName("hl");
            if (pID > 0)
            {
                m.OpenProcess(pID);
                label1.Text = "status: connected!";
            }
            else
            {
                label1.Text = "status: not connected";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Address offsets MUST be put from bottom to top, otherwise it won't work
            label2.Text = "Current Money: " + m.ReadMemory<int>("client.dll+0011A6AC,8,24,24,24,24,10,104").ToString();
            if (checkBox1.Checked == true)
            {
                m.WriteMemory("client.dll+0011A6AC,8,24,24,24,24,10,104", "int","1000000000");
            }

            label3.Text = "Current Ammo: " + m.ReadMemory<int>("client.dll+0011D5D8,A0").ToString();
            if (checkBox2.Checked == true)
            {
                m.FreezeValue("client.dll+0011D5D8,A0", "int", "20");
            }
        }
    }
}