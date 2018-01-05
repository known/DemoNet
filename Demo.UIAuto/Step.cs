using System;
using System.Collections.Generic;
using System.Windows.Automation;

namespace Demo.UIAuto
{
    public class Step
    {
        public Step(int processId, string step, Dictionary<string, string> data)
        {
            var index = step.IndexOf("=>");
            if (index < 0)
                throw new Exception("步骤格式不正确！");

            ActionType = (ActionType)Enum.Parse(typeof(ActionType), step.Substring(0, index));
            Data = data;

            var path = step.Substring(index + 2);
            index = path.IndexOf("=>d[");
            if (index > 0)
            {
                DataKey = path.Substring(index + 4).TrimEnd(']');
                path = path.Substring(0, index);
            }
            //Element = ElementHelper.GetElement(path);
            Element = Demo.UIAuto.Element.FindElementById(processId, path);
        }

        public ActionType ActionType { get; private set; }
        public Dictionary<string, string> Data { get; private set; }
        public AutomationElement Element { get; private set; }
        public string DataKey { get; private set; }

        public void Perform()
        {
            if (Element == null)
                return;

            var sendKeys = new SendKeys();
            switch (ActionType)
            {
                case ActionType.SetValue:
                    sendKeys.Sendkeys(Element, Data[DataKey]);
                    break;
                case ActionType.SetValueAndEnter:
                    sendKeys.Sendkeys(Element, Data[DataKey], sendKeys.Enter);
                    break;
                case ActionType.Click:
                    var ip = (InvokePattern)Element.GetCurrentPattern(InvokePattern.Pattern);
                    ip.Invoke();
                    break;
                default:
                    break;
            }
        }

        private void PerformSetValue()
        {
            var vp = (ValuePattern)Element.GetCurrentPattern(ValuePattern.Pattern);
            vp.SetValue(Data[DataKey]);
        }
    }
}
