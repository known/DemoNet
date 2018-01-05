using System.Collections;
using System.Windows.Automation;

namespace Demo.UIAuto
{
    class ElementHelper
    {
        private static Hashtable elements = new Hashtable();

        public static AutomationElement GetElement(string path)
        {
            if (elements.ContainsKey(path))
                return (AutomationElement)elements[path];

            lock (elements.SyncRoot)
            {
                if (!elements.ContainsKey(path))
                {
                    var desktop = AutomationElement.RootElement;
                    elements[path] = GetElement(desktop, path);
                }
            }

            return (AutomationElement)elements[path];
        }

        private static AutomationElement GetElement(AutomationElement rootWindow, string path)
        {
            string[] str = path.Split('.');
            if (str.Length > 1)
            {
                string[] parm = str[0].Split('|');
                AutomationElement window = null;
                if (parm.Length == 2)
                {
                    switch (parm[1])
                    {
                        case "Name":
                            window = rootWindow.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, str[0]));
                            break;
                    }
                }
                else
                {
                    window = rootWindow.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.AutomationIdProperty, str[0]));
                }
                string[] newstr = new string[str.Length - 1];
                for (int i = 1; i < str.Length; i++)
                {
                    newstr[i - 1] = str[i];
                }
                return GetElement(window, string.Join(",", newstr));
            }
            else
            {
                AutomationElement returnElement = null;
                string[] parm = str[0].Split('|');
                if (parm.Length == 2)
                {
                    switch (parm[1])
                    {
                        case "Name":
                            returnElement = rootWindow.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, parm[0]));
                            break;
                    }
                }
                else
                {
                    returnElement = rootWindow.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, parm[0]));
                }
                return returnElement;
            }
        }

        private void PerformAction()
        {
            var desktop = AutomationElement.RootElement;
            var condition = new PropertyCondition(AutomationElement.AutomationIdProperty, "Form1");
            var window = desktop.FindFirst(TreeScope.Children, condition);

            var textBox1 = window.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, "textBox1"));
            var textBox2 = window.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, "textBox2"));
            var button1 = window.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, "button1"));

            var vpTextBox1 = (ValuePattern)textBox1.GetCurrentPattern(ValuePattern.Pattern);
            var vpTextBox2 = (ValuePattern)textBox2.GetCurrentPattern(ValuePattern.Pattern);
            //var ipButton1 = (InvokePattern)button1.GetCurrentPattern(InvokePattern.Pattern);

            for (int i = 0; i < 10; i++)
            {
                vpTextBox1.SetValue("text1-" + i);
                vpTextBox2.SetValue("text2-" + i);
                textBox2.SetFocus();
                System.Windows.Forms.SendKeys.SendWait("{Enter}");
                //ipButton1.Invoke();
            }
        }
    }
}
