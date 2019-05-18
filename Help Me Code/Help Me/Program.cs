using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Drawing;

class InterceptKeys
{
    private const int WH_KEYBOARD_LL = 13;

    private const int WM_KEYDOWN = 0x0100;

    private static LowLevelKeyboardProc _proc = HookCallback;

    private static IntPtr _hookID = IntPtr.Zero;

    private static StreamWriter writer = new StreamWriter(@"C:\Users\blang\Desktop\Dump.txt");

    [STAThread]
    public static void Main()
    {
        writer.WriteLine("");
        writer.WriteLine("import testMethods");
        writer.WriteLine("");
        writer.WriteLine("testMethods.test_code = FILLIN # name of test for email");
        writer.WriteLine("");

        writer.WriteLine("click = 1       # clicks an element");
        writer.WriteLine("assertt = 3     # asserts string in element");
        writer.WriteLine("sendKeys = 2    # sends text to element");
        writer.WriteLine("xClick = 5      # clicks an element using XPATH");
        writer.WriteLine("verify = 0      # verifies element is present");
        writer.WriteLine("");

        _hookID = SetHook(_proc);

        Application.Run();

        UnhookWindowsHookEx(_hookID);
    }


    private static IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using (Process curProcess = Process.GetCurrentProcess())

        using (ProcessModule curModule = curProcess.MainModule)

        {

            return SetWindowsHookEx(WH_KEYBOARD_LL, proc,

                GetModuleHandle(curModule.ModuleName), 0);
        }
    }


    private delegate IntPtr LowLevelKeyboardProc(

        int nCode, IntPtr wParam, IntPtr lParam);


    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        string clipboardText = "no";

        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);

            //
            // for the get URL
            //
            if ((Keys)vkCode == Keys.D9)
            {
                if (Clipboard.ContainsText(TextDataFormat.Text))
                {
                    clipboardText = Clipboard.GetText(TextDataFormat.Text);
                    writer.WriteLine("testMethods.driver.get('" + clipboardText + "')");
                    writer.WriteLine("");
                    Console.WriteLine((Keys)vkCode);
                }
            }

            //
            // for the click
            //
            if ((Keys)vkCode == Keys.D1)
            {
                string value = "";
                string comment = "";

                if (Clipboard.ContainsText(TextDataFormat.Text))
                {
                    clipboardText = Clipboard.GetText(TextDataFormat.Text);

                    Console.WriteLine((Keys)vkCode);

                    DialogResult input1 = InputBox("Button Comment", "Enter a comment for the button", ref value);
                    if (input1 == DialogResult.OK)
                    {
                        comment = value;
                    }

                    writer.WriteLine("testMethods.test_element(click, '" + clipboardText + "', None)  # " + comment);
                    writer.WriteLine("");
                }
            }

            //
            // for the sendkeys
            //
            if ((Keys)vkCode == Keys.D5)
            {
                string value = "";
                string comment = "";
                string sendKeys = "";

                if (Clipboard.ContainsText(TextDataFormat.Text))
                {
                    clipboardText = Clipboard.GetText(TextDataFormat.Text);

                    Console.WriteLine((Keys)vkCode);

                    DialogResult input1 = InputBox("Sendkeys", "Enter a sendkeys value", ref value);
                    if (input1 == DialogResult.OK)
                    {
                        sendKeys = value;
                    }

                    DialogResult input2 = InputBox("SendKeys Comment", "Enter a comment for sendkeys", ref value);
                    if (input2 == DialogResult.OK)
                    {
                        comment = value;
                    }

                    writer.WriteLine("testMethods.test_element(sendKeys, '" + clipboardText + "','" + sendKeys +"')  # " + comment);
                    writer.WriteLine("");
                }
            }

            //
            // for verify element present
            //
            if ((Keys)vkCode == Keys.D3)
            {
                string value = "";
                string comment = "";

                if (Clipboard.ContainsText(TextDataFormat.Text))
                {
                    clipboardText = Clipboard.GetText(TextDataFormat.Text);

                    Console.WriteLine((Keys)vkCode);

                    DialogResult input1 = InputBox("Verify Comment", "Enter a comment for the verify", ref value);
                    if (input1 == DialogResult.OK)
                    {
                        comment = value;
                    }

                    writer.WriteLine("testMethods.test_element(verify, '" + clipboardText + "', None)  # " + comment);
                    writer.WriteLine("");
                }
            }

            //
            // assert string in an element
            //
            if ((Keys)vkCode == Keys.D4)
            {
                string value = "";
                string comment = "";
                string assert = "";

                if (Clipboard.ContainsText(TextDataFormat.Text))
                {
                    clipboardText = Clipboard.GetText(TextDataFormat.Text);

                    Console.WriteLine((Keys)vkCode);

                    DialogResult input1 = InputBox("Assert", "Enter a assert value", ref value);
                    if (input1 == DialogResult.OK)
                    {
                        assert = value;
                    }

                    DialogResult input2 = InputBox("Assert Comment", "Enter a comment for assert", ref value);
                    if (input2 == DialogResult.OK)
                    {
                        comment = value;
                    }

                    writer.WriteLine("testMethods.test_element(assertt, '" + clipboardText + "','" + assert + "')  # " + comment);
                    writer.WriteLine("");
                }
            }

            //
            // for ending the program
            //
            if ((Keys)vkCode == Keys.D0)
            {
                Console.WriteLine((Keys)vkCode);
                writer.WriteLine("testMethods.driver.close()");
                writer.WriteLine("");
                writer.Close();
                Application.Exit();
            }
        }

        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }

    public static DialogResult InputBox(string title, string promptText, ref string value)
    {
        Form form = new Form();
        Label label = new Label();
        TextBox textBox = new TextBox();
        Button buttonOk = new Button();
        Button buttonCancel = new Button();

        form.Text = title;
        label.Text = promptText;
        textBox.Text = value;

        buttonOk.Text = "OK";
        buttonCancel.Text = "Cancel";
        buttonOk.DialogResult = DialogResult.OK;
        buttonCancel.DialogResult = DialogResult.Cancel;

        label.SetBounds(9, 20, 372, 13);
        textBox.SetBounds(12, 36, 372, 20);
        buttonOk.SetBounds(228, 72, 75, 23);
        buttonCancel.SetBounds(309, 72, 75, 23);

        label.AutoSize = true;
        textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
        buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

        form.ClientSize = new Size(396, 107);
        form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
        form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
        form.FormBorderStyle = FormBorderStyle.FixedDialog;
        form.StartPosition = FormStartPosition.CenterScreen;
        form.MinimizeBox = false;
        form.MaximizeBox = false;
        form.AcceptButton = buttonOk;
        form.CancelButton = buttonCancel;

        DialogResult dialogResult = form.ShowDialog();
        value = textBox.Text;
        return dialogResult;
    }


    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);


    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    [return: MarshalAs(UnmanagedType.Bool)]

    private static extern bool UnhookWindowsHookEx(IntPtr hhk);


    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);


    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    private static extern IntPtr GetModuleHandle(string lpModuleName);

}