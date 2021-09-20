using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Compiler
{
    public class CompilerUIForm : Form
    {
        private readonly TableLayoutPanel UILayout = new()
        {
            Name = "LayoutPanel",
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
            Dock = DockStyle.Fill,
            Location = new(3, 423),
            Name = "CompileButton",
            Size = new(794, 24),
            TabIndex = 2,
            Text = "Compile",
            UseVisualStyleBackColor = true,
        };
        private readonly Button OpenCodeFileButton = new()
        {
            Dock = DockStyle.Fill,
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
            AutoScaleDimensions = new(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new(800, 450);
            Controls.Add(UILayout);
            Name = "CompilerUIForm";
            Text = "Compiler";
        }

        private void RegisterHandlers()
        {
            CompileButton.Click += CompileButton_Click;
            OpenCodeFileButton.Click += OpenCodeFileButton_Click;
        }

        private void DoLayout()
        {
            this.WithLayoutSuspended(form =>
            {
                form.UILayout.WithLayoutSuspended(panel =>
                {
                    panel.ApplyLayouts(new()
                    {
                        new(form.CodeFilePath, Col: 0, Row: 0, ColSpan: 1, RowSpan: 1),
                        new(form.CompileResultListBox, Col: 0, Row: 1, ColSpan: 2, RowSpan: 1),
                        new(form.CompileButton, Col: 0, Row: 2, ColSpan: 2, RowSpan: 1),
                        new(form.OpenCodeFileButton, Col: 1, Row: 0, ColSpan: 1, RowSpan: 1),
                    });
                });
            });
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
            _ = new Compiler();
        }
    }
}
