using System.Diagnostics;

namespace PCSX2_AUTO_SAVER
{
    public partial class Form1 : Form
    {
        private bool _canCreateNewThread = true;
        private bool _canExitThread = false;
        private bool _canStart = true;


        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_3(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://github.com/iHytrex",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        // Start/Pause Button: Used for starting or stopping the AutoSave Thread. 
        private void button2_Click_1(object sender, EventArgs e)
        {
            // Used for Managing GUI elements.
            EnableDisable();

            // Check if a new thread can be created.
            if (_canCreateNewThread)
            {
                Console.WriteLine("Can Create new thread!")
;               _canCreateNewThread = false;
            }
            // Responsable for exiting the current function, this way not starting a new thread.
            else
            {

                Console.WriteLine("Can't Create new thread!");
                _canExitThread = true;
                _canStart = true;
                _canCreateNewThread = true;
                return;
            }

            // AutoSave thread, responsable for all the auto-save features.
            Thread autoSave = new Thread(() =>
            {
                Console.WriteLine("Running!!");
                while (!_canExitThread)
                {
                    if (_canExitThread)
                    {
                        Console.WriteLine("Exited While Loop!");
                        break;
                    }

                    Console.WriteLine("Sleeping Thread!");
                    Thread.Sleep((int)numericUpDown1.Value * 60000);

                    if (_canExitThread)
                    {
                        Console.WriteLine("Exited While Loop!");
                        break;
                    }

                    if (checkBox3.Checked && !_canExitThread)
                    {
                        SendKeys.SendWait("{F2}");
                        Console.WriteLine("Pressed F2!");

                        Thread.Sleep(5000);

                        Console.WriteLine("Exited While Loop!");
                    }

                    if (!_canExitThread)
                    {
                        Console.WriteLine("Pressing F1!");
                        SendKeys.SendWait("{F1}");
                    }
                    else
                    {
                        Console.WriteLine("Exited While Loop!");
                    }
                    

                    if (_canExitThread)
                    {
                        Console.WriteLine("Exited While Loop!");
                        break;
                    }
                }
                Console.WriteLine("Thread finished!");
            });

            // Starts a new thread.
            if (_canStart)
            {
                _canExitThread = false;
                _canStart = false;
                Console.WriteLine("Thread Started!");
                autoSave.Start();
            }
        }

        // Used for Managing GUI elements.
        private void EnableDisable()
        {
            bool status;
            if (checkBox3.Enabled)
            {
                button2.Text = "Stop";
                status = false;
            }
            else
            {
                button2.Text = "Start";
                status = true;
            }


            checkBox3.Enabled = status;
            numericUpDown1.Enabled = status;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // BETA
            SaveTools.Backup();
        }
    }
}

public static class SaveTools
{
    public static void Backup()
    {
        if (!Directory.Exists(@"C:\Users\Me\Documents\PCSX2\sstatesBackups"))
        {
            Directory.CreateDirectory(@"C:\Users\Me\Documents\PCSX2\sstatesBackups");
        }

        DirectoryInfo dI = new DirectoryInfo(@"C:\Users\Me\Documents\PCSX2\sstates");
        FileInfo[] files = dI.GetFiles("*.P2S");

        foreach (var file in files)
        {
            file.CopyTo($"C:\\Users\\Me\\Documents\\PCSX2\\sstatesBackups\\{file.Name}", true);
        }
    }
}
