using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Compiler
{
    public record ControlTableLayout(Control Control, int Col, int Row, int ColSpan, int RowSpan)
    { }

    public static class ControlLayoutExtension
    {
        public static void WithLayoutSuspended<T> (this T control, Action<T> action)
            where T: Control
        {
            control.SuspendLayout();
            action(control);
            control.ResumeLayout();
        }        

        public static void ApplyLayout(this TableLayoutPanel panel, ControlTableLayout layout)
        {
            panel.Controls.Add(layout.Control, layout.Col, layout.Row);
            panel.SetColumnSpan(layout.Control, layout.ColSpan);
            panel.SetRowSpan(layout.Control, layout.RowSpan);
        }

        public static void ApplyLayouts(this TableLayoutPanel panel, List<ControlTableLayout> layouts)
        {
            layouts.ForEach(panel.ApplyLayout);
        }
    }
}
