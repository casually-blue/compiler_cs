using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Compiler
{
    public class CompilerUIForm : Form
    {
        private readonly TableLayoutPanel tableLayoutPanel1 = new()
        {
            Name = "tableLayoutPanel1",
            ColumnCount = 2,
            ColumnStyles = {
                new(SizeType.Percent, 75F),
                new(SizeType.Percent, 25F),
            },
            RowCount = 3,
            RowStyles = {
                new(SizeType.Absolute, 30F),
                new(SizeType.Percent, 100F),
                new(SizeType.Absolute, 30F),
            },
            Dock = DockStyle.Fill,
            Location = new(0, 0),
            Size = new(800, 450),

            TabIndex = 0,
        };
        private readonly TextBox CodeFilePath = new()
        {
            Name = "CodeFilePath",

            Dock = DockStyle.Fill,
            Location = new(3, 3),
            Size = new(594, 23),

            TabIndex = 0,
        };
        private readonly ListBox CompileResultListBox = new()
        {
            Name = "CompileResultListBox",

            Dock = DockStyle.Fill,

            FormattingEnabled = true,
            ItemHeight = 15,
            Location = new(3, 33),
            Size = new(794, 384),

            TabIndex = 1,
        };
        private readonly Button CompileButton = new()
        {
            Dock = System.Windows.Forms.DockStyle.Fill,
            Location = new(3, 423),
            Name = "CompileButton",
            Size = new(794, 24),
            TabIndex = 2,
            Text = "Compile",
            UseVisualStyleBackColor = true,
        };
        private readonly Button OpenCodeFileButton = new()
        {
            Dock = System.Windows.Forms.DockStyle.Fill,
            Location = new(603, 3),
            Name = "OpenCodeFileButton",
            Size = new(194, 24),
            TabIndex = 3,
            Text = "Open File",
            UseVisualStyleBackColor = true,
        };
        private readonly OpenFileDialog CodeFileDialog = new()
        {
            FileName = "codefile.sc",
            Filter = "Code Files (*.sc)|*.sc|All files( *.*)|*.*",
            InitialDirectory = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}",
        };

        public CompilerUIForm()
        {
            SetFormBaseVisuals();

            DoLayout();

            RegisterHandlers();
        }

        private void SetFormBaseVisuals()
        {
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "CompilerUIForm";
            Text = "Compiler";
        }

        private void RegisterHandlers()
        {
            CompileButton.Click += new(CompileButton_Click);
            OpenCodeFileButton.Click += new(OpenCodeFileButton_Click);
        }

        private void DoLayout()
        {
            UpdateLayout(this, () =>
            {
                UpdateLayout(tableLayoutPanel1, () =>
                {
                    new List<(Control control, int col, int row)>() {
                        (CodeFilePath, 0, 0),
                        (CompileResultListBox, 0, 1),
                        (CompileButton, 0, 2),
                        (OpenCodeFileButton, 1, 0),
                    }.ForEach((ccr) => tableLayoutPanel1.Controls.Add(ccr.control, ccr.col, ccr.row));

                    new List<(Control control, int colSpan)>() {
                        (CompileResultListBox, 2),
                        (CompileButton, 2)
                    }.ForEach((ccs) => tableLayoutPanel1.SetColumnSpan(ccs.control, ccs.colSpan));

                });
            });
        }

        private static void UpdateLayout(Control control, Action action)
        {
            control.SuspendLayout();
            action();
            control.ResumeLayout();
        }

        private void OpenCodeFileButton_Click(object? sender, EventArgs e)
        {
            if (CodeFileDialog.ShowDialog() == DialogResult.OK)
            {
                CodeFilePath.Text = CodeFileDialog.FileName;
            }
        }

        private void CompileButton_Click(object? sender, EventArgs e)
        {
            Compiler compiler = new();
        }
    }
}
