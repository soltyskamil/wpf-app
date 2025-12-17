using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVMGym.Views
{
    public class FormViewBase : UserControl
    {
        static FormViewBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FormViewBase), new FrameworkPropertyMetadata(typeof(FormViewBase)));
        }
    }
}
