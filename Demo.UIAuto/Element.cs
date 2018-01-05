using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace Demo.UIAuto
{
    public class Element
    {
        public static AutomationElement FindWindowByProcessId(int processId)
        {
            AutomationElement targetWindow = null;
            int count = 0;
            try
            {
                var process = Process.GetProcessById(processId);
                targetWindow = AutomationElement.FromHandle(process.MainWindowHandle);
                return targetWindow;
            }
            catch (Exception ex)
            {
                count++;
                var message = string.Format("Target window is not existing.try #{0}", count);
                if (count > 5)
                {
                    throw new InvalidProgramException(message, ex);
                }
                else
                {
                    return FindWindowByProcessId(processId);
                }
            }
        }

        public static AutomationElement FindElementById(int processId, string automationId)
        {
            var window = FindWindowByProcessId(processId);
            var element = window.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
            return element;
        }
    }
}
